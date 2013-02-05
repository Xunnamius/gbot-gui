namespace GameBotGUI
{
    partial class GBGMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GBGMain));
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.sslblMouseTracker = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.botToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetRunStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearProcessLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txbLog = new System.Windows.Forms.TextBox();
            this.lblCurrentActionLabel = new System.Windows.Forms.Label();
            this.lblCurrentAction = new System.Windows.Forms.Label();
            this.lbNodes = new System.Windows.Forms.ListBox();
            this.cbProfileSelector = new System.Windows.Forms.ComboBox();
            this.lblProfileSelector = new System.Windows.Forms.Label();
            this.btnCreateNode = new System.Windows.Forms.Button();
            this.btnDuplicateNode = new System.Windows.Forms.Button();
            this.btnDestroyNode = new System.Windows.Forms.Button();
            this.btnModifyNode = new System.Windows.Forms.Button();
            this.btnStopBot = new System.Windows.Forms.Button();
            this.btnRunBot = new System.Windows.Forms.Button();
            this.gbxRunStats = new System.Windows.Forms.GroupBox();
            this.lblCurrentProfile = new System.Windows.Forms.Label();
            this.lblNodeCount = new System.Windows.Forms.Label();
            this.lblTotalRuns = new System.Windows.Forms.Label();
            this.lblTotalClicks = new System.Windows.Forms.Label();
            this.lblLastActionTime = new System.Windows.Forms.Label();
            this.lblTotalRunTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMoveNodeDown = new System.Windows.Forms.Button();
            this.btnMoveNodeUp = new System.Windows.Forms.Button();
            this.trayNotif = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStripMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.gbxRunStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslblMouseTracker});
            this.statusStripMain.Location = new System.Drawing.Point(0, 463);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(623, 22);
            this.statusStripMain.TabIndex = 0;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // sslblMouseTracker
            // 
            this.sslblMouseTracker.Name = "sslblMouseTracker";
            this.sslblMouseTracker.Size = new System.Drawing.Size(137, 17);
            this.sslblMouseTracker.Text = "Loading mouse tracker...";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Enabled = false;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botToolStripMenuItem,
            this.profilesToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(623, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // botToolStripMenuItem
            // 
            this.botToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runBotToolStripMenuItem,
            this.toolStripSeparator1,
            this.resetRunStatsToolStripMenuItem,
            this.clearNodesToolStripMenuItem,
            this.clearProcessLogToolStripMenuItem,
            this.toolStripSeparator2,
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.botToolStripMenuItem.Name = "botToolStripMenuItem";
            this.botToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.botToolStripMenuItem.Text = "Bot";
            // 
            // runBotToolStripMenuItem
            // 
            this.runBotToolStripMenuItem.Enabled = false;
            this.runBotToolStripMenuItem.Name = "runBotToolStripMenuItem";
            this.runBotToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.runBotToolStripMenuItem.Text = "Run Bot";
            this.runBotToolStripMenuItem.Click += new System.EventHandler(this.runBotToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // resetRunStatsToolStripMenuItem
            // 
            this.resetRunStatsToolStripMenuItem.Name = "resetRunStatsToolStripMenuItem";
            this.resetRunStatsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetRunStatsToolStripMenuItem.Text = "Reset Run Statsistics";
            this.resetRunStatsToolStripMenuItem.Click += new System.EventHandler(this.resetRunStatsToolStripMenuItem_Click);
            // 
            // clearNodesToolStripMenuItem
            // 
            this.clearNodesToolStripMenuItem.Name = "clearNodesToolStripMenuItem";
            this.clearNodesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearNodesToolStripMenuItem.Text = "Clear Nodes";
            this.clearNodesToolStripMenuItem.Click += new System.EventHandler(this.clearNodesToolStripMenuItem_Click);
            // 
            // clearProcessLogToolStripMenuItem
            // 
            this.clearProcessLogToolStripMenuItem.Name = "clearProcessLogToolStripMenuItem";
            this.clearProcessLogToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearProcessLogToolStripMenuItem.Text = "Clear Process Log";
            this.clearProcessLogToolStripMenuItem.Click += new System.EventHandler(this.clearProcessLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Enabled = false;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.restartToolStripMenuItem.Text = "Factory Reset";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveProfileToolStripMenuItem,
            this.loadProfileToolStripMenuItem});
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.profilesToolStripMenuItem.Text = "Profiles";
            // 
            // saveProfileToolStripMenuItem
            // 
            this.saveProfileToolStripMenuItem.Enabled = false;
            this.saveProfileToolStripMenuItem.Name = "saveProfileToolStripMenuItem";
            this.saveProfileToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.saveProfileToolStripMenuItem.Text = "Load Profile";
            // 
            // loadProfileToolStripMenuItem
            // 
            this.loadProfileToolStripMenuItem.Enabled = false;
            this.loadProfileToolStripMenuItem.Name = "loadProfileToolStripMenuItem";
            this.loadProfileToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.loadProfileToolStripMenuItem.Text = "Save Profile";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationSettingsToolStripMenuItem,
            this.profileSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // applicationSettingsToolStripMenuItem
            // 
            this.applicationSettingsToolStripMenuItem.Name = "applicationSettingsToolStripMenuItem";
            this.applicationSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.applicationSettingsToolStripMenuItem.Text = "Application Settings";
            this.applicationSettingsToolStripMenuItem.Click += new System.EventHandler(this.applicationSettingsToolStripMenuItem_Click);
            // 
            // profileSettingsToolStripMenuItem
            // 
            this.profileSettingsToolStripMenuItem.Name = "profileSettingsToolStripMenuItem";
            this.profileSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.profileSettingsToolStripMenuItem.Text = "Profile Settings";
            this.profileSettingsToolStripMenuItem.Click += new System.EventHandler(this.profileSettingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.toolStripSeparator3,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Enabled = false;
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.manualToolStripMenuItem.Text = "How To...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(152, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.aboutToolStripMenuItem.Text = "About GBotGUI";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // txbLog
            // 
            this.txbLog.Location = new System.Drawing.Point(0, 342);
            this.txbLog.Multiline = true;
            this.txbLog.Name = "txbLog";
            this.txbLog.ReadOnly = true;
            this.txbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbLog.Size = new System.Drawing.Size(623, 118);
            this.txbLog.TabIndex = 1;
            this.txbLog.TabStop = false;
            this.txbLog.Text = "Welcome to Game Bot, the cheater\'s Graphical User Interface by X0DG";
            // 
            // lblCurrentActionLabel
            // 
            this.lblCurrentActionLabel.AutoSize = true;
            this.lblCurrentActionLabel.Location = new System.Drawing.Point(13, 307);
            this.lblCurrentActionLabel.Name = "lblCurrentActionLabel";
            this.lblCurrentActionLabel.Size = new System.Drawing.Size(76, 13);
            this.lblCurrentActionLabel.TabIndex = 4;
            this.lblCurrentActionLabel.Text = "Current action:";
            // 
            // lblCurrentAction
            // 
            this.lblCurrentAction.AutoSize = true;
            this.lblCurrentAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentAction.Location = new System.Drawing.Point(95, 307);
            this.lblCurrentAction.Name = "lblCurrentAction";
            this.lblCurrentAction.Size = new System.Drawing.Size(130, 13);
            this.lblCurrentAction.TabIndex = 5;
            this.lblCurrentAction.Text = "Loading application...";
            // 
            // lbNodes
            // 
            this.lbNodes.FormattingEnabled = true;
            this.lbNodes.Location = new System.Drawing.Point(15, 68);
            this.lbNodes.Name = "lbNodes";
            this.lbNodes.ScrollAlwaysVisible = true;
            this.lbNodes.Size = new System.Drawing.Size(302, 121);
            this.lbNodes.TabIndex = 6;
            this.lbNodes.SelectedIndexChanged += new System.EventHandler(this.lbNodes_SelectedIndexChanged);
            // 
            // cbProfileSelector
            // 
            this.cbProfileSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfileSelector.Enabled = false;
            this.cbProfileSelector.FormattingEnabled = true;
            this.cbProfileSelector.Location = new System.Drawing.Point(100, 41);
            this.cbProfileSelector.Name = "cbProfileSelector";
            this.cbProfileSelector.Size = new System.Drawing.Size(217, 21);
            this.cbProfileSelector.TabIndex = 1;
            // 
            // lblProfileSelector
            // 
            this.lblProfileSelector.AutoSize = true;
            this.lblProfileSelector.Location = new System.Drawing.Point(12, 44);
            this.lblProfileSelector.Name = "lblProfileSelector";
            this.lblProfileSelector.Size = new System.Drawing.Size(82, 13);
            this.lblProfileSelector.TabIndex = 8;
            this.lblProfileSelector.Text = "Recent Profiles:";
            // 
            // btnCreateNode
            // 
            this.btnCreateNode.Enabled = false;
            this.btnCreateNode.Location = new System.Drawing.Point(15, 196);
            this.btnCreateNode.Name = "btnCreateNode";
            this.btnCreateNode.Size = new System.Drawing.Size(139, 23);
            this.btnCreateNode.TabIndex = 4;
            this.btnCreateNode.Text = "Create Node";
            this.btnCreateNode.UseVisualStyleBackColor = true;
            this.btnCreateNode.Click += new System.EventHandler(this.btnCreateNode_Click);
            // 
            // btnDuplicateNode
            // 
            this.btnDuplicateNode.Enabled = false;
            this.btnDuplicateNode.Location = new System.Drawing.Point(179, 196);
            this.btnDuplicateNode.Name = "btnDuplicateNode";
            this.btnDuplicateNode.Size = new System.Drawing.Size(139, 23);
            this.btnDuplicateNode.TabIndex = 5;
            this.btnDuplicateNode.Text = "Duplicate Node";
            this.btnDuplicateNode.UseVisualStyleBackColor = true;
            this.btnDuplicateNode.Click += new System.EventHandler(this.btnDuplicateNode_Click);
            // 
            // btnDestroyNode
            // 
            this.btnDestroyNode.Enabled = false;
            this.btnDestroyNode.Location = new System.Drawing.Point(179, 225);
            this.btnDestroyNode.Name = "btnDestroyNode";
            this.btnDestroyNode.Size = new System.Drawing.Size(139, 23);
            this.btnDestroyNode.TabIndex = 7;
            this.btnDestroyNode.Text = "Destroy Node";
            this.btnDestroyNode.UseVisualStyleBackColor = true;
            this.btnDestroyNode.Click += new System.EventHandler(this.btnDestroyNode_Click);
            // 
            // btnModifyNode
            // 
            this.btnModifyNode.Enabled = false;
            this.btnModifyNode.Location = new System.Drawing.Point(16, 225);
            this.btnModifyNode.Name = "btnModifyNode";
            this.btnModifyNode.Size = new System.Drawing.Size(139, 23);
            this.btnModifyNode.TabIndex = 6;
            this.btnModifyNode.Text = "Modify Node";
            this.btnModifyNode.UseVisualStyleBackColor = true;
            this.btnModifyNode.Click += new System.EventHandler(this.btnModifyNode_Click);
            // 
            // btnStopBot
            // 
            this.btnStopBot.Enabled = false;
            this.btnStopBot.Location = new System.Drawing.Point(343, 70);
            this.btnStopBot.Name = "btnStopBot";
            this.btnStopBot.Size = new System.Drawing.Size(269, 23);
            this.btnStopBot.TabIndex = 3;
            this.btnStopBot.Text = "Stop Bot (ctrl+alt+F12)";
            this.btnStopBot.UseVisualStyleBackColor = true;
            this.btnStopBot.Click += new System.EventHandler(this.btnStopBot_Click);
            // 
            // btnRunBot
            // 
            this.btnRunBot.Enabled = false;
            this.btnRunBot.Location = new System.Drawing.Point(342, 41);
            this.btnRunBot.Name = "btnRunBot";
            this.btnRunBot.Size = new System.Drawing.Size(269, 23);
            this.btnRunBot.TabIndex = 2;
            this.btnRunBot.Text = "Run Bot  (ctrl+alt+F12)";
            this.btnRunBot.UseVisualStyleBackColor = true;
            this.btnRunBot.Click += new System.EventHandler(this.btnRunBot_Click);
            // 
            // gbxRunStats
            // 
            this.gbxRunStats.Controls.Add(this.lblCurrentProfile);
            this.gbxRunStats.Controls.Add(this.lblNodeCount);
            this.gbxRunStats.Controls.Add(this.lblTotalRuns);
            this.gbxRunStats.Controls.Add(this.lblTotalClicks);
            this.gbxRunStats.Controls.Add(this.lblLastActionTime);
            this.gbxRunStats.Controls.Add(this.lblTotalRunTime);
            this.gbxRunStats.Controls.Add(this.label5);
            this.gbxRunStats.Controls.Add(this.label6);
            this.gbxRunStats.Controls.Add(this.label3);
            this.gbxRunStats.Controls.Add(this.label4);
            this.gbxRunStats.Controls.Add(this.label2);
            this.gbxRunStats.Controls.Add(this.label1);
            this.gbxRunStats.Location = new System.Drawing.Point(343, 109);
            this.gbxRunStats.Name = "gbxRunStats";
            this.gbxRunStats.Size = new System.Drawing.Size(268, 168);
            this.gbxRunStats.TabIndex = 15;
            this.gbxRunStats.TabStop = false;
            this.gbxRunStats.Text = "Run Statistics";
            // 
            // lblCurrentProfile
            // 
            this.lblCurrentProfile.Location = new System.Drawing.Point(112, 139);
            this.lblCurrentProfile.Name = "lblCurrentProfile";
            this.lblCurrentProfile.Size = new System.Drawing.Size(150, 13);
            this.lblCurrentProfile.TabIndex = 11;
            this.lblCurrentProfile.Text = "loading...";
            // 
            // lblNodeCount
            // 
            this.lblNodeCount.Location = new System.Drawing.Point(112, 116);
            this.lblNodeCount.Name = "lblNodeCount";
            this.lblNodeCount.Size = new System.Drawing.Size(150, 13);
            this.lblNodeCount.TabIndex = 10;
            this.lblNodeCount.Text = " loading...";
            // 
            // lblTotalRuns
            // 
            this.lblTotalRuns.Location = new System.Drawing.Point(112, 93);
            this.lblTotalRuns.Name = "lblTotalRuns";
            this.lblTotalRuns.Size = new System.Drawing.Size(150, 13);
            this.lblTotalRuns.TabIndex = 9;
            this.lblTotalRuns.Text = "loading...";
            // 
            // lblTotalClicks
            // 
            this.lblTotalClicks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalClicks.Location = new System.Drawing.Point(112, 70);
            this.lblTotalClicks.Name = "lblTotalClicks";
            this.lblTotalClicks.Size = new System.Drawing.Size(150, 13);
            this.lblTotalClicks.TabIndex = 8;
            this.lblTotalClicks.Text = "loading...";
            // 
            // lblLastActionTime
            // 
            this.lblLastActionTime.Location = new System.Drawing.Point(112, 47);
            this.lblLastActionTime.Name = "lblLastActionTime";
            this.lblLastActionTime.Size = new System.Drawing.Size(150, 13);
            this.lblLastActionTime.TabIndex = 7;
            this.lblLastActionTime.Text = "loading...";
            // 
            // lblTotalRunTime
            // 
            this.lblTotalRunTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRunTime.Location = new System.Drawing.Point(112, 24);
            this.lblTotalRunTime.Name = "lblTotalRunTime";
            this.lblTotalRunTime.Size = new System.Drawing.Size(150, 13);
            this.lblTotalRunTime.TabIndex = 6;
            this.lblTotalRunTime.Text = "loading...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Current Profile:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Node Count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total # of Runs:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Clicks:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Since Last Action:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Run Time:";
            // 
            // btnMoveNodeDown
            // 
            this.btnMoveNodeDown.Enabled = false;
            this.btnMoveNodeDown.Location = new System.Drawing.Point(179, 254);
            this.btnMoveNodeDown.Name = "btnMoveNodeDown";
            this.btnMoveNodeDown.Size = new System.Drawing.Size(139, 23);
            this.btnMoveNodeDown.TabIndex = 9;
            this.btnMoveNodeDown.Text = "Move Node Down";
            this.btnMoveNodeDown.UseVisualStyleBackColor = true;
            this.btnMoveNodeDown.Click += new System.EventHandler(this.btnMoveNodeDown_Click);
            // 
            // btnMoveNodeUp
            // 
            this.btnMoveNodeUp.Enabled = false;
            this.btnMoveNodeUp.Location = new System.Drawing.Point(16, 254);
            this.btnMoveNodeUp.Name = "btnMoveNodeUp";
            this.btnMoveNodeUp.Size = new System.Drawing.Size(139, 23);
            this.btnMoveNodeUp.TabIndex = 8;
            this.btnMoveNodeUp.Text = "Move Node Up";
            this.btnMoveNodeUp.UseVisualStyleBackColor = true;
            this.btnMoveNodeUp.Click += new System.EventHandler(this.btnMoveNodeUp_Click);
            // 
            // trayNotif
            // 
            this.trayNotif.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayNotif.Icon = ((System.Drawing.Icon)(resources.GetObject("trayNotif.Icon")));
            this.trayNotif.Text = "You cheater you!";
            this.trayNotif.Visible = true;
            // 
            // GBGMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 485);
            this.Controls.Add(this.btnMoveNodeDown);
            this.Controls.Add(this.btnMoveNodeUp);
            this.Controls.Add(this.gbxRunStats);
            this.Controls.Add(this.btnStopBot);
            this.Controls.Add(this.btnRunBot);
            this.Controls.Add(this.btnDestroyNode);
            this.Controls.Add(this.btnModifyNode);
            this.Controls.Add(this.btnDuplicateNode);
            this.Controls.Add(this.btnCreateNode);
            this.Controls.Add(this.lblProfileSelector);
            this.Controls.Add(this.cbProfileSelector);
            this.Controls.Add(this.lbNodes);
            this.Controls.Add(this.lblCurrentAction);
            this.Controls.Add(this.lblCurrentActionLabel);
            this.Controls.Add(this.txbLog);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GBGMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Game Bot GUI v";
            this.Load += new System.EventHandler(this.GBGMain_Load);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.gbxRunStats.ResumeLayout(false);
            this.gbxRunStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem botToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runBotToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem resetRunStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearProcessLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel sslblMouseTracker;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox txbLog;
        private System.Windows.Forms.Label lblCurrentActionLabel;
        private System.Windows.Forms.Label lblCurrentAction;
        private System.Windows.Forms.ListBox lbNodes;
        private System.Windows.Forms.ComboBox cbProfileSelector;
        private System.Windows.Forms.Label lblProfileSelector;
        private System.Windows.Forms.Button btnCreateNode;
        private System.Windows.Forms.Button btnDuplicateNode;
        private System.Windows.Forms.Button btnDestroyNode;
        private System.Windows.Forms.Button btnModifyNode;
        private System.Windows.Forms.Button btnStopBot;
        private System.Windows.Forms.Button btnRunBot;
        private System.Windows.Forms.GroupBox gbxRunStats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMoveNodeDown;
        private System.Windows.Forms.Button btnMoveNodeUp;
        private System.Windows.Forms.Label lblCurrentProfile;
        private System.Windows.Forms.Label lblNodeCount;
        private System.Windows.Forms.Label lblTotalRuns;
        private System.Windows.Forms.Label lblTotalClicks;
        private System.Windows.Forms.Label lblLastActionTime;
        private System.Windows.Forms.Label lblTotalRunTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.NotifyIcon trayNotif;
    }
}

