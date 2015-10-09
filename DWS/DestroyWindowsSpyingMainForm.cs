﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DWS_Lite.lang;
using DWS_Lite.lib;
using DWS_Lite.Properties;
using Microsoft.Win32;

namespace DWS_Lite
{
    public partial class DestroyWindowsSpyingMainForm : Form
    {
        private ResourceManager _rm;
        private readonly string _systemPath = Path.GetPathRoot(Environment.SystemDirectory);
        private string _shellCmdLocation;
        private string _system32Location;
        private string _logFileName = "DWS.log";
        private bool _win10 = true;
        private int _fatalErrors;
        private bool _debug;

        public DestroyWindowsSpyingMainForm(string[] args)
        {

            InitializeComponent();
            // Re create log file
            RecreateLogFile(_logFileName);
            // Check windows version
            CheckWindowsVersion();
            //Check SYSNATIVE (x64)
            _SetShellSys32Path();
            ProfessionalModeSet(false);
            CheckEnableOrDisableUac();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            Text += Resources.build_number;
            labelBuildDataTime.Text = @"Build number:" + Resources.build_number + @"  |  Build Time:" +
                                      Resources.build_datatime;

            SetLanguage(_GetLang(args));
            ChangeLanguage();
            StealthMode(args);
            new Thread(CheckUpdates).Start();
            new Thread(AnimateBackground).Start();

        }

        void AnimateBackground()
        {
            while (true)
            {
                for (float i = 0; i < 1f; i += 0.01f)
                {
                    Thread.Sleep(50);
                    ChangeBorderColor(Rainbow(i));
                }
            }
        }

