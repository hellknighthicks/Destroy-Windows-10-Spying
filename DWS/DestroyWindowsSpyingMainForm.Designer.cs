using System.ComponentModel;
using System.Windows.Forms;

namespace DWS_Lite
{
    partial class DestroyWindowsSpyingMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DestroyWindowsSpyingMainForm));
            this.CaptionWindow = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.MinimizeButton = new System.Windows.Forms.PictureBox();
            this.BorderUP = new System.Windows.Forms.PictureBox();
            this.BorderDown = new System.Windows.Forms.PictureBox();
            this.BorderLeft = new System.Windows.Forms.PictureBox();
            this.BorderR = new System.Windows.Forms.PictureBox();
            this.tabPageLicense = new System.Windows.Forms.TabPage();
            this.linkLabelLicense = new System.Windows.Forms.LinkLabel();
            this.labelLicense = new System.Windows.Forms.Label();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.About_Info = new System.Windows.Forms.Label();
            this.labelBuildDataTime = new System.Windows.Forms.Label();
            this.tabPageUtilites = new System.Windows.Forms.TabPage();
            this.btnDisableOfficeUpdate = new System.Windows.Forms.Button();
            this.btnRemoveOldFirewallRules = new System.Windows.Forms.Button();
            this.btnDeleteOneDrive = new System.Windows.Forms.Button();
            this.btnDeleteMetroAppsInfo = new System.Windows.Forms.Button();
            this.groupBoxWindowsUpdate = new System.Windows.Forms.GroupBox();
            this.btnEnableWindowsUpdate = new System.Windows.Forms.Button();
            this.btnDisableWindowsUpdate = new System.Windows.Forms.Button();
            this.groupBoxUACEdit = new System.Windows.Forms.GroupBox();
            this.btnEnableUac = new System.Windows.Forms.Button();
            this.btnDisableUac = new System.Windows.Forms.Button();
            this.btnOpenAndEditHosts = new System.Windows.Forms.Button();
            this.btnRestoreSystem = new System.Windows.Forms.Button();
            this.btnDeleteAllWindows10Apps = new System.Windows.Forms.Button();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.checkBoxDisableServices = new System.Windows.Forms.CheckBox();
            this.btnProfessionalMode = new System.Windows.Forms.CheckBox();
            this.labelInfoDeleteMetroApps = new System.Windows.Forms.Label();
            this.checkBoxDeleteAppXBOX = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteAppVoice = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteAppSolit = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteAppPhotos = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteAppPhone = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteAppPeopleOneNote = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteAppZune = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteAppBing = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteMailCalendarMaps = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteAppCamera = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteApp3d = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteWindows10Apps = new System.Windows.Forms.CheckBox();
            this.checkBoxSPYTasks = new System.Windows.Forms.CheckBox();
            this.checkBoxSetDefaultPhoto = new System.Windows.Forms.CheckBox();
            this.checkBoxDisableWindowsDefender = new System.Windows.Forms.CheckBox();
            this.checkBoxDisablePrivateSettings = new System.Windows.Forms.CheckBox();
            this.checkBoxAddToHosts = new System.Windows.Forms.CheckBox();
            this.checkBoxKeyLoggerAndTelemetry = new System.Windows.Forms.CheckBox();
            this.checkBoxCreateSystemRestorePoint = new System.Windows.Forms.CheckBox();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.btnDestroyWindows10Spy = new System.Windows.Forms.Button();
            this.LogOutputTextBox = new System.Windows.Forms.RichTextBox();
            this.ProgressBarStatus = new System.Windows.Forms.ProgressBar();
            this.btnDestroyWindowsSpying = new System.Windows.Forms.Button();
            this.FormTabsControl = new System.Windows.Forms.TabControl();
            this.checkBoxP2PWinUpdate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderR)).BeginInit();
            this.tabPageLicense.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            this.tabPageUtilites.SuspendLayout();
            this.groupBoxWindowsUpdate.SuspendLayout();
            this.groupBoxUACEdit.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.FormTabsControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // CaptionWindow
            // 
            this.CaptionWindow.BackColor = System.Drawing.Color.DimGray;
            this.CaptionWindow.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.CaptionWindow.Dock = System.Windows.Forms.DockStyle.Top;
            this.CaptionWindow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CaptionWindow.ForeColor = System.Drawing.Color.SpringGreen;
            this.CaptionWindow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CaptionWindow.Location = new System.Drawing.Point(0, 0);
            this.CaptionWindow.Name = "CaptionWindow";
            this.CaptionWindow.Size = new System.Drawing.Size(453, 28);
            this.CaptionWindow.TabIndex = 1;
            this.CaptionWindow.Text = "Pro Silver Systems - DWS Lite";
            this.CaptionWindow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CaptionWindow.Click += new System.EventHandler(this.CaptionWindow_Click);
            this.CaptionWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CaptionWindow_MouseDown);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.White;
            this.CloseButton.BackgroundImage = global::DWS_Lite.Properties.Resources.close;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Location = new System.Drawing.Point(423, 7);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(18, 16);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.CloseButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackgroundImage = global::DWS_Lite.Properties.Resources.minimize;
            this.MinimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizeButton.Location = new System.Drawing.Point(399, 7);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(18, 16);
            this.MinimizeButton.TabIndex = 3;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            this.MinimizeButton.MouseEnter += new System.EventHandler(this.MinimizeButton_MouseEnter);
            this.MinimizeButton.MouseLeave += new System.EventHandler(this.MinimizeButton_MouseLeave);
            // 
            // BorderUP
            // 
            this.BorderUP.BackColor = System.Drawing.Color.Cyan;
            this.BorderUP.Location = new System.Drawing.Point(-7, 0);
            this.BorderUP.Name = "BorderUP";
            this.BorderUP.Size = new System.Drawing.Size(480, 1);
            this.BorderUP.TabIndex = 4;
            this.BorderUP.TabStop = false;
            // 
            // BorderDown
            // 
            this.BorderDown.BackColor = System.Drawing.Color.Cyan;
            this.BorderDown.Location = new System.Drawing.Point(-14, 456);
            this.BorderDown.Name = "BorderDown";
            this.BorderDown.Size = new System.Drawing.Size(480, 1);
            this.BorderDown.TabIndex = 5;
            this.BorderDown.TabStop = false;
            // 
            // BorderLeft
            // 
            this.BorderLeft.BackColor = System.Drawing.Color.Cyan;
            this.BorderLeft.Location = new System.Drawing.Point(0, -8);
            this.BorderLeft.Name = "BorderLeft";
            this.BorderLeft.Size = new System.Drawing.Size(1, 500);
            this.BorderLeft.TabIndex = 6;
            this.BorderLeft.TabStop = false;
            // 
            // BorderR
            // 
            this.BorderR.BackColor = System.Drawing.Color.Cyan;
            this.BorderR.Location = new System.Drawing.Point(452, -22);
            this.BorderR.Name = "BorderR";
            this.BorderR.Size = new System.Drawing.Size(1, 500);
            this.BorderR.TabIndex = 7;
            this.BorderR.TabStop = false;
            // 
            // tabPageLicense
            // 
            this.tabPageLicense.Controls.Add(this.linkLabelLicense);
            this.tabPageLicense.Controls.Add(this.labelLicense);
            this.tabPageLicense.Location = new System.Drawing.Point(4, 22);
            this.tabPageLicense.Name = "tabPageLicense";
            this.tabPageLicense.Size = new System.Drawing.Size(445, 454);
            this.tabPageLicense.TabIndex = 5;
            this.tabPageLicense.Text = "License";
            this.tabPageLicense.UseVisualStyleBackColor = true;
            // 
            // linkLabelLicense
            // 
            this.linkLabelLicense.AutoSize = true;
            this.linkLabelLicense.Location = new System.Drawing.Point(32, 64);
            this.linkLabelLicense.Name = "linkLabelLicense";
            this.linkLabelLicense.Size = new System.Drawing.Size(228, 13);
            this.linkLabelLicense.TabIndex = 1;
            this.linkLabelLicense.TabStop = true;
            this.linkLabelLicense.Text = "http://www.apache.org/licenses/LICENSE-2.0";
            this.linkLabelLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLicense_LinkClicked);
            // 
            // labelLicense
            // 
            this.labelLicense.AutoSize = true;
            this.labelLicense.Location = new System.Drawing.Point(8, 11);
            this.labelLicense.Name = "labelLicense";
            this.labelLicense.Size = new System.Drawing.Size(405, 143);
            this.labelLicense.TabIndex = 0;
            this.labelLicense.Text = resources.GetString("labelLicense.Text");
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.BackColor = System.Drawing.Color.White;
            this.tabPageAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageAbout.Controls.Add(this.About_Info);
            this.tabPageAbout.Controls.Add(this.labelBuildDataTime);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 22);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Size = new System.Drawing.Size(445, 454);
            this.tabPageAbout.TabIndex = 3;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.Click += new System.EventHandler(this.tabPageAbout_Click);
            // 
            // About_Info
            // 
            this.About_Info.BackColor = System.Drawing.Color.Transparent;
            this.About_Info.Font = new System.Drawing.Font("Consolas", 12F);
            this.About_Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.About_Info.Location = new System.Drawing.Point(6, 36);
            this.About_Info.Margin = new System.Windows.Forms.Padding(3);
            this.About_Info.Name = "About_Info";
            this.About_Info.Size = new System.Drawing.Size(439, 184);
            this.About_Info.TabIndex = 1;
            this.About_Info.Text = "Spin off Build HellKnightHicks\r\n\r\nOrigitnally developed by Nummer \r\nSpecial Thank" +
    "s: @WZorNET , @MicrosoftInside ,\r\n@rgadguard, @DiamondMonday, @Ratiborus58";
            this.About_Info.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelBuildDataTime
            // 
            this.labelBuildDataTime.AutoSize = true;
            this.labelBuildDataTime.BackColor = System.Drawing.Color.Transparent;
            this.labelBuildDataTime.Location = new System.Drawing.Point(6, 315);
            this.labelBuildDataTime.Name = "labelBuildDataTime";
            this.labelBuildDataTime.Size = new System.Drawing.Size(32, 13);
            this.labelBuildDataTime.TabIndex = 0;
            this.labelBuildDataTime.Text = "Build ";
            // 
            // tabPageUtilites
            // 
            this.tabPageUtilites.BackColor = System.Drawing.Color.White;
            this.tabPageUtilites.BackgroundImage = global::DWS_Lite.Properties.Resources.BGProgImg;
            this.tabPageUtilites.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageUtilites.Controls.Add(this.btnDisableOfficeUpdate);
            this.tabPageUtilites.Controls.Add(this.btnRemoveOldFirewallRules);
            this.tabPageUtilites.Controls.Add(this.btnDeleteOneDrive);
            this.tabPageUtilites.Controls.Add(this.btnDeleteMetroAppsInfo);
            this.tabPageUtilites.Controls.Add(this.groupBoxWindowsUpdate);
            this.tabPageUtilites.Controls.Add(this.groupBoxUACEdit);
            this.tabPageUtilites.Controls.Add(this.btnOpenAndEditHosts);
            this.tabPageUtilites.Controls.Add(this.btnRestoreSystem);
            this.tabPageUtilites.Controls.Add(this.btnDeleteAllWindows10Apps);
            this.tabPageUtilites.Location = new System.Drawing.Point(4, 22);
            this.tabPageUtilites.Name = "tabPageUtilites";
            this.tabPageUtilites.Size = new System.Drawing.Size(445, 454);
            this.tabPageUtilites.TabIndex = 2;
            this.tabPageUtilites.Text = "Utilites";
            // 
            // btnDisableOfficeUpdate
            // 
            this.btnDisableOfficeUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnDisableOfficeUpdate.BackgroundImage = global::DWS_Lite.Properties.Resources.warning;
            this.btnDisableOfficeUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDisableOfficeUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisableOfficeUpdate.Location = new System.Drawing.Point(14, 147);
            this.btnDisableOfficeUpdate.Name = "btnDisableOfficeUpdate";
            this.btnDisableOfficeUpdate.Size = new System.Drawing.Size(202, 23);
            this.btnDisableOfficeUpdate.TabIndex = 6;
            this.btnDisableOfficeUpdate.Text = "Disable Office 2016 Telemetry";
            this.btnDisableOfficeUpdate.UseVisualStyleBackColor = false;
            this.btnDisableOfficeUpdate.Click += new System.EventHandler(this.btnDisableOfficeUpdate_Click);
            // 
            // btnRemoveOldFirewallRules
            // 
            this.btnRemoveOldFirewallRules.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveOldFirewallRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveOldFirewallRules.ForeColor = System.Drawing.Color.Green;
            this.btnRemoveOldFirewallRules.Location = new System.Drawing.Point(223, 147);
            this.btnRemoveOldFirewallRules.Name = "btnRemoveOldFirewallRules";
            this.btnRemoveOldFirewallRules.Size = new System.Drawing.Size(214, 23);
            this.btnRemoveOldFirewallRules.TabIndex = 6;
            this.btnRemoveOldFirewallRules.Text = "Remove all old DWS firewall rules";
            this.btnRemoveOldFirewallRules.UseVisualStyleBackColor = false;
            this.btnRemoveOldFirewallRules.Click += new System.EventHandler(this.btnRemoveOldFirewallRules_Click);
            // 
            // btnDeleteOneDrive
            // 
            this.btnDeleteOneDrive.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteOneDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOneDrive.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteOneDrive.Location = new System.Drawing.Point(223, 32);
            this.btnDeleteOneDrive.Name = "btnDeleteOneDrive";
            this.btnDeleteOneDrive.Size = new System.Drawing.Size(214, 23);
            this.btnDeleteOneDrive.TabIndex = 10;
            this.btnDeleteOneDrive.Text = "Delete One Drive";
            this.btnDeleteOneDrive.UseVisualStyleBackColor = false;
            this.btnDeleteOneDrive.Click += new System.EventHandler(this.btnDeleteOneDrive_Click);
            // 
            // btnDeleteMetroAppsInfo
            // 
            this.btnDeleteMetroAppsInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteMetroAppsInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteMetroAppsInfo.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteMetroAppsInfo.Location = new System.Drawing.Point(199, 32);
            this.btnDeleteMetroAppsInfo.Name = "btnDeleteMetroAppsInfo";
            this.btnDeleteMetroAppsInfo.Size = new System.Drawing.Size(23, 23);
            this.btnDeleteMetroAppsInfo.TabIndex = 9;
            this.btnDeleteMetroAppsInfo.Text = "?";
            this.btnDeleteMetroAppsInfo.UseVisualStyleBackColor = false;
            this.btnDeleteMetroAppsInfo.Click += new System.EventHandler(this.btnDeleteMetroAppsInfo_Click);
            // 
            // groupBoxWindowsUpdate
            // 
            this.groupBoxWindowsUpdate.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxWindowsUpdate.Controls.Add(this.btnEnableWindowsUpdate);
            this.groupBoxWindowsUpdate.Controls.Add(this.btnDisableWindowsUpdate);
            this.groupBoxWindowsUpdate.Location = new System.Drawing.Point(223, 61);
            this.groupBoxWindowsUpdate.Name = "groupBoxWindowsUpdate";
            this.groupBoxWindowsUpdate.Size = new System.Drawing.Size(214, 80);
            this.groupBoxWindowsUpdate.TabIndex = 8;
            this.groupBoxWindowsUpdate.TabStop = false;
            this.groupBoxWindowsUpdate.Text = "Windows Update";
            // 
            // btnEnableWindowsUpdate
            // 
            this.btnEnableWindowsUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnEnableWindowsUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnableWindowsUpdate.Location = new System.Drawing.Point(6, 20);
            this.btnEnableWindowsUpdate.Name = "btnEnableWindowsUpdate";
            this.btnEnableWindowsUpdate.Size = new System.Drawing.Size(202, 23);
            this.btnEnableWindowsUpdate.TabIndex = 4;
            this.btnEnableWindowsUpdate.Text = "Enable Windows Update";
            this.btnEnableWindowsUpdate.UseVisualStyleBackColor = false;
            this.btnEnableWindowsUpdate.Click += new System.EventHandler(this.btnEnableWindowsUpdate_Click);
            // 
            // btnDisableWindowsUpdate
            // 
            this.btnDisableWindowsUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnDisableWindowsUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisableWindowsUpdate.Location = new System.Drawing.Point(6, 49);
            this.btnDisableWindowsUpdate.Name = "btnDisableWindowsUpdate";
            this.btnDisableWindowsUpdate.Size = new System.Drawing.Size(202, 23);
            this.btnDisableWindowsUpdate.TabIndex = 5;
            this.btnDisableWindowsUpdate.Text = "Disable Windows Update";
            this.btnDisableWindowsUpdate.UseVisualStyleBackColor = false;
            this.btnDisableWindowsUpdate.Click += new System.EventHandler(this.btnDisableWindowsUpdate_Click);
            // 
            // groupBoxUACEdit
            // 
            this.groupBoxUACEdit.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxUACEdit.Controls.Add(this.btnEnableUac);
            this.groupBoxUACEdit.Controls.Add(this.btnDisableUac);
            this.groupBoxUACEdit.Location = new System.Drawing.Point(8, 61);
            this.groupBoxUACEdit.Name = "groupBoxUACEdit";
            this.groupBoxUACEdit.Size = new System.Drawing.Size(214, 80);
            this.groupBoxUACEdit.TabIndex = 7;
            this.groupBoxUACEdit.TabStop = false;
            this.groupBoxUACEdit.Text = "UAC";
            // 
            // btnEnableUac
            // 
            this.btnEnableUac.BackColor = System.Drawing.Color.Transparent;
            this.btnEnableUac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnableUac.Location = new System.Drawing.Point(6, 20);
            this.btnEnableUac.Name = "btnEnableUac";
            this.btnEnableUac.Size = new System.Drawing.Size(202, 23);
            this.btnEnableUac.TabIndex = 2;
            this.btnEnableUac.Text = "Enable UAC";
            this.btnEnableUac.UseVisualStyleBackColor = false;
            this.btnEnableUac.Click += new System.EventHandler(this.btnEnableUac_Click);
            // 
            // btnDisableUac
            // 
            this.btnDisableUac.BackColor = System.Drawing.Color.Transparent;
            this.btnDisableUac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisableUac.Location = new System.Drawing.Point(6, 49);
            this.btnDisableUac.Name = "btnDisableUac";
            this.btnDisableUac.Size = new System.Drawing.Size(202, 23);
            this.btnDisableUac.TabIndex = 3;
            this.btnDisableUac.Text = "Disable UAC";
            this.btnDisableUac.UseVisualStyleBackColor = false;
            this.btnDisableUac.Click += new System.EventHandler(this.btnDisableUac_Click);
            // 
            // btnOpenAndEditHosts
            // 
            this.btnOpenAndEditHosts.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenAndEditHosts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenAndEditHosts.Location = new System.Drawing.Point(8, 3);
            this.btnOpenAndEditHosts.Name = "btnOpenAndEditHosts";
            this.btnOpenAndEditHosts.Size = new System.Drawing.Size(214, 23);
            this.btnOpenAndEditHosts.TabIndex = 6;
            this.btnOpenAndEditHosts.Text = "Open and edit HOSTS file";
            this.btnOpenAndEditHosts.UseVisualStyleBackColor = false;
            this.btnOpenAndEditHosts.Click += new System.EventHandler(this.btnOpenAndEditHosts_Click);
            // 
            // btnRestoreSystem
            // 
            this.btnRestoreSystem.BackColor = System.Drawing.Color.Transparent;
            this.btnRestoreSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestoreSystem.Location = new System.Drawing.Point(223, 3);
            this.btnRestoreSystem.Name = "btnRestoreSystem";
            this.btnRestoreSystem.Size = new System.Drawing.Size(214, 23);
            this.btnRestoreSystem.TabIndex = 1;
            this.btnRestoreSystem.Text = "Restore System";
            this.btnRestoreSystem.UseVisualStyleBackColor = false;
            this.btnRestoreSystem.Click += new System.EventHandler(this.btnRestoreSystem_Click);
            // 
            // btnDeleteAllWindows10Apps
            // 
            this.btnDeleteAllWindows10Apps.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteAllWindows10Apps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAllWindows10Apps.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteAllWindows10Apps.Location = new System.Drawing.Point(8, 32);
            this.btnDeleteAllWindows10Apps.Name = "btnDeleteAllWindows10Apps";
            this.btnDeleteAllWindows10Apps.Size = new System.Drawing.Size(191, 23);
            this.btnDeleteAllWindows10Apps.TabIndex = 0;
            this.btnDeleteAllWindows10Apps.Text = "Delete all windows 10 metro apps";
            this.btnDeleteAllWindows10Apps.UseVisualStyleBackColor = false;
            this.btnDeleteAllWindows10Apps.Click += new System.EventHandler(this.btnDeleteAllWindows10Apps_Click);
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.BackColor = System.Drawing.Color.White;
            this.tabPageSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageSettings.Controls.Add(this.checkBoxP2PWinUpdate);
            this.tabPageSettings.Controls.Add(this.checkBoxDisableServices);
            this.tabPageSettings.Controls.Add(this.btnProfessionalMode);
            this.tabPageSettings.Controls.Add(this.labelInfoDeleteMetroApps);
            this.tabPageSettings.Controls.Add(this.checkBoxDeleteAppXBOX);
            this.tabPageSettings.Controls.Add(this.checkBoxDeleteAppVoice);
            this.tabPageSettings.Controls.Add(this.checkBoxDeleteAppSolit);
            this.tabPageSettings.Controls.Add(this.checkBoxDeleteAppPhotos);
            this.tabPageSettings.Controls.Add(this.checkBoxDeleteAppPhone);
            this.tabPageSettings.Controls.Add(this.checkBoxDeleteAppPeopleOneNote);
            this.tabPageSettings.Controls.Add(this.checkBoxDeleteAppZune);
            this.tabPageSettings.Controls.Add(this.checkBoxDeleteAppBing);
            this.tabPageSettings.Controls.Add(this.checkBoxDeleteMailCalendarMaps);
            this.tabPageSettings.Controls.Add(this.checkBoxDeleteAppCamera);
            this.tabPageSettings.Controls.Add(this.checkBoxDeleteApp3d);
            this.tabPageSettings.Controls.Add(this.checkBoxDeleteWindows10Apps);
            this.tabPageSettings.Controls.Add(this.checkBoxSPYTasks);
            this.tabPageSettings.Controls.Add(this.checkBoxSetDefaultPhoto);
            this.tabPageSettings.Controls.Add(this.checkBoxDisableWindowsDefender);
            this.tabPageSettings.Controls.Add(this.checkBoxDisablePrivateSettings);
            this.tabPageSettings.Controls.Add(this.checkBoxAddToHosts);
            this.tabPageSettings.Controls.Add(this.checkBoxKeyLoggerAndTelemetry);
            this.tabPageSettings.Controls.Add(this.checkBoxCreateSystemRestorePoint);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(445, 400);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            // 
            // checkBoxDisableServices
            // 
            this.checkBoxDisableServices.AutoSize = true;
            this.checkBoxDisableServices.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDisableServices.Checked = true;
            this.checkBoxDisableServices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisableServices.Location = new System.Drawing.Point(6, 125);
            this.checkBoxDisableServices.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDisableServices.Name = "checkBoxDisableServices";
            this.checkBoxDisableServices.Size = new System.Drawing.Size(160, 17);
            this.checkBoxDisableServices.TabIndex = 22;
            this.checkBoxDisableServices.Text = "Disable Un-Needed Services";
            this.checkBoxDisableServices.UseVisualStyleBackColor = false;
            // 
            // btnProfessionalMode
            // 
            this.btnProfessionalMode.AutoSize = true;
            this.btnProfessionalMode.ForeColor = System.Drawing.Color.Red;
            this.btnProfessionalMode.Location = new System.Drawing.Point(345, 3);
            this.btnProfessionalMode.Name = "btnProfessionalMode";
            this.btnProfessionalMode.Size = new System.Drawing.Size(105, 17);
            this.btnProfessionalMode.TabIndex = 21;
            this.btnProfessionalMode.Text = "Manually  Config";
            this.btnProfessionalMode.UseVisualStyleBackColor = true;
            this.btnProfessionalMode.CheckedChanged += new System.EventHandler(this.btnProfessionalMode_Click);
            // 
            // labelInfoDeleteMetroApps
            // 
            this.labelInfoDeleteMetroApps.AutoSize = true;
            this.labelInfoDeleteMetroApps.BackColor = System.Drawing.Color.Transparent;
            this.labelInfoDeleteMetroApps.ForeColor = System.Drawing.Color.Red;
            this.labelInfoDeleteMetroApps.Location = new System.Drawing.Point(3, 182);
            this.labelInfoDeleteMetroApps.Name = "labelInfoDeleteMetroApps";
            this.labelInfoDeleteMetroApps.Size = new System.Drawing.Size(273, 13);
            this.labelInfoDeleteMetroApps.TabIndex = 20;
            this.labelInfoDeleteMetroApps.Text = "If selected the Metro Apps will be deleted permanently.";
            // 
            // checkBoxDeleteAppXBOX
            // 
            this.checkBoxDeleteAppXBOX.AutoSize = true;
            this.checkBoxDeleteAppXBOX.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDeleteAppXBOX.Checked = true;
            this.checkBoxDeleteAppXBOX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteAppXBOX.Enabled = false;
            this.checkBoxDeleteAppXBOX.Location = new System.Drawing.Point(6, 382);
            this.checkBoxDeleteAppXBOX.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDeleteAppXBOX.Name = "checkBoxDeleteAppXBOX";
            this.checkBoxDeleteAppXBOX.Size = new System.Drawing.Size(84, 17);
            this.checkBoxDeleteAppXBOX.TabIndex = 18;
            this.checkBoxDeleteAppXBOX.Text = "Delete XBoX";
            this.checkBoxDeleteAppXBOX.UseVisualStyleBackColor = false;
            // 
            // checkBoxDeleteAppVoice
            // 
            this.checkBoxDeleteAppVoice.AutoSize = true;
            this.checkBoxDeleteAppVoice.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDeleteAppVoice.Checked = true;
            this.checkBoxDeleteAppVoice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteAppVoice.Enabled = false;
            this.checkBoxDeleteAppVoice.Location = new System.Drawing.Point(6, 365);
            this.checkBoxDeleteAppVoice.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDeleteAppVoice.Name = "checkBoxDeleteAppVoice";
            this.checkBoxDeleteAppVoice.Size = new System.Drawing.Size(132, 17);
            this.checkBoxDeleteAppVoice.TabIndex = 17;
            this.checkBoxDeleteAppVoice.Text = "Delete Voice Recorder";
            this.checkBoxDeleteAppVoice.UseVisualStyleBackColor = false;
            // 
            // checkBoxDeleteAppSolit
            // 
            this.checkBoxDeleteAppSolit.AutoSize = true;
            this.checkBoxDeleteAppSolit.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDeleteAppSolit.Checked = true;
            this.checkBoxDeleteAppSolit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteAppSolit.Enabled = false;
            this.checkBoxDeleteAppSolit.Location = new System.Drawing.Point(6, 348);
            this.checkBoxDeleteAppSolit.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDeleteAppSolit.Name = "checkBoxDeleteAppSolit";
            this.checkBoxDeleteAppSolit.Size = new System.Drawing.Size(147, 17);
            this.checkBoxDeleteAppSolit.TabIndex = 16;
            this.checkBoxDeleteAppSolit.Text = "Delete Solitaire Collection";
            this.checkBoxDeleteAppSolit.UseVisualStyleBackColor = false;
            // 
            // checkBoxDeleteAppPhotos
            // 
            this.checkBoxDeleteAppPhotos.AutoSize = true;
            this.checkBoxDeleteAppPhotos.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDeleteAppPhotos.Checked = true;
            this.checkBoxDeleteAppPhotos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteAppPhotos.Enabled = false;
            this.checkBoxDeleteAppPhotos.Location = new System.Drawing.Point(6, 331);
            this.checkBoxDeleteAppPhotos.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDeleteAppPhotos.Name = "checkBoxDeleteAppPhotos";
            this.checkBoxDeleteAppPhotos.Size = new System.Drawing.Size(93, 17);
            this.checkBoxDeleteAppPhotos.TabIndex = 15;
            this.checkBoxDeleteAppPhotos.Text = "Delete Photos";
            this.checkBoxDeleteAppPhotos.UseVisualStyleBackColor = false;
            // 
            // checkBoxDeleteAppPhone
            // 
            this.checkBoxDeleteAppPhone.AutoSize = true;
            this.checkBoxDeleteAppPhone.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDeleteAppPhone.Checked = true;
            this.checkBoxDeleteAppPhone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteAppPhone.Enabled = false;
            this.checkBoxDeleteAppPhone.Location = new System.Drawing.Point(6, 314);
            this.checkBoxDeleteAppPhone.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDeleteAppPhone.Name = "checkBoxDeleteAppPhone";
            this.checkBoxDeleteAppPhone.Size = new System.Drawing.Size(146, 17);
            this.checkBoxDeleteAppPhone.TabIndex = 14;
            this.checkBoxDeleteAppPhone.Text = "Delete Phone Companion";
            this.checkBoxDeleteAppPhone.UseVisualStyleBackColor = false;
            // 
            // checkBoxDeleteAppPeopleOneNote
            // 
            this.checkBoxDeleteAppPeopleOneNote.AutoSize = true;
            this.checkBoxDeleteAppPeopleOneNote.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDeleteAppPeopleOneNote.Checked = true;
            this.checkBoxDeleteAppPeopleOneNote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteAppPeopleOneNote.Enabled = false;
            this.checkBoxDeleteAppPeopleOneNote.Location = new System.Drawing.Point(6, 297);
            this.checkBoxDeleteAppPeopleOneNote.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDeleteAppPeopleOneNote.Name = "checkBoxDeleteAppPeopleOneNote";
            this.checkBoxDeleteAppPeopleOneNote.Size = new System.Drawing.Size(159, 17);
            this.checkBoxDeleteAppPeopleOneNote.TabIndex = 13;
            this.checkBoxDeleteAppPeopleOneNote.Text = "Delete People and OneNote";
            this.checkBoxDeleteAppPeopleOneNote.UseVisualStyleBackColor = false;
            // 
            // checkBoxDeleteAppZune
            // 
            this.checkBoxDeleteAppZune.AutoSize = true;
            this.checkBoxDeleteAppZune.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDeleteAppZune.Checked = true;
            this.checkBoxDeleteAppZune.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteAppZune.Enabled = false;
            this.checkBoxDeleteAppZune.Location = new System.Drawing.Point(6, 280);
            this.checkBoxDeleteAppZune.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDeleteAppZune.Name = "checkBoxDeleteAppZune";
            this.checkBoxDeleteAppZune.Size = new System.Drawing.Size(184, 17);
            this.checkBoxDeleteAppZune.TabIndex = 12;
            this.checkBoxDeleteAppZune.Text = "Delete Groove Music and Film TV ";
            this.checkBoxDeleteAppZune.UseVisualStyleBackColor = false;
            // 
            // checkBoxDeleteAppBing
            // 
            this.checkBoxDeleteAppBing.AutoSize = true;
            this.checkBoxDeleteAppBing.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDeleteAppBing.Checked = true;
            this.checkBoxDeleteAppBing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteAppBing.Enabled = false;
            this.checkBoxDeleteAppBing.Location = new System.Drawing.Point(6, 263);
            this.checkBoxDeleteAppBing.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDeleteAppBing.Name = "checkBoxDeleteAppBing";
            this.checkBoxDeleteAppBing.Size = new System.Drawing.Size(229, 17);
            this.checkBoxDeleteAppBing.TabIndex = 11;
            this.checkBoxDeleteAppBing.Text = "Delete Money, Sports, News and Weather";
            this.checkBoxDeleteAppBing.UseVisualStyleBackColor = false;
            // 
            // checkBoxDeleteMailCalendarMaps
            // 
            this.checkBoxDeleteMailCalendarMaps.AutoSize = true;
            this.checkBoxDeleteMailCalendarMaps.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDeleteMailCalendarMaps.Checked = true;
            this.checkBoxDeleteMailCalendarMaps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteMailCalendarMaps.Enabled = false;
            this.checkBoxDeleteMailCalendarMaps.Location = new System.Drawing.Point(6, 246);
            this.checkBoxDeleteMailCalendarMaps.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDeleteMailCalendarMaps.Name = "checkBoxDeleteMailCalendarMaps";
            this.checkBoxDeleteMailCalendarMaps.Size = new System.Drawing.Size(174, 17);
            this.checkBoxDeleteMailCalendarMaps.TabIndex = 10;
            this.checkBoxDeleteMailCalendarMaps.Text = "Delete Mail,Calendar and Maps";
            this.checkBoxDeleteMailCalendarMaps.UseVisualStyleBackColor = false;
            // 
            // checkBoxDeleteAppCamera
            // 
            this.checkBoxDeleteAppCamera.AutoSize = true;
            this.checkBoxDeleteAppCamera.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDeleteAppCamera.Checked = true;
            this.checkBoxDeleteAppCamera.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteAppCamera.Enabled = false;
            this.checkBoxDeleteAppCamera.Location = new System.Drawing.Point(6, 229);
            this.checkBoxDeleteAppCamera.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDeleteAppCamera.Name = "checkBoxDeleteAppCamera";
            this.checkBoxDeleteAppCamera.Size = new System.Drawing.Size(97, 17);
            this.checkBoxDeleteAppCamera.TabIndex = 9;
            this.checkBoxDeleteAppCamera.Text = "Delete Camera";
            this.checkBoxDeleteAppCamera.UseVisualStyleBackColor = false;
            // 
            // checkBoxDeleteApp3d
            // 
            this.checkBoxDeleteApp3d.AutoSize = true;
            this.checkBoxDeleteApp3d.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDeleteApp3d.Checked = true;
            this.checkBoxDeleteApp3d.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteApp3d.Enabled = false;
            this.checkBoxDeleteApp3d.Location = new System.Drawing.Point(6, 212);
            this.checkBoxDeleteApp3d.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDeleteApp3d.Name = "checkBoxDeleteApp3d";
            this.checkBoxDeleteApp3d.Size = new System.Drawing.Size(108, 17);
            this.checkBoxDeleteApp3d.TabIndex = 8;
            this.checkBoxDeleteApp3d.Text = "Delete Builder 3D";
            this.checkBoxDeleteApp3d.UseVisualStyleBackColor = false;
            // 
            // checkBoxDeleteWindows10Apps
            // 
            this.checkBoxDeleteWindows10Apps.AutoSize = true;
            this.checkBoxDeleteWindows10Apps.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDeleteWindows10Apps.Location = new System.Drawing.Point(6, 195);
            this.checkBoxDeleteWindows10Apps.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDeleteWindows10Apps.Name = "checkBoxDeleteWindows10Apps";
            this.checkBoxDeleteWindows10Apps.Size = new System.Drawing.Size(173, 17);
            this.checkBoxDeleteWindows10Apps.TabIndex = 7;
            this.checkBoxDeleteWindows10Apps.Text = "Delete windows 10 metro apps";
            this.checkBoxDeleteWindows10Apps.UseVisualStyleBackColor = false;
            this.checkBoxDeleteWindows10Apps.CheckedChanged += new System.EventHandler(this.checkBoxDeleteWindows10Apps_CheckedChanged);
            // 
            // checkBoxSPYTasks
            // 
            this.checkBoxSPYTasks.AutoSize = true;
            this.checkBoxSPYTasks.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxSPYTasks.Checked = true;
            this.checkBoxSPYTasks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSPYTasks.Location = new System.Drawing.Point(6, 108);
            this.checkBoxSPYTasks.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxSPYTasks.Name = "checkBoxSPYTasks";
            this.checkBoxSPYTasks.Size = new System.Drawing.Size(109, 17);
            this.checkBoxSPYTasks.TabIndex = 6;
            this.checkBoxSPYTasks.Text = "Disable SPY tasks";
            this.checkBoxSPYTasks.UseVisualStyleBackColor = false;
            // 
            // checkBoxSetDefaultPhoto
            // 
            this.checkBoxSetDefaultPhoto.AutoSize = true;
            this.checkBoxSetDefaultPhoto.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxSetDefaultPhoto.Checked = true;
            this.checkBoxSetDefaultPhoto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSetDefaultPhoto.Location = new System.Drawing.Point(6, 91);
            this.checkBoxSetDefaultPhoto.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxSetDefaultPhoto.Name = "checkBoxSetDefaultPhoto";
            this.checkBoxSetDefaultPhoto.Size = new System.Drawing.Size(189, 17);
            this.checkBoxSetDefaultPhoto.TabIndex = 5;
            this.checkBoxSetDefaultPhoto.Text = "Set default windows photo viewer";
            this.checkBoxSetDefaultPhoto.UseVisualStyleBackColor = false;
            // 
            // checkBoxDisableWindowsDefender
            // 
            this.checkBoxDisableWindowsDefender.AutoSize = true;
            this.checkBoxDisableWindowsDefender.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDisableWindowsDefender.Checked = true;
            this.checkBoxDisableWindowsDefender.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisableWindowsDefender.Location = new System.Drawing.Point(6, 74);
            this.checkBoxDisableWindowsDefender.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDisableWindowsDefender.Name = "checkBoxDisableWindowsDefender";
            this.checkBoxDisableWindowsDefender.Size = new System.Drawing.Size(151, 17);
            this.checkBoxDisableWindowsDefender.TabIndex = 4;
            this.checkBoxDisableWindowsDefender.Text = "Disable windows defender";
            this.checkBoxDisableWindowsDefender.UseVisualStyleBackColor = false;
            // 
            // checkBoxDisablePrivateSettings
            // 
            this.checkBoxDisablePrivateSettings.AutoSize = true;
            this.checkBoxDisablePrivateSettings.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxDisablePrivateSettings.Checked = true;
            this.checkBoxDisablePrivateSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisablePrivateSettings.Location = new System.Drawing.Point(6, 57);
            this.checkBoxDisablePrivateSettings.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDisablePrivateSettings.Name = "checkBoxDisablePrivateSettings";
            this.checkBoxDisablePrivateSettings.Size = new System.Drawing.Size(138, 17);
            this.checkBoxDisablePrivateSettings.TabIndex = 3;
            this.checkBoxDisablePrivateSettings.Text = "Disable private settings";
            this.checkBoxDisablePrivateSettings.UseVisualStyleBackColor = false;
            // 
            // checkBoxAddToHosts
            // 
            this.checkBoxAddToHosts.AutoSize = true;
            this.checkBoxAddToHosts.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxAddToHosts.Checked = true;
            this.checkBoxAddToHosts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAddToHosts.Location = new System.Drawing.Point(6, 40);
            this.checkBoxAddToHosts.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxAddToHosts.Name = "checkBoxAddToHosts";
            this.checkBoxAddToHosts.Size = new System.Drawing.Size(314, 17);
            this.checkBoxAddToHosts.TabIndex = 2;
            this.checkBoxAddToHosts.Text = "Add spy domains to hosts file, and block in Windows Firewall\r\n";
            this.checkBoxAddToHosts.UseVisualStyleBackColor = false;
            // 
            // checkBoxKeyLoggerAndTelemetry
            // 
            this.checkBoxKeyLoggerAndTelemetry.AutoSize = true;
            this.checkBoxKeyLoggerAndTelemetry.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxKeyLoggerAndTelemetry.Checked = true;
            this.checkBoxKeyLoggerAndTelemetry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKeyLoggerAndTelemetry.Location = new System.Drawing.Point(6, 23);
            this.checkBoxKeyLoggerAndTelemetry.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxKeyLoggerAndTelemetry.Name = "checkBoxKeyLoggerAndTelemetry";
            this.checkBoxKeyLoggerAndTelemetry.Size = new System.Drawing.Size(177, 17);
            this.checkBoxKeyLoggerAndTelemetry.TabIndex = 1;
            this.checkBoxKeyLoggerAndTelemetry.Text = "Delete keylogger and telemetry";
            this.checkBoxKeyLoggerAndTelemetry.UseVisualStyleBackColor = false;
            // 
            // checkBoxCreateSystemRestorePoint
            // 
            this.checkBoxCreateSystemRestorePoint.AutoSize = true;
            this.checkBoxCreateSystemRestorePoint.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxCreateSystemRestorePoint.Checked = true;
            this.checkBoxCreateSystemRestorePoint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCreateSystemRestorePoint.Location = new System.Drawing.Point(6, 6);
            this.checkBoxCreateSystemRestorePoint.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxCreateSystemRestorePoint.Name = "checkBoxCreateSystemRestorePoint";
            this.checkBoxCreateSystemRestorePoint.Size = new System.Drawing.Size(161, 17);
            this.checkBoxCreateSystemRestorePoint.TabIndex = 0;
            this.checkBoxCreateSystemRestorePoint.Text = "Create system restore point";
            this.checkBoxCreateSystemRestorePoint.UseVisualStyleBackColor = false;
            // 
            // tabPageMain
            // 
            this.tabPageMain.BackColor = System.Drawing.Color.DimGray;
            this.tabPageMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageMain.Controls.Add(this.btnDestroyWindows10Spy);
            this.tabPageMain.Controls.Add(this.LogOutputTextBox);
            this.tabPageMain.Controls.Add(this.ProgressBarStatus);
            this.tabPageMain.Controls.Add(this.btnDestroyWindowsSpying);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(445, 400);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            // 
            // btnDestroyWindows10Spy
            // 
            this.btnDestroyWindows10Spy.BackColor = System.Drawing.Color.White;
            this.btnDestroyWindows10Spy.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnDestroyWindows10Spy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDestroyWindows10Spy.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDestroyWindows10Spy.Location = new System.Drawing.Point(8, 6);
            this.btnDestroyWindows10Spy.Name = "btnDestroyWindows10Spy";
            this.btnDestroyWindows10Spy.Size = new System.Drawing.Size(429, 30);
            this.btnDestroyWindows10Spy.TabIndex = 4;
            this.btnDestroyWindows10Spy.Text = "Execute";
            this.btnDestroyWindows10Spy.UseVisualStyleBackColor = false;
            this.btnDestroyWindows10Spy.Visible = false;
            this.btnDestroyWindows10Spy.Click += new System.EventHandler(this.btnDestroyWindows78Spy_Click);
            // 
            // LogOutputTextBox
            // 
            this.LogOutputTextBox.BackColor = System.Drawing.Color.Black;
            this.LogOutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogOutputTextBox.Font = new System.Drawing.Font("Copperplate Gothic Bold", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutputTextBox.ForeColor = System.Drawing.Color.Cyan;
            this.LogOutputTextBox.Location = new System.Drawing.Point(8, 71);
            this.LogOutputTextBox.Name = "LogOutputTextBox";
            this.LogOutputTextBox.ReadOnly = true;
            this.LogOutputTextBox.Size = new System.Drawing.Size(429, 321);
            this.LogOutputTextBox.TabIndex = 3;
            this.LogOutputTextBox.Text = "";
            this.LogOutputTextBox.TextChanged += new System.EventHandler(this.LogOutputTextBox_TextChanged);
            // 
            // ProgressBarStatus
            // 
            this.ProgressBarStatus.BackColor = System.Drawing.SystemColors.Control;
            this.ProgressBarStatus.Location = new System.Drawing.Point(8, 42);
            this.ProgressBarStatus.Name = "ProgressBarStatus";
            this.ProgressBarStatus.Size = new System.Drawing.Size(429, 23);
            this.ProgressBarStatus.TabIndex = 1;
            // 
            // btnDestroyWindowsSpying
            // 
            this.btnDestroyWindowsSpying.BackColor = System.Drawing.Color.White;
            this.btnDestroyWindowsSpying.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnDestroyWindowsSpying.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDestroyWindowsSpying.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDestroyWindowsSpying.Location = new System.Drawing.Point(8, 6);
            this.btnDestroyWindowsSpying.Name = "btnDestroyWindowsSpying";
            this.btnDestroyWindowsSpying.Size = new System.Drawing.Size(429, 30);
            this.btnDestroyWindowsSpying.TabIndex = 0;
            this.btnDestroyWindowsSpying.Text = "Execute";
            this.btnDestroyWindowsSpying.UseVisualStyleBackColor = false;
            this.btnDestroyWindowsSpying.Click += new System.EventHandler(this.btnDestroyWindowsSpying_Click);
            // 
            // FormTabsControl
            // 
            this.FormTabsControl.Controls.Add(this.tabPageMain);
            this.FormTabsControl.Controls.Add(this.tabPageSettings);
            this.FormTabsControl.Controls.Add(this.tabPageUtilites);
            this.FormTabsControl.Controls.Add(this.tabPageAbout);
            this.FormTabsControl.Controls.Add(this.tabPageLicense);
            this.FormTabsControl.Location = new System.Drawing.Point(0, 31);
            this.FormTabsControl.Name = "FormTabsControl";
            this.FormTabsControl.SelectedIndex = 0;
            this.FormTabsControl.Size = new System.Drawing.Size(453, 426);
            this.FormTabsControl.TabIndex = 0;
            // 
            // checkBoxP2PWinUpdate
            // 
            this.checkBoxP2PWinUpdate.AutoSize = true;
            this.checkBoxP2PWinUpdate.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxP2PWinUpdate.Checked = true;
            this.checkBoxP2PWinUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxP2PWinUpdate.Location = new System.Drawing.Point(6, 142);
            this.checkBoxP2PWinUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxP2PWinUpdate.Name = "checkBoxP2PWinUpdate";
            this.checkBoxP2PWinUpdate.Size = new System.Drawing.Size(283, 17);
            this.checkBoxP2PWinUpdate.TabIndex = 23;
            this.checkBoxP2PWinUpdate.Text = "Disable Internet P2P Distribution of Windows Updates";
            this.checkBoxP2PWinUpdate.UseVisualStyleBackColor = false;
            // 
            // DestroyWindowsSpyingMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(453, 457);
            this.Controls.Add(this.BorderR);
            this.Controls.Add(this.BorderLeft);
            this.Controls.Add(this.BorderDown);
            this.Controls.Add(this.BorderUP);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.CaptionWindow);
            this.Controls.Add(this.FormTabsControl);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "DestroyWindowsSpyingMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DWS Lite                       build ";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DestroyWindowsSpyingMainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DestroyWindowsSpyingMainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderR)).EndInit();
            this.tabPageLicense.ResumeLayout(false);
            this.tabPageLicense.PerformLayout();
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
            this.tabPageUtilites.ResumeLayout(false);
            this.groupBoxWindowsUpdate.ResumeLayout(false);
            this.groupBoxUACEdit.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.tabPageMain.ResumeLayout(false);
            this.FormTabsControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label CaptionWindow;
        private PictureBox CloseButton;
        private PictureBox MinimizeButton;
        private PictureBox BorderUP;
        private PictureBox BorderDown;
        private PictureBox BorderLeft;
        private PictureBox BorderR;
        private TabPage tabPageLicense;
        private LinkLabel linkLabelLicense;
        private Label labelLicense;
        private TabPage tabPageAbout;
        private Label About_Info;
        private Label labelBuildDataTime;
        private TabPage tabPageUtilites;
        private Button btnDisableOfficeUpdate;
        private Button btnRemoveOldFirewallRules;
        private Button btnDeleteOneDrive;
        private Button btnDeleteMetroAppsInfo;
        private GroupBox groupBoxWindowsUpdate;
        private Button btnEnableWindowsUpdate;
        private Button btnDisableWindowsUpdate;
        private GroupBox groupBoxUACEdit;
        private Button btnEnableUac;
        private Button btnDisableUac;
        private Button btnOpenAndEditHosts;
        private Button btnRestoreSystem;
        private Button btnDeleteAllWindows10Apps;
        private TabPage tabPageSettings;
        private CheckBox checkBoxDisableServices;
        private CheckBox btnProfessionalMode;
        private Label labelInfoDeleteMetroApps;
        private CheckBox checkBoxDeleteAppXBOX;
        private CheckBox checkBoxDeleteAppVoice;
        private CheckBox checkBoxDeleteAppSolit;
        private CheckBox checkBoxDeleteAppPhotos;
        private CheckBox checkBoxDeleteAppPhone;
        private CheckBox checkBoxDeleteAppPeopleOneNote;
        private CheckBox checkBoxDeleteAppZune;
        private CheckBox checkBoxDeleteAppBing;
        private CheckBox checkBoxDeleteMailCalendarMaps;
        private CheckBox checkBoxDeleteAppCamera;
        private CheckBox checkBoxDeleteApp3d;
        private CheckBox checkBoxDeleteWindows10Apps;
        private CheckBox checkBoxSPYTasks;
        private CheckBox checkBoxSetDefaultPhoto;
        private CheckBox checkBoxDisableWindowsDefender;
        private CheckBox checkBoxDisablePrivateSettings;
        private CheckBox checkBoxAddToHosts;
        private CheckBox checkBoxKeyLoggerAndTelemetry;
        private CheckBox checkBoxCreateSystemRestorePoint;
        private TabPage tabPageMain;
        private Button btnDestroyWindows10Spy;
        private RichTextBox LogOutputTextBox;
        private ProgressBar ProgressBarStatus;
        private Button btnDestroyWindowsSpying;
        private TabControl FormTabsControl;
        private CheckBox checkBoxP2PWinUpdate;
    }
}