        void CheckUpdates()
        {
            try
            {
                string latestVersion = new WebClient().DownloadString(
                    "http://raw.githubusercontent.com/Nummer/Destroy-Windows-10-Spying/master/DWS/Resources/build_number.txt");
                if (Convert.ToInt32(Resources.build_number) <
                    Convert.ToInt32(latestVersion))
                {
                    if (
                        MessageBox.Show(
                            string.Format("New version found.\nBuild number: {0}\nDownload now?", latestVersion),
                            @"Update",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start("https://github.com/Nummer/Destroy-Windows-10-Spying/releases/latest");
                    }
                }
                _OutPut(string.Format("Latest version number: {0}", latestVersion));
            }
            catch (Exception ex)
            {
                _OutPut("Error check updates.", LogLevel.Error);
                if (_debug) _OutPut(ex.Message, LogLevel.Debug);
            }
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (WindowsUtil.SystemRestore_Status() == 0) _OutPut("Windows Restore DISABLE", LogLevel.Warning);
        }

        void StealthMode(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].IndexOf("-debug", StringComparison.Ordinal) > -1)
                {
                    _debug = true;
                }
                if (args[i].IndexOf("/deleteapp=", StringComparison.Ordinal) > -1)
                {
                    DeleteWindows10MetroApp(args[i].Replace("/deleteapp=", null));
                    Process.GetCurrentProcess().Kill();
                }
                if (args[i].IndexOf("/destroy", StringComparison.Ordinal) > -1)
                {
                    WindowState = FormWindowState.Minimized;
                    ShowInTaskbar = false;
                    //Windows 10
                    if (_win10)
                    {
                        DestroyWindowsSpyingMainThread();
                    }
                    else
                    {
                        AddToHostsAndFirewall();
                        DisableSpyingTasks();
                        DeleteUpdatesWin78();
                    }
                    Process.GetCurrentProcess().Kill();
                }
            }
        }
        private void _SetShellSys32Path()
        {
            if (File.Exists(_systemPath + @"Windows\Sysnative\cmd.exe"))
            {
                _shellCmdLocation = _systemPath + @"Windows\Sysnative\cmd.exe";
                _system32Location = _systemPath + @"Windows\System32\";
            }
            else
            {
                _shellCmdLocation = _systemPath + @"Windows\System32\cmd.exe";
                _system32Location = _systemPath + @"Windows\System32\";
            }
        }
        private void CheckWindowsVersion()
        {
            int windowsBuildNumber = WindowsUtil.GetWindowsBuildNumber();

            if (windowsBuildNumber < 7600)
            {
                MessageBox.Show(@"Minimum windows version - 7", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
            }

            // check Win 7 or 8.1
            if (windowsBuildNumber < 10000)
            {
                _win10 = false;
                tabPageUtilites.Enabled = false;
                tabPageSettings.Enabled = false;
                btnDestroyWindowsSpying.Visible = false;
                btnDestroyWindows78Spy.Visible = true;
            }
            //------------------------------------------

        }
        #region Language
        private string _GetLang(string[] args)
        {
            string languageName = null;
            // check args lang
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].IndexOf("/lang=", StringComparison.Ordinal) > -1)
                {
                    languageName = args[i].Replace("/lang=", null);
                }
            }
            return languageName;
        }

        private void SetLanguage(string currentlang = null)
        {
            if (currentlang == null)
            {
                currentlang = CultureInfo.CurrentUICulture.Name.ToLower();
            }
            if (currentlang.IndexOf("ru", StringComparison.Ordinal) > -1)
            {
                _rm = ru_RU.ResourceManager;
                comboBoxLanguageSelect.Text = @"ru-RU | Русский";
            }
            else if (currentlang.IndexOf("fr", StringComparison.Ordinal) > -1)
            {
                _rm = fr_FR.ResourceManager;
                comboBoxLanguageSelect.Text = @"fr-FR | French";
            }
            else if (currentlang.IndexOf("es", StringComparison.Ordinal) > -1)
            {
                _rm = es_ES.ResourceManager;
                comboBoxLanguageSelect.Text = @"es-ES | Spanish";
            }
            else if (currentlang.IndexOf("pt", StringComparison.Ordinal) > -1)
            {
                _rm = pt_BR.ResourceManager;
                comboBoxLanguageSelect.Text = @"pt-BR | Portuguese";
            }
            else if (currentlang.IndexOf("de", StringComparison.Ordinal) > -1)
            {
                _rm = de_DE.ResourceManager;
                comboBoxLanguageSelect.Text = @"de-DE | German";
            }
            else if (currentlang.IndexOf("pl", StringComparison.Ordinal) > -1)
            {
                _rm = pl_PL.ResourceManager;
                comboBoxLanguageSelect.Text = @"pl-PL | Polish";
            }
            else if (currentlang.IndexOf("it", StringComparison.Ordinal) > -1)
            {
                _rm = it_CH.ResourceManager;
                comboBoxLanguageSelect.Text = @"it-CH | Italian";
            }
            else if (currentlang.IndexOf("cs", StringComparison.Ordinal) > -1)
            {
                _rm = cs_CZ.ResourceManager;
                comboBoxLanguageSelect.Text = @"cs-CZ | Czech";
            }
            else if (currentlang.IndexOf("cn", StringComparison.Ordinal) > -1)
            {
                _rm = zh_CN.ResourceManager;
                comboBoxLanguageSelect.Text = @"zh-CN | 中文(简体)";
            }
            else
            {
                _rm = en_US.ResourceManager;
                comboBoxLanguageSelect.Text = @"en-US | English";
            }
        }

        void ChangeLanguage()
        {
            ReadmeRichTextBox.Text = GetTranslateText("ReadMeTextBox");
            tabPageMain.Text = GetTranslateText("tabPageMain");
            tabPageAbout.Text = GetTranslateText("tabPageAbout");
            tabPageReadMe.Text = GetTranslateText("tabPageReadMe");
            tabPageSettings.Text = GetTranslateText("tabPageSettings");
            tabPageUtilites.Text = GetTranslateText("tabPageUtilites");
            btnDeleteAllWindows10Apps.Text = GetTranslateText("btnDeleteAllWindows10Apps");
            btnDeleteOneDrive.Text = GetTranslateText("btnDeleteOneDrive");
            btnOpenAndEditHosts.Text = GetTranslateText("btnOpenAndEditHosts");
            btnProfessionalMode.Text = GetTranslateText("btnProfessionalMode");
            btnRestoreSystem.Text = GetTranslateText("btnRestoreSystem");
            checkBoxAddToHosts.Text = GetTranslateText("checkBoxAddToHosts");
            checkBoxCreateSystemRestorePoint.Text = GetTranslateText("checkBoxCreateSystemRestorePoint");
            checkBoxDeleteWindows10Apps.Text = GetTranslateText("checkBoxDeleteWindows10Apps");
            checkBoxDisablePrivateSettings.Text = GetTranslateText("checkBoxDisablePrivateSettings");
            checkBoxDisableWindowsDefender.Text = GetTranslateText("checkBoxDisableWindowsDefender");
            checkBoxKeyLoggerAndTelemetry.Text = GetTranslateText("checkBoxKeyLoggerAndTelemetry");
            checkBoxSetDefaultPhoto.Text = GetTranslateText("checkBoxSetDefaultPhoto");
            checkBoxSPYTasks.Text = GetTranslateText("checkBoxSPYTasks");
            labelInfoDeleteMetroApps.Text = GetTranslateText("labelInfoDeleteMetroApps");
            btnEnableUac.Text = string.Format("{0} UAC", GetTranslateText("Enable"));
            btnDisableUac.Text = string.Format("{0} UAC", GetTranslateText("Disable"));
            btnDisableOfficeUpdate.Text = string.Format("{0} Office 2016 Telemetry", GetTranslateText("Disable"));
            btnDisableWindowsUpdate.Text = string.Format("{0} Windows Update", GetTranslateText("Disable"));
            btnEnableWindowsUpdate.Text = string.Format("{0} Windows Update", GetTranslateText("Enable"));
            checkBoxDeleteApp3d.Text = string.Format("{0} Builder 3D", GetTranslateText("Delete"));
            checkBoxDeleteAppCamera.Text = string.Format("{0} Camera", GetTranslateText("Delete"));
            checkBoxDeleteMailCalendarMaps.Text = string.Format("{0} Mail, Calendar, Maps", GetTranslateText("Delete"));
            checkBoxDeleteAppBing.Text = string.Format("{0} Money, Sports, News, Weather", GetTranslateText("Delete"));
            checkBoxDeleteAppZune.Text = string.Format("{0} Groove Music, Film TV", GetTranslateText("Delete"));
            checkBoxDeleteAppPeopleOneNote.Text = string.Format("{0} People, OneNote", GetTranslateText("Delete"));
            checkBoxDeleteAppPhone.Text = string.Format("{0} Phone Companion", GetTranslateText("Delete"));
            checkBoxDeleteAppPhotos.Text = string.Format("{0} Photos", GetTranslateText("Delete"));
            checkBoxDeleteAppSolit.Text = string.Format("{0} Solitaire Collection", GetTranslateText("Delete"));
            checkBoxDeleteAppVoice.Text = string.Format("{0} Voice Recorder", GetTranslateText("Delete"));
            checkBoxDeleteAppXBOX.Text = string.Format("{0} XBOX", GetTranslateText("Delete"));
            btnRemoveOldFirewallRules.Text = GetTranslateText("RemoveAllOldFirewallRules");
            btnReportABug.Text = GetTranslateText("ReportABug");
            groupBoxLinks.Text = GetTranslateText("Links");
        }
        string GetTranslateText(string name)
        {
            try
            {
                return _rm.GetString(name);
            }
            catch (Exception ex)
            {
                if (_debug) _OutPut(ex.Message, LogLevel.Debug);
                return null;
            }
        }
        #endregion
        private void CheckEnableOrDisableUac()
        {
            if (WindowsUtil.UAC_Status())
            {
                btnEnableUac.Enabled = true;
                btnDisableUac.Enabled = false;
            }
            else
            {
                btnEnableUac.Enabled = false;
                btnDisableUac.Enabled = true;
            }

            if (WindowsUtil.SystemRestore_Status() == 0)
            {
                checkBoxCreateSystemRestorePoint.Checked = false;
                checkBoxCreateSystemRestorePoint.Enabled = false;
            }

        }
        private void btnDestroyWindowsSpying_Click(object sender, EventArgs e)
        {
            StartDestroyWindowsSpying();
        }
        #region Output
        private void LogOutputTextBox_TextChanged(object sender, EventArgs e)
        {
            LogOutputTextBox.SelectionStart = LogOutputTextBox.Text.Length;
            LogOutputTextBox.ScrollToCaret();
        }

        private void _OutPut(string str)
        {
            _OutPut(str, LogLevel.Info);
        }

        private void _OutPutSplit()
        {
            try
            {
                Invoke(new MethodInvoker(delegate
                {
                    OutPutSplitInvoke();
                }));
            }
            catch
            {
                try
                {
                    OutPutSplitInvoke();
                }
                catch
                {
                    _fatalErrors++;
                }
            }
        }

        private void _OutPut(string str, LogLevel logLevel)
        {
            try
            {
                Invoke(new MethodInvoker(delegate
                {
                    _OutPutInvoke(str, logLevel);
                }));
            }
            catch
            {
                try
                {
                    _OutPutInvoke(str, logLevel);
                }
                catch
                {
                    _fatalErrors++;
                }
            }
        }

        private enum LogLevel // thx TRoskop
        {
            Info,
            Warning,
            Error,
            FatalError,
            Debug
        };
        private void _OutPutInvoke(string str, LogLevel logLevel)
        {
            if(logLevel == LogLevel.Debug && String.IsNullOrEmpty(str))
                return;

            switch (logLevel)
            {
                case LogLevel.Info:
                    str = "[INFO] " + str;
                    break;
                case LogLevel.Warning:
                    str = "[WARNING] " + str;
                    break;
                case LogLevel.Error:
                    str = "[ERROR] " + str;
                    break;
                case LogLevel.FatalError:
                    str = "[!! FATAL ERROR !!] " + str;
                    break;
                case LogLevel.Debug:
                    str = "[DEBUG] " + str;
                    break;
            }
            File.WriteAllText(_logFileName, File.ReadAllText(_logFileName) + str + Environment.NewLine);
            Console.WriteLine(str);
            LogOutputTextBox.Text += str + Environment.NewLine;
        }

        private void OutPutSplitInvoke()
        {
            string splittext = "==========================" + Environment.NewLine;
            File.WriteAllText(_logFileName, File.ReadAllText(_logFileName) + splittext);
            LogOutputTextBox.Text += splittext;
        }

        #endregion
        private void Progressbaradd(int numberadd)
        {
            try
            {
                Invoke(new MethodInvoker(delegate
                {
                    try
                    {
                        ProgressBarStatus.Value += numberadd;
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }));
            }
            catch (Exception)
            {
                try
                {
                    ProgressBarStatus.Value += numberadd;
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
        private void EnableOrDisableTab(bool enableordisable)
        {
            try
            {
                Invoke(new MethodInvoker(delegate
                {
                    this.ControlBox = enableordisable;
                    btnDestroyWindowsSpying.Enabled = enableordisable;
                    tabPageSettings.Enabled = enableordisable;
                    tabPageUtilites.Enabled = enableordisable;
                }));
            }
            catch (Exception)
            {
                ControlBox = enableordisable;
                tabPageMain.Enabled = enableordisable;
                tabPageSettings.Enabled = enableordisable;
                tabPageUtilites.Enabled = enableordisable;
            }
        }

        public void RecreateLogFile(string logfilename)
        {
            try
            {
                if (!File.Exists(logfilename))
                {
                    File.Create(logfilename).Close();
                }
                else
                {
                    File.Delete(logfilename);
                    File.Create(logfilename).Close();
                }
            }
            catch (Exception ex)
            {
                if (_debug) _OutPut(ex.Message, LogLevel.Debug);
            }
        }
        public void DeleteFile(string filepath)
        {
            RunCmd(String.Format("/c del /F /Q \"{0}\"", filepath));
        }

        public void RunCmd(string args)
        {
            ProcStartargs(Paths.ShellCmdLocation, args);
        }

        private void ProcStartargs(string name, string args)
        {
            try
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = name,
                        Arguments = args,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true,
                        StandardOutputEncoding = Encoding.GetEncoding(866)
                    }
                };
                proc.Start();
                string line = null;
                while (!proc.StandardOutput.EndOfStream)
                {
                    line += Environment.NewLine + proc.StandardOutput.ReadLine();
                }
                if (_debug) _OutPut("Start: " + name + " " + args + Environment.NewLine + "Output: " + line, LogLevel.Debug);
            }
            catch (Exception ex)
            {
                _OutPut("Error start prog " + name + " " + args, LogLevel.Error);
                if (_debug) _OutPut(ex.Message, LogLevel.Debug);
                _fatalErrors++;
            }
        }
        private void CreateRestorePoint(string description)
        {
            ManagementScope oScope = new ManagementScope("\\\\localhost\\root\\default");
            ManagementPath oPath = new ManagementPath("SystemRestore");
            ObjectGetOptions oGetOp = new ObjectGetOptions();
            ManagementClass oProcess = new ManagementClass(oScope, oPath, oGetOp);

            ManagementBaseObject oInParams =
                oProcess.GetMethodParameters("CreateRestorePoint");
            oInParams["Description"] = description;
            oInParams["RestorePointType"] = 12; // MODIFY_SETTINGS
            oInParams["EventType"] = 100;

            oProcess.InvokeMethod("CreateRestorePoint", oInParams, null);
        }
        private string GetWindowsBuildVersion()
        {

            // в value массив из байт
            string value = "Product Name: " + WindowsUtil.GetProductName() + Environment.NewLine;
            value += "  Build: " + WindowsUtil.GetSystemBuild();
            return value;

        }
        #region registry
        private void SetRegValueHkcu(string regkeyfolder, string paramname, string paramvalue, RegistryValueKind keytype)
        {
            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(regkeyfolder);
            if (registryKey != null)
                registryKey.Close();
            RegistryKey myKey = Registry.CurrentUser.OpenSubKey(regkeyfolder, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
            try
            {
                if (myKey != null)
                {
                    myKey.SetValue(paramname, paramvalue, keytype);
                }
            }
            catch (Exception ex)
            {
                _fatalErrors++;
                _OutPut(GetTranslateText("Error") + ": " + ex.Message, LogLevel.Error);
            }

            if (myKey != null) myKey.Close();
        }
        private void SetRegValueHklm(string regkeyfolder, string paramname, string paramvalue, RegistryValueKind keytype)
        {
            try
            {
                RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(regkeyfolder);
                if (registryKey != null)
                    registryKey.Close();
                RegistryKey myKey = Registry.LocalMachine.OpenSubKey(regkeyfolder,
                    RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
                try
                {
                    if (myKey != null)
                    {
                        myKey.SetValue(paramname, paramvalue, keytype);
                    }
                }
                catch (Exception ex)
                {
                    _fatalErrors++;
                    _OutPut(GetTranslateText("Error") + ": " + ex.Message, LogLevel.Error);
                }
                if (myKey != null) myKey.Close();
            }
            catch (Exception ex)
            {
                _fatalErrors++;
                _OutPut(GetTranslateText("Error") + ": " + ex.Message, LogLevel.Error);
            }
        }
        #endregion
        private void DeleteWindows10MetroApp(string appname)
        {
            ProcStartargs("powershell", "-command \"Get-AppxPackage *" + appname + "* | Remove-AppxPackage\"");
        }
        private void StartDestroyWindowsSpying()
        {
            EnableOrDisableTab(false);
            SetCompleteText(true);
            _OutPut(string.Format("Starting: {0}.", DateTime.Now));
            _OutPut(GetWindowsBuildVersion());
            _OutPutSplit();
            _fatalErrors = 0;
            ProgressBarStatus.Value = 0;
            new Thread(DestroyWindowsSpyingMainThread).Start();
        }
        private void DestroyWindowsSpyingMainThread()
        {
            if (checkBoxCreateSystemRestorePoint.Checked)
            {
                try
                {
                    string restorepointName = "DestroyWindowsSpying " + DateTime.Now;
                    _OutPut("Creating restore point " + restorepointName + "...");
                    CreateRestorePoint(restorepointName);
                    _OutPut("Restore point " + restorepointName + " created.");
                }
                catch (Exception ex)
                {
                    _OutPut("Error creating restore point.");
                    if (_debug) _OutPut(ex.Message, LogLevel.Debug);
                }
            }
            Progressbaradd(10);
            if (checkBoxKeyLoggerAndTelemetry.Checked)
            {
                // DISABLE TELEMETRY
                _OutPut("Disable telemetry...");
                RunCmd("/c net stop DiagTrack ");
                RunCmd("/c net stop diagnosticshub.standardcollector.service ");
                RunCmd("/c net stop dmwappushservice ");
                RunCmd("/c net stop WMPNetworkSvc ");
                RunCmd("/c sc config DiagTrack start=disabled ");
                RunCmd("/c sc config diagnosticshub.standardcollector.service start=disabled ");
                RunCmd("/c sc config dmwappushservice start=disabled ");
                RunCmd("/c sc config WMPNetworkSvc start=disabled ");
                RunCmd("/c REG ADD HKLM\\SYSTEM\\ControlSet001\\Control\\WMI\\AutoLogger\\AutoLogger-Diagtrack-Listener /v Start /t REG_DWORD /d 0 /f");
                RunCmd("/c net stop dmwappushservice");
                RunCmd("/c net stop diagtrack");
                RunCmd("/c sc delete dmwappushsvc");
                RunCmd("/c sc delete \"Diagnostics Tracking Service\"");
                RunCmd("/c sc delete diagtrack");
                RunCmd("/c reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Device Metadata\" /v \"PreventDeviceMetadataFromNetwork\" /t REG_DWORD /d 1 /f ");
                RunCmd("/c reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection\" /v \"AllowTelemetry\" /t REG_DWORD /d 0 /f ");
                RunCmd("/c reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\MRT\" /v \"DontOfferThroughWUAU\" /t REG_DWORD /d 1 /f ");
                RunCmd("/c reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\SQMClient\\Windows\" /v \"CEIPEnable\" /t REG_DWORD /d 0 /f ");
                RunCmd("/c reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat\" /v \"AITEnable\" /t REG_DWORD /d 0 /f ");
                RunCmd("/c reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat\" /v \"DisableUAR\" /t REG_DWORD /d 1 /f ");
                RunCmd("/c reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\DataCollection\" /v \"AllowTelemetry\" /t REG_DWORD /d 0 /f ");
                RunCmd("/c reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\WMI\\AutoLogger\\AutoLogger-Diagtrack-Listener\" /v \"Start\" /t REG_DWORD /d 0 /f ");
                RunCmd("/c reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\WMI\\AutoLogger\\SQMLogger\" /v \"Start\" /t REG_DWORD /d 0 /f ");
                RunCmd("/c reg add \"HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Siuf\\Rules\" /v \"NumberOfSIUFInPeriod\" /t REG_DWORD /d 0 /f ");
                RunCmd("/c reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat\" /v \"DisableUAR\" /t REG_DWORD /d 1 /f ");
                RunCmd("/c reg add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\SQMClient\\Windows\" /v \"CEIPEnable\" /t REG_DWORD /d 0 /f ");
                RunCmd("/c reg delete \"HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Siuf\\Rules\" /v \"PeriodInNanoSeconds\" /f ");
                // DELETE KEYLOGGER
                _OutPut("Delete keylogger...");
            }
            Progressbaradd(15); //25
            if (checkBoxAddToHosts.Checked)
            {
                AddToHostsAndFirewall();
            }
            Progressbaradd(20); //45
            if (checkBoxDisablePrivateSettings.Checked)
            {

                SetRegValueHkcu(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{21157C1F-2651-4CC1-90CA-1F28B02263F6}",
                    "Value", "Deny", RegistryValueKind.String);
                SetRegValueHkcu(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{2EEF81BE-33FA-4800-9670-1CD474972C3F}",
                    "Value", "Deny", RegistryValueKind.String);
                SetRegValueHkcu(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{7D7E8402-7C54-4821-A34E-AEEFD62DED93}",
                    "Value", "Deny", RegistryValueKind.String);
                SetRegValueHkcu(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{992AFA70-6F47-4148-B3E9-3003349C1548}",
                    "Value", "Deny", RegistryValueKind.String);
                SetRegValueHkcu(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{9D9E0118-1807-4F2E-96E4-2CE57142E196}",
                    "Value", "Deny", RegistryValueKind.String);
                SetRegValueHkcu(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{A8804298-2D5F-42E3-9531-9C8C39EB29CE}",
                    "Value", "Deny", RegistryValueKind.String);
                SetRegValueHkcu(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{B19F89AF-E3EB-444B-8DEA-202575A71599}",
                    "Value", "Deny", RegistryValueKind.String);
                SetRegValueHkcu(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}",
                    "Value", "Deny", RegistryValueKind.String);
                SetRegValueHkcu(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{C1D23ACC-752B-43E5-8448-8D0E519CD6D6}",
                    "Value", "Deny", RegistryValueKind.String);
                SetRegValueHkcu(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{D89823BA-7180-4B81-B50C-7E471E6121A3}",
                    "Value", "Deny", RegistryValueKind.String);
                SetRegValueHkcu(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{E5323777-F976-4f5b-9B55-B94699C46E44}",
                    "Value", "Deny", RegistryValueKind.String);
                SetRegValueHkcu(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{E6AD100E-5F4E-44CD-BE0F-2265D88D14F5}",
                    "Value", "Deny", RegistryValueKind.String);
                SetRegValueHkcu(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\{E83AF229-8640-4D18-A213-E22675EBB2C3}",
                    "Value", "Deny", RegistryValueKind.String);
                SetRegValueHkcu(@"SOFTWARE\Microsoft\Windows\CurrentVersion\DeviceAccess\Global\LooselyCoupled",
                    "Value", "Deny", RegistryValueKind.String);
                _OutPut("Disable private settings");
                SetRegValueHkcu(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Search", "CortanaEnabled", "0",
                    RegistryValueKind.DWord);
                SetRegValueHkcu(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Search", "BingSearchEnabled", "0",
                    RegistryValueKind.DWord);
            }
            Progressbaradd(10); //55
            if (checkBoxDisableWindowsDefender.Checked)
            {
                try
                {
                    SetRegValueHklm(@"SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", "1",
                        RegistryValueKind.DWord);
                    _OutPut("Disable Windows Defender.");
                }
                catch (Exception ex)
                {
                    _OutPut("Error disable windows Defender", LogLevel.Error);
                    if (_debug) _OutPut(ex.Message, LogLevel.Debug);
                    _fatalErrors++;
                }
            }
            Progressbaradd(5); //60
            if (checkBoxSetDefaultPhoto.Checked)
            {
                SetRegValueHkcu(@"Software\Classes\.ico", null, "PhotoViewer.FileAssoc.Tiff", RegistryValueKind.String);
                SetRegValueHkcu(@"Software\Classes\.tiff", null, "PhotoViewer.FileAssoc.Tiff", RegistryValueKind.String);
                SetRegValueHkcu(@"Software\Classes\.bmp", null, "PhotoViewer.FileAssoc.Tiff", RegistryValueKind.String);
                SetRegValueHkcu(@"Software\Classes\.png", null, "PhotoViewer.FileAssoc.Tiff", RegistryValueKind.String);
                SetRegValueHkcu(@"Software\Classes\.gif", null, "PhotoViewer.FileAssoc.Tiff", RegistryValueKind.String);
                SetRegValueHkcu(@"Software\Classes\.jpeg", null, "PhotoViewer.FileAssoc.Tiff", RegistryValueKind.String);
                SetRegValueHkcu(@"Software\Classes\.jpg", null, "PhotoViewer.FileAssoc.Tiff", RegistryValueKind.String);
                _OutPut("Set Default PhotoViewer");
            }
            Progressbaradd(10); //70
            if (checkBoxSPYTasks.Checked)
            {
                DisableSpyingTasks();
            }
            Progressbaradd(5); //75
            if (checkBoxDisableServices.Checked)
            {   //Direct Registry modifications threw a .reg file will not be applied to the section of the registry that sets the start type of services
                // Not sure if you can touch that area of the registry threw an Admin rights Console Command or not. 

                    //DPS
                RunCmd("/c net stop DPS ");
                _OutPut("Stopping Diagnostic Protocol Serivice.");
                RunCmd("/c sc config DPS start = disabled");
                _OutPut("Disabling Diagnostic Protocol Serivice.");
                    //TrkWks
                RunCmd("/c net stop TrkWks ");
                _OutPut("Stopping Distributed link Tracking Client Service.");
                RunCmd("/c sc config TrkWks start = disabled");
                _OutPut("Disabling Distributed link Tracking Client Service.");
                    //Disable Remote Registry
                RunCmd("/c net stop RemoteRegistry ");
                _OutPut("Stopping Remote Registry Service.");
                RunCmd("/c sc config RemoteRegistry start = disabled");
                _OutPut("Disabling Remote Registry Service.");
            }
            Progressbaradd(10); //85
            if (checkBoxDeleteWindows10Apps.Checked)
            {
                RemoveWindows10Apps();
            }
            Progressbaradd(15); //100
            EnableOrDisableTab(true);
            try
            {
                Invoke(new MethodInvoker(delegate
                {
                    SetCompleteText();
                }));
            }
            catch (Exception)
            {
                try
                {
                    SetCompleteText();
                }
                catch (Exception ex)
                {
                    if (_debug) _OutPut(ex.Message, LogLevel.Debug);
                }
            }
        }
        private void SetCompleteText(bool start = false)
        {
            if (start)
            {
                StatusCommandsLable.Text = @"Destroy Windows 10 Spying";
                StatusCommandsLable.ForeColor = Color.Black;
            }
            else
            {
                if (_fatalErrors == 0)
                {
                    StatusCommandsLable.Text = string.Format("Destroy Windows 10 Spying - {0}!", GetTranslateText("Complete"));
                    StatusCommandsLable.ForeColor = Color.DarkGreen;
                    if (
                        MessageBox.Show(GetTranslateText("CompleteMSG"), GetTranslateText("Info"),
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                    {
                        Process.Start("shutdown.exe", "-r -t 0");
                        Process.GetCurrentProcess().Kill();
                    }
                }
                else
                {
                    StatusCommandsLable.Text = string.Format("Destroy Windows 10 Spying - errors: {0}", _fatalErrors);
                    StatusCommandsLable.ForeColor = Color.Red;
                    if (
                        MessageBox.Show(string.Format(GetTranslateText("ErrorMSG"), _fatalErrors), GetTranslateText("Info"),
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                        DialogResult.Yes)
                    {
                        Process.Start("shutdown.exe", "-r -t 0");
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }
        }
        void DisableSpyingTasks()
        {


            string[] disabletaskslist =
                {
                    @"Microsoft\Office\Office ClickToRun Service Monitor",
                    @"Microsoft\Office\OfficeTelemetryAgentFallBack2016",
                    @"Microsoft\Office\OfficeTelemetryAgentLogOn2016",
                    @"Microsoft\Windows\Customer Experience Improvement Program\KernelCeipTask",
                    @"Microsoft\Windows\Customer Experience Improvement Program\UsbCeip",
                    @"Microsoft\Windows\Power Efficiency Diagnostics\AnalyzeSystem",
                    @"Microsoft\Windows\Shell\FamilySafetyMonitor",
                    @"Microsoft\Windows\Shell\FamilySafetyRefresh",
                    @"Microsoft\Windows\Application Experience\AitAgent",
                    @"Microsoft\Windows\Application Experience\ProgramDataUpdater",
                    @"Microsoft\Windows\Application Experience\StartupAppTask",
                    @"Microsoft\Windows\Autochk\Proxy",
                    @"Microsoft\Windows\Customer Experience Improvement Program\BthSQM",
                    @"Microsoft\Windows\Customer Experience Improvement Program\Consolidator",
                    @"Microsoft\Office\OfficeTelemetry\AgentFallBack2016",
                    @"Microsoft\Office\OfficeTelemetry\OfficeTelemetryAgentLogOn2016",
                    @"Microsoft\Windows\Application Experience\Microsoft Compatibility Appraiser",
                    @"Microsoft\Windows\DiskDiagnostic\Microsoft-Windows-DiskDiagnosticDataCollector",
                    @"Microsoft\Windows\Maintenance\WinSAT",
                    @"Microsoft\Windows\Media Center\ActivateWindowsSearch",
                    @"Microsoft\Windows\Media Center\ConfigureInternetTimeService",
                    @"Microsoft\Windows\Media Center\DispatchRecoveryTasks",
                    @"Microsoft\Windows\Media Center\ehDRMInit",
                    @"Microsoft\Windows\Media Center\InstallPlayReady",
                    @"Microsoft\Windows\Media Center\mcupdate",
                    @"Microsoft\Windows\Media Center\MediaCenterRecoveryTask",
                    @"Microsoft\Windows\Media Center\ObjectStoreRecoveryTask",
                    @"Microsoft\Windows\Media Center\OCURActivate",
                    @"Microsoft\Windows\Media Center\OCURDiscovery",
                    @"Microsoft\Windows\Media Center\PBDADiscovery",
                    @"Microsoft\Windows\Media Center\PBDADiscoveryW1",
                    @"Microsoft\Windows\Media Center\PBDADiscoveryW2",
                    @"Microsoft\Windows\Media Center\PvrRecoveryTask",
                    @"Microsoft\Windows\Media Center\PvrScheduleTask",
                    @"Microsoft\Windows\Media Center\RegisterSearch",
                    @"Microsoft\Windows\Media Center\ReindexSearchRoot",
                    @"Microsoft\Windows\Media Center\SqlLiteRecoveryTask",
                    @"Microsoft\Windows\Media Center\UpdateRecordPath"
                };
            for (int i = 0; i < disabletaskslist.Length; i++)
            {
                ProcStartargs("SCHTASKS", "/Change /TN \"" + disabletaskslist[i] + "\" /disable");
                _OutPut("Disabled task: " + disabletaskslist[i]);
            }
        }
        void AddToHostsAndFirewall()
        {
            try
            {
                string[] hostsdomains =
                {
                    "vortex.data.microsoft.com",
                    "vortex-win.data.microsoft.com",
                    "telecommand.telemetry.microsoft.com",
                    "telecommand.telemetry.microsoft.com.nsatc.net",
                    "oca.telemetry.microsoft.com",
                    "sqm.telemetry.microsoft.com",
                    "sqm.telemetry.microsoft.com.nsatc.net",
                    "watson.telemetry.microsoft.com",
                    "watson.telemetry.microsoft.com.nsatc.net",
                    "redir.metaservices.microsoft.com",
                    "choice.microsoft.com",
                    "choice.microsoft.com.nsatc.net",
                    "wes.df.telemetry.microsoft.com",
                    "services.wes.df.telemetry.microsoft.com",
                    "sqm.df.telemetry.microsoft.com",
                    "telemetry.microsoft.com",
                    "watson.ppe.telemetry.microsoft.com",
                    "telemetry.appex.bing.net",
                    "telemetry.urs.microsoft.com",
                    "telemetry.appex.bing.net:443",
                    "settings-sandbox.data.microsoft.com",
                    "survey.watson.microsoft.com",
                    "watson.live.com",
                    "watson.microsoft.com",
                    "statsfe2.ws.microsoft.com",
                    "corpext.msitadfs.glbdns2.microsoft.com",
                    "compatexchange.cloudapp.net",
                    "a-0001.a-msedge.net",
                    "statsfe2.update.microsoft.com.akadns.net",
                    "sls.update.microsoft.com.akadns.net",
                    "fe2.update.microsoft.com.akadns.net",
                    "diagnostics.support.microsoft.com",
                    "corp.sts.microsoft.com",
                    "statsfe1.ws.microsoft.com",
                    "feedback.windows.com",
                    "feedback.microsoft-hohm.com",
                    "feedback.search.microsoft.com",
                    "rad.msn.com",
                    "preview.msn.com",
                    "ad.doubleclick.net",
                    "ads.msn.com",
                    "ads1.msads.net",
                    "ads1.msn.com",
                    "a.ads1.msn.com",
                    "a.ads2.msn.com",
                    "adnexus.net",
                    "adnxs.com",
                    "az361816.vo.msecnd.net",
                    "az512334.vo.msecnd.net",
                    "ssw.live.com",
                    "ca.telemetry.microsoft.com",
                    "i1.services.social.microsoft.com",
                    "i1.services.social.microsoft.com.nsatc.net",
                    "df.telemetry.microsoft.com",
                    "reports.wes.df.telemetry.microsoft.com",
                    "cs1.wpc.v0cdn.net",
                    "vortex-sandbox.data.microsoft.com",
                    "oca.telemetry.microsoft.com.nsatc.net",
                    "pre.footprintpredict.com",
                    "spynet2.microsoft.com",
                    "spynetalt.microsoft.com",
                    "fe3.delivery.dsp.mp.microsoft.com.nsatc.net"
                };
                string hostslocation = _system32Location + @"drivers\etc\hosts";
                string hosts = null;
                if (File.Exists(hostslocation))
                {
                    hosts = File.ReadAllText(hostslocation);
                    File.SetAttributes(hostslocation, FileAttributes.Normal);
                    DeleteFile(hostslocation);
                }
                File.Create(hostslocation).Close();
                File.WriteAllText(hostslocation, hosts + Environment.NewLine);
                for (int i = 0; i < hostsdomains.Length; i++)
                {
                    if (hosts != null && hosts.IndexOf(hostsdomains[i], StringComparison.Ordinal) == -1)
                    {
                        ProcStartargs(_shellCmdLocation,
                            "/c echo " + "0.0.0.0 " + hostsdomains[i] + " >> \"" + hostslocation +
                            "\"");
                        _OutPut("Add to hosts - " + hostsdomains[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                _fatalErrors++;
                _OutPut("Error add HOSTS", LogLevel.Error);
                if (_debug) _OutPut(ex.Message, LogLevel.Debug);
            }
            RunCmd("/c ipconfig /flushdns");

            _OutPut("Add hosts MS complete.");
            BlockIpAddr();
        }
        private void RemoveWindows10Apps()
        {
            if (checkBoxDeleteApp3d.Checked)
            {
                DeleteWindows10MetroApp("3d");
                _OutPut("Delete builder 3D");
            }
            if (checkBoxDeleteAppCamera.Checked)
            {
                DeleteWindows10MetroApp("camera");
                _OutPut("Delete Camera");
            }
            if (checkBoxDeleteMailCalendarMaps.Checked)
            {
                DeleteWindows10MetroApp("communi");
                DeleteWindows10MetroApp("maps");
                _OutPut("Delete Mail, Calendar, Maps");
            }
            if (checkBoxDeleteAppBing.Checked)
            {
                DeleteWindows10MetroApp("bing");
                _OutPut("Delete Money, Sports, News and Weather");
            }
            if (checkBoxDeleteAppZune.Checked)
            {
                DeleteWindows10MetroApp("zune");
                _OutPut("Delete Groove Music and Film TV");
            }
            if (checkBoxDeleteAppPeopleOneNote.Checked)
            {
                DeleteWindows10MetroApp("people");
                DeleteWindows10MetroApp("note");
                _OutPut("Delete People and OneNote");
            }
            if (checkBoxDeleteAppPhone.Checked)
            {
                DeleteWindows10MetroApp("phone");
                _OutPut("Delete Phone Companion");
            }
            if (checkBoxDeleteAppPhotos.Checked)
            {
                DeleteWindows10MetroApp("photo");
                _OutPut("Delete Photos");
            }
            if (checkBoxDeleteAppSolit.Checked)
            {
                DeleteWindows10MetroApp("solit");
                _OutPut("Delete Solitaire Collection");
            }
            if (checkBoxDeleteAppVoice.Checked)
            {
                DeleteWindows10MetroApp("soundrec");
                _OutPut("Delete Voice Recorder");
            }
            if (checkBoxDeleteAppXBOX.Checked)
            {
                DeleteWindows10MetroApp("xbox");
                _OutPut("Delete XBOX");
            }

        }
        private void checkBoxDeleteWindows10Apps_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxDeleteApp3d.Enabled = checkBoxDeleteWindows10Apps.Checked;
            checkBoxDeleteAppBing.Enabled = checkBoxDeleteWindows10Apps.Checked;
            checkBoxDeleteAppCamera.Enabled = checkBoxDeleteWindows10Apps.Checked;
            checkBoxDeleteAppPeopleOneNote.Enabled = checkBoxDeleteWindows10Apps.Checked;
            checkBoxDeleteAppPhone.Enabled = checkBoxDeleteWindows10Apps.Checked;
            checkBoxDeleteAppPhotos.Enabled = checkBoxDeleteWindows10Apps.Checked;
            checkBoxDeleteAppSolit.Enabled = checkBoxDeleteWindows10Apps.Checked;
            checkBoxDeleteAppVoice.Enabled = checkBoxDeleteWindows10Apps.Checked;
            checkBoxDeleteAppXBOX.Enabled = checkBoxDeleteWindows10Apps.Checked;
            checkBoxDeleteAppZune.Enabled = checkBoxDeleteWindows10Apps.Checked;
            checkBoxDeleteMailCalendarMaps.Enabled = checkBoxDeleteWindows10Apps.Checked;
        }
        private void btnDeleteAllWindows10Apps_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(GetTranslateText("Really"), GetTranslateText("Question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                EnableOrDisableTab(false);
                MessageBox.Show(GetTranslateText("PressOkAndWait15"));
                new Thread(() =>
                {
                    DeleteWindows10MetroApp(null);
                    Invoke(new MethodInvoker(delegate
                    {
                        EnableOrDisableTab(true);
                        MessageBox.Show(GetTranslateText("Complete"), GetTranslateText("Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }).Start();
            }
            else
            {
                MessageBox.Show(@"=(", @"%(");
            }
        }
        private void btnRestoreSystem_Click(object sender, EventArgs e)
        {
            Process.Start(_system32Location + "rstrui.exe");
        }
        private void btnEnableUac_Click(object sender, EventArgs e)
        {
            SetRegValueHklm(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System\", "EnableLUA", "1",
                RegistryValueKind.DWord);
            _OutPut("Enable UAC");
            CheckEnableOrDisableUac();
            if (
                MessageBox.Show(GetTranslateText("CompleteMSG"), GetTranslateText("Info"), MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start("shutdown.exe", "-r -t 0");
            }
        }
        private void btnDisableUac_Click(object sender, EventArgs e)
        {
            SetRegValueHklm(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System\", "EnableLUA", "0",
                RegistryValueKind.DWord);
            _OutPut("Disable UAC");
            CheckEnableOrDisableUac();
            if (
                MessageBox.Show(GetTranslateText("CompleteMSG"), GetTranslateText("Info"), MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start("shutdown.exe", "-r -t 0");
            }
        }
        private void btnEnableWindowsUpdate_Click(object sender, EventArgs e)
        {
            ProcStartargs("powershell", "-command \"Set-Service -Name wuauserv -StartupType Automatic\"");
            RunCmd("/c net start wuauserv");
            RunCmd("/c netsh advfirewall firewall delete rule name=\"WindowsUpdateBlock\"");
            _OutPut("Windows Update enabled");
        }
        private void btnDisableWindowsUpdate_Click(object sender, EventArgs e)
        {
            RunCmd("/c net stop wuauserv");
            ProcStartargs("powershell", "-command \"Set-Service -Name wuauserv -StartupType Disabled\"");
            RunCmd("/c netsh advfirewall firewall delete rule name=\"WindowsUpdateBlock\"");
            RunCmd("/c netsh advfirewall firewall add rule name=\"WindowsUpdateBlock\" dir=out interface=any action=block service=wuauserv");
            _OutPut("Windows Update disabled");
        }
        private void btnOpenAndEditHosts_Click(object sender, EventArgs e)
        {
            ProcStartargs("notepad", _system32Location + @"drivers\etc\hosts");
        }
        private void DestroyWindowsSpyingMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        private void DestroyWindowsSpyingMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://goo.gl/EpFSzj");
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://goo.gl/fxEkcl");
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://goo.gl/CDaZye");
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://goo.gl/Xb9sy7");
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://goo.gl/sZIfQD");
        }
        private void btnProfessionalMode_Click(object sender, EventArgs e)
        {
            ProfessionalModeSet(btnProfessionalMode.Checked);
            Text = btnProfessionalMode.Checked
                ? string.Format("{0}  !Professional mode!", Text)
                : Text.Replace("  !Professional mode!", String.Empty);
        }
        private void ProfessionalModeSet(bool enableordisable)
        {
            checkBoxKeyLoggerAndTelemetry.Enabled = enableordisable;
            checkBoxAddToHosts.Enabled = enableordisable;
            checkBoxDisablePrivateSettings.Enabled = enableordisable;
            checkBoxDisableWindowsDefender.Enabled = enableordisable;
            checkBoxSetDefaultPhoto.Enabled = enableordisable;
            checkBoxSPYTasks.Enabled = enableordisable;
            btnDeleteAllWindows10Apps.Enabled = enableordisable;
            groupBoxUACEdit.Enabled = enableordisable;
            btnDeleteMetroAppsInfo.Enabled = enableordisable;
            btnDeleteOneDrive.Enabled = enableordisable;
            if (WindowsUtil.SystemRestore_Status() == 0)
            {
                checkBoxCreateSystemRestorePoint.Checked = false;
                checkBoxCreateSystemRestorePoint.Enabled = false;
            }
            else
            {
                checkBoxCreateSystemRestorePoint.Enabled = enableordisable;
            }
        }
        private void linkLabelOtherThanks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"Чёрная поганка, Архангел, Yele, TRoskop, artemiy , moldabekovm", @"Thanks");
        }
        private void btnDeleteMetroAppsInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Delete apps: Calculator, Windows Store, Windows Feedback, and other METRO apps.", @"Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnDeleteOneDrive_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                EnableOrDisableTab(false);
                try
                {
                    RunCmd("/c taskkill /f /im OneDrive.exe > NUL 2>&1");
                    RunCmd("/c ping 127.0.0.1 -n 5 > NUL 2>&1");
                    if (File.Exists(_systemPath + @"Windows\System32\OneDriveSetup.exe"))
                        ProcStartargs(_systemPath + @"Windows\System32\OneDriveSetup.exe", "/uninstall");
                    if (File.Exists(_systemPath + @"Windows\SysWOW64\OneDriveSetup.exe"))
                        ProcStartargs(_systemPath + @"Windows\SysWOW64\OneDriveSetup.exe", "/uninstall");
                    RunCmd("/c ping 127.0.0.1 -n 5 > NUL 2>&1");
                    RunCmd("/c rd \"%USERPROFILE%\\OneDrive\" /Q /S > NUL 2>&1");
                    RunCmd("/c rd \"C:\\OneDriveTemp\" /Q /S > NUL 2>&1");
                    RunCmd("/c rd \"%LOCALAPPDATA%\\Microsoft\\OneDrive\" /Q /S > NUL 2>&1");
                    RunCmd("/c rd \"%PROGRAMDATA%\\Microsoft OneDrive\" /Q /S > NUL 2>&1");
                    ProcStartargs(_shellCmdLocation,
                        "/c REG DELETE \"HKEY_CLASSES_ROOT\\CLSID\\{018D5C66-4533-4307-9B53-224DE2ED1FE6}\" /f > NUL 2>&1");
                    ProcStartargs(_shellCmdLocation,
                        "/c REG DELETE \"HKEY_CLASSES_ROOT\\Wow6432Node\\CLSID\\{018D5C66-4533-4307-9B53-224DE2ED1FE6}\" /f > NUL 2>&1");
                }
                catch (Exception ex)
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        MessageBox.Show(ex.Message, GetTranslateText("Error"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }));
                    if (_debug) _OutPut(ex.Message, LogLevel.Debug);
                }
                Invoke(new MethodInvoker(delegate
                {
                    MessageBox.Show(GetTranslateText("Complete"), GetTranslateText("Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
                EnableOrDisableTab(true);
            }).Start();
        }
        private void linkLabelSourceCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Nummer/Destroy-Windows-10-Spying");
        }
        private void btnRemoveOldFirewallRules_Click(object sender, EventArgs e)
        {
            string[] rulename =
            {
                "MS Spynet block 1",
                "MS Spynet block 2",
                "MS telemetry block 1",
                "MS telemetry block 2",
                "185.13.160.61_Block",
                "184.86.56.12_Block"
            };
            foreach (var hostname in rulename)
            {
                RunCmd("/c netsh advfirewall firewall delete rule name=\"" + hostname + "\"");
            }

            MessageBox.Show(GetTranslateText("Complete"), GetTranslateText("Info"));
        }
        private void btnReportABug_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Nummer/Destroy-Windows-10-Spying/issues/new");
        }

        private void comboBoxLanguageSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLanguageSelect.Text.Split('|')[0].Replace(" ", "") == "ru-RU")
            {
                _rm = ru_RU.ResourceManager;
                ChangeLanguage();
            }
            else if (comboBoxLanguageSelect.Text.Split('|')[0].Replace(" ", "") == "fr-FR")
            {
                _rm = fr_FR.ResourceManager;
                ChangeLanguage();
            }
            else if (comboBoxLanguageSelect.Text.Split('|')[0].Replace(" ", "") == "es-ES")
            {
                _rm = es_ES.ResourceManager;
                ChangeLanguage();
            }
            else if (comboBoxLanguageSelect.Text.Split('|')[0].Replace(" ", "") == "pt-BR")
            {
                _rm = pt_BR.ResourceManager;
                ChangeLanguage();
            }
            else if (comboBoxLanguageSelect.Text.Split('|')[0].Replace(" ", "") == "de-DE")
            {
                _rm = de_DE.ResourceManager;
                ChangeLanguage();
            }
            else if (comboBoxLanguageSelect.Text.Split('|')[0].Replace(" ", "") == "pl-PL")
            {
                _rm = pl_PL.ResourceManager;
                ChangeLanguage();
            }
            else if (comboBoxLanguageSelect.Text.Split('|')[0].Replace(" ", "") == "it-CH")
            {
                _rm = it_CH.ResourceManager;
                ChangeLanguage();
            }
            else if (comboBoxLanguageSelect.Text.Split('|')[0].Replace(" ", "") == "cs-CZ")
            {
                _rm = cs_CZ.ResourceManager;
                ChangeLanguage();
            }
            else if (comboBoxLanguageSelect.Text.Split('|')[0].Replace(" ", "") == "zh-CN")
            {
                _rm = zh_CN.ResourceManager;
                ChangeLanguage();
            }
            else
            {
                _rm = en_US.ResourceManager;
                ChangeLanguage();
            }
        }

        private void btnDestroyWindows78Spy_Click(object sender, EventArgs e)
        {
            btnDestroyWindows78Spy.Enabled = false;
            _fatalErrors = 0;
            new Thread(() =>
            {
                AddToHostsAndFirewall();
                DisableSpyingTasks();
                DeleteUpdatesWin78();
                RunCmd("/c REG ADD HKLM\\SYSTEM\\CurrentControlSet\\Control\\WMI\\AutoLogger\\AutoLogger-Diagtrack-Listener /v Start /t REG_DWORD /d 0 /f");
                Invoke(new MethodInvoker(delegate
                {
                    btnDestroyWindows78Spy.Enabled = true;
                    MessageBox.Show(GetTranslateText("Complete"), GetTranslateText("Info"), MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }));
            }).Start();
        }
        void DeleteUpdatesWin78()
        {
            string[] updatesnumberlist =
            {
                    "3080149",
                    "3075249",
                    "3068708",
                    "3044374",
                    "3035583",
                    "3022345",
                    "3021917",
                    "3015249",
                    "3012973",
                    "2990214",
                    "2977759",
                    "2976978",
                    "2952664",
                    "2922324",
                    "971033"
            };
            for (int i = 0; i < updatesnumberlist.Length; i++)
            {
                RunCmd("/c start /wait wusa /uninstall /norestart /quiet /kb:" + updatesnumberlist[i]);
                _OutPut("Remove update KB" + updatesnumberlist[i]);
            }
        }
        void BlockIpAddr()
        {
            string[] ipAddr =
            {
                "111.221.29.177",
                "111.221.29.253",
                "131.253.40.37",
                "134.170.30.202",
                "134.170.115.60",
                "134.170.165.248",
                "134.170.165.253",
                "134.170.185.70",
                "137.116.81.24",
                "137.117.235.16",
                "157.55.129.21",
                "157.55.133.204",
                "157.56.121.89",
                "157.56.91.77",
                "168.63.108.233",
                "191.232.139.254",
                "191.232.80.58",
                "191.232.80.62",
                "191.237.208.126",
                "204.79.197.200",
                "207.46.101.29",
                "207.46.114.58",
                "207.46.223.94",
                "207.68.166.254",
                "212.30.134.204",
                "212.30.134.205",
                "23.102.21.4",
                "23.99.10.11",
                "23.218.212.69",
                "64.4.54.22",
                "64.4.54.32",
                "64.4.6.100",
                "65.39.117.230",
                "65.52.100.11",
                "65.52.100.7",
                "65.52.100.9",
                "65.52.100.91",
                "65.52.100.92",
                "65.52.100.93",
                "65.52.100.94",
                "65.52.108.29",
                "65.55.108.23",
                "65.55.138.114",
                "65.55.138.126",
                "65.55.138.186",
                "65.55.252.63",
                "65.55.252.71",
                "65.55.252.92",
                "65.55.252.93",
                "65.55.29.238",
                "65.55.39.10",
                "191.232.139.2",
                "64.4.23.0-64.4.23.255",
                "111.221.64.0-111.221.127.255", // singapure
                "157.55.235.0-157.55.235.255",
                "157.55.56.0-157.55.56.255",
                "157.55.52.0-157.55.52.255",
                "157.55.130.0-157.55.130.255",
                "65.55.223.0-65.55.223.255",
                "213.199.179.0-213.199.179.255", // Ireland
                "195.138.255.0-195.138.255.255"

            };
            for (int i = 0; i < ipAddr.Length; i++)
            {
                RunCmd("/c route -p ADD " + ipAddr[i] + " MASK 255.255.255.255 0.0.0.0");
                RunCmd("/c netsh advfirewall firewall delete rule name=\"" + ipAddr[i] + "_Block\"");
                RunCmd("/c netsh advfirewall firewall add rule name=\"" + ipAddr[i] + "_Block\" dir=out interface=any action=block remoteip=" + ipAddr[i]);
                _OutPut("Add Windows Firewall rule: \"" + ipAddr[i] + "_Block\"");
            }
            RunCmd("/c netsh advfirewall firewall delete rule name=\"WSearch_Block\"");
            RunCmd("/c netsh advfirewall firewall add rule name=\"WSearch_Block\" dir=out interface=any action=block service=WSearch");
            _OutPut("Add Windows Firewall rule: \"WSearch_Block\"");
            _OutPut("Ip list blocked");
        }
        private void linkLabelLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.apache.org/licenses/LICENSE-2.0");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://dws.wzor.net/");
        }

        private void btnDisableOfficeUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
@"Office 2016 may stop working after these actions.
Are you sure?", @"Warning", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            try
            {
                var windowsIdentityUser = WindowsIdentity.GetCurrent();
                if (windowsIdentityUser != null)
                {
                    string userName = windowsIdentityUser.Name.Split('\\')[1];
                    MessageBox.Show(GetTranslateText("FindOffice16FileT"), GetTranslateText("Info"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OpenFileDialog opnFileDialog = new OpenFileDialog();
                    opnFileDialog.InitialDirectory = @"C:\Program Files\Microsoft Office\root\Office16\";
                    opnFileDialog.Filter = @"msosync.exe|msosync.exe";
                    string officePath = @"C:\Program Files\Microsoft Office\root\Office16\msosync.exe";
                    if (opnFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(opnFileDialog.FileName))
                        {
                            officePath = opnFileDialog.FileName;
                        }
                    }

                    RunCmd("/c TASKKILL /F /IM msosync.exe");
                    RunCmd(String.Format("/c takeown /f \"{0}\" /d y", officePath));
                    RunCmd(String.Format("/c icacls \"{0}\" /grant {1}:F /q", officePath, userName));
                    byte[] fileOffice = File.ReadAllBytes(officePath);
                    fileOffice = StringToByteArray(ByteArrayToString(fileOffice).Replace("68747470", "78747470"));
                    File.WriteAllBytes(officePath, fileOffice);
                    _OutPut("Complete",LogLevel.Info);
                }
            }
            catch (Exception ex)
            {
                _OutPut(ex.Message, LogLevel.Error);
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }

        private void CaptionWindow_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void CaptionWindow_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.BackColor = Color.Gainsboro;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.BackColor = Color.White;
        }

        private void MinimizeButton_MouseEnter(object sender, EventArgs e)
        {
            MinimizeButton.BackColor = Color.Gainsboro;
        }

        private void MinimizeButton_MouseLeave(object sender, EventArgs e)
        {
            MinimizeButton.BackColor = Color.White;
        }

        void ChangeBorderColor(Color cl)
        {
            try
            {
                Invoke(new MethodInvoker(delegate
                {
                    BorderDown.BackColor = cl;
                    BorderLeft.BackColor = cl;
                    BorderR.BackColor = cl;
                    BorderUP.BackColor = cl;
                }));
            }
            catch (Exception ex)
            {
                
            }
        }

        public static Color Rainbow(float progress)
        {
            float div = (Math.Abs(progress % 1) * 6);
            int ascending = (int)((div % 1) * 255);
            int descending = 255 - ascending;

            switch ((int)div)
            {
                case 0:
                    return Color.FromArgb(255, 255, ascending, 0);
                case 1:
                    return Color.FromArgb(255, descending, 255, 0);
                case 2:
                    return Color.FromArgb(255, 0, 255, ascending);
                case 3:
                    return Color.FromArgb(255, 0, descending, 255);
                case 4:
                    return Color.FromArgb(255, ascending, 0, 255);
                default: // case 5:
                    return Color.FromArgb(255, 255, 0, descending);
            }
        }

    }
}
