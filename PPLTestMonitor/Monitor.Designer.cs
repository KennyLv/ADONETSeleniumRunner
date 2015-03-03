namespace PPLTestMonitor
{
    partial class Monitor
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_MailConfig = new System.Windows.Forms.TabPage();
            this.Config_but_Cancel = new System.Windows.Forms.Button();
            this.Config_but_OK = new System.Windows.Forms.Button();
            this.Config_setGroup_allState = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Config_txt_All_maxTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Config_txt_All_timeoutNum = new System.Windows.Forms.TextBox();
            this.Config_txt_All_timeSpan = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Config_setGroup_singleState = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Config_txt_fun_maxTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Config_txt_fun_timeoutNum = new System.Windows.Forms.TextBox();
            this.Config_txt_fun_timeSpan = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPage_Run = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.Run_txt_totalTime = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Run_but_changeFilePath = new System.Windows.Forms.Button();
            this.Run_lab_scriptFilePath = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Run_checkBox_WetherSend = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Run_combin_chooseEnvior = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Run_txt_StateStartTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Run_radio_startInOrder = new System.Windows.Forms.RadioButton();
            this.Run_radio_startInParallel = new System.Windows.Forms.RadioButton();
            this.Run_txt_singleStateRunTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Run_but_addState = new System.Windows.Forms.Button();
            this.Run_but_RUN = new System.Windows.Forms.Button();
            this.Run_CheckList_checkStates = new System.Windows.Forms.CheckedListBox();
            this.Run_setting_Panel = new System.Windows.Forms.Panel();
            this.Run_but_deleteState = new System.Windows.Forms.Button();
            this.tabPage_Logview = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage_MailConfig.SuspendLayout();
            this.Config_setGroup_allState.SuspendLayout();
            this.Config_setGroup_singleState.SuspendLayout();
            this.tabPage_Run.SuspendLayout();
            this.Run_setting_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_MailConfig);
            this.tabControl1.Controls.Add(this.tabPage_Run);
            this.tabControl1.Controls.Add(this.tabPage_Logview);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(432, 405);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_MailConfig
            // 
            this.tabPage_MailConfig.Controls.Add(this.Config_but_Cancel);
            this.tabPage_MailConfig.Controls.Add(this.Config_but_OK);
            this.tabPage_MailConfig.Controls.Add(this.Config_setGroup_allState);
            this.tabPage_MailConfig.Controls.Add(this.Config_setGroup_singleState);
            this.tabPage_MailConfig.Location = new System.Drawing.Point(4, 25);
            this.tabPage_MailConfig.Name = "tabPage_MailConfig";
            this.tabPage_MailConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_MailConfig.Size = new System.Drawing.Size(424, 376);
            this.tabPage_MailConfig.TabIndex = 0;
            this.tabPage_MailConfig.Text = "   邮件提醒设定   ";
            this.tabPage_MailConfig.UseVisualStyleBackColor = true;
            // 
            // Config_but_Cancel
            // 
            this.Config_but_Cancel.Location = new System.Drawing.Point(233, 309);
            this.Config_but_Cancel.Name = "Config_but_Cancel";
            this.Config_but_Cancel.Size = new System.Drawing.Size(136, 47);
            this.Config_but_Cancel.TabIndex = 3;
            this.Config_but_Cancel.Text = "Cancel";
            this.Config_but_Cancel.UseVisualStyleBackColor = true;
            this.Config_but_Cancel.Click += new System.EventHandler(this.Config_but_Cancel_Click);
            // 
            // Config_but_OK
            // 
            this.Config_but_OK.Location = new System.Drawing.Point(26, 309);
            this.Config_but_OK.Name = "Config_but_OK";
            this.Config_but_OK.Size = new System.Drawing.Size(137, 47);
            this.Config_but_OK.TabIndex = 2;
            this.Config_but_OK.Text = "Save";
            this.Config_but_OK.UseVisualStyleBackColor = true;
            this.Config_but_OK.Click += new System.EventHandler(this.Config_but_OK_Click);
            // 
            // Config_setGroup_allState
            // 
            this.Config_setGroup_allState.BackColor = System.Drawing.Color.White;
            this.Config_setGroup_allState.Controls.Add(this.label13);
            this.Config_setGroup_allState.Controls.Add(this.Config_txt_All_maxTime);
            this.Config_setGroup_allState.Controls.Add(this.label12);
            this.Config_setGroup_allState.Controls.Add(this.label11);
            this.Config_setGroup_allState.Controls.Add(this.Config_txt_All_timeoutNum);
            this.Config_setGroup_allState.Controls.Add(this.Config_txt_All_timeSpan);
            this.Config_setGroup_allState.Controls.Add(this.label8);
            this.Config_setGroup_allState.Controls.Add(this.label9);
            this.Config_setGroup_allState.Location = new System.Drawing.Point(8, 28);
            this.Config_setGroup_allState.Name = "Config_setGroup_allState";
            this.Config_setGroup_allState.Size = new System.Drawing.Size(388, 102);
            this.Config_setGroup_allState.TabIndex = 1;
            this.Config_setGroup_allState.TabStop = false;
            this.Config_setGroup_allState.Text = "全部州总的超时设定：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(321, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 17);
            this.label13.TabIndex = 9;
            this.label13.Text = "秒";
            // 
            // Config_txt_All_maxTime
            // 
            this.Config_txt_All_maxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Config_txt_All_maxTime.ForeColor = System.Drawing.Color.Red;
            this.Config_txt_All_maxTime.Location = new System.Drawing.Point(281, 32);
            this.Config_txt_All_maxTime.Name = "Config_txt_All_maxTime";
            this.Config_txt_All_maxTime.Size = new System.Drawing.Size(33, 22);
            this.Config_txt_All_maxTime.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(63, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 17);
            this.label12.TabIndex = 7;
            this.label12.Text = "的动作次数达到";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(222, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 17);
            this.label11.TabIndex = 6;
            this.label11.Text = "次则为超时！";
            // 
            // Config_txt_All_timeoutNum
            // 
            this.Config_txt_All_timeoutNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Config_txt_All_timeoutNum.ForeColor = System.Drawing.Color.Black;
            this.Config_txt_All_timeoutNum.Location = new System.Drawing.Point(177, 64);
            this.Config_txt_All_timeoutNum.Name = "Config_txt_All_timeoutNum";
            this.Config_txt_All_timeoutNum.Size = new System.Drawing.Size(41, 22);
            this.Config_txt_All_timeoutNum.TabIndex = 5;
            // 
            // Config_txt_All_timeSpan
            // 
            this.Config_txt_All_timeSpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Config_txt_All_timeSpan.ForeColor = System.Drawing.Color.Black;
            this.Config_txt_All_timeSpan.Location = new System.Drawing.Point(88, 32);
            this.Config_txt_All_timeSpan.Name = "Config_txt_All_timeSpan";
            this.Config_txt_All_timeSpan.Size = new System.Drawing.Size(44, 22);
            this.Config_txt_All_timeSpan.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(134, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "分钟内响应时间超过";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(49, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "当在";
            // 
            // Config_setGroup_singleState
            // 
            this.Config_setGroup_singleState.Controls.Add(this.label6);
            this.Config_setGroup_singleState.Controls.Add(this.Config_txt_fun_maxTime);
            this.Config_setGroup_singleState.Controls.Add(this.label7);
            this.Config_setGroup_singleState.Controls.Add(this.label16);
            this.Config_setGroup_singleState.Controls.Add(this.Config_txt_fun_timeoutNum);
            this.Config_setGroup_singleState.Controls.Add(this.Config_txt_fun_timeSpan);
            this.Config_setGroup_singleState.Controls.Add(this.label17);
            this.Config_setGroup_singleState.Controls.Add(this.label18);
            this.Config_setGroup_singleState.Location = new System.Drawing.Point(13, 149);
            this.Config_setGroup_singleState.Name = "Config_setGroup_singleState";
            this.Config_setGroup_singleState.Size = new System.Drawing.Size(388, 128);
            this.Config_setGroup_singleState.TabIndex = 0;
            this.Config_setGroup_singleState.TabStop = false;
            this.Config_setGroup_singleState.Text = "单个操作超时提醒设定：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(200, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "秒则为超时！";
            // 
            // Config_txt_fun_maxTime
            // 
            this.Config_txt_fun_maxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Config_txt_fun_maxTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Config_txt_fun_maxTime.Location = new System.Drawing.Point(160, 69);
            this.Config_txt_fun_maxTime.Name = "Config_txt_fun_maxTime";
            this.Config_txt_fun_maxTime.Size = new System.Drawing.Size(33, 22);
            this.Config_txt_fun_maxTime.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(61, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "响应时间超过";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(298, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 17);
            this.label16.TabIndex = 14;
            this.label16.Text = "次";
            // 
            // Config_txt_fun_timeoutNum
            // 
            this.Config_txt_fun_timeoutNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Config_txt_fun_timeoutNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Config_txt_fun_timeoutNum.Location = new System.Drawing.Point(251, 40);
            this.Config_txt_fun_timeoutNum.Name = "Config_txt_fun_timeoutNum";
            this.Config_txt_fun_timeoutNum.Size = new System.Drawing.Size(41, 22);
            this.Config_txt_fun_timeoutNum.TabIndex = 13;
            // 
            // Config_txt_fun_timeSpan
            // 
            this.Config_txt_fun_timeSpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Config_txt_fun_timeSpan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Config_txt_fun_timeSpan.Location = new System.Drawing.Point(86, 40);
            this.Config_txt_fun_timeSpan.Name = "Config_txt_fun_timeSpan";
            this.Config_txt_fun_timeSpan.Size = new System.Drawing.Size(44, 22);
            this.Config_txt_fun_timeSpan.TabIndex = 12;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(132, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 17);
            this.label17.TabIndex = 11;
            this.label17.Text = "分钟内某个动作";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(47, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(36, 17);
            this.label18.TabIndex = 10;
            this.label18.Text = "当在";
            // 
            // tabPage_Run
            // 
            this.tabPage_Run.Controls.Add(this.label15);
            this.tabPage_Run.Controls.Add(this.Run_txt_totalTime);
            this.tabPage_Run.Controls.Add(this.label14);
            this.tabPage_Run.Controls.Add(this.Run_but_changeFilePath);
            this.tabPage_Run.Controls.Add(this.Run_lab_scriptFilePath);
            this.tabPage_Run.Controls.Add(this.label10);
            this.tabPage_Run.Controls.Add(this.Run_checkBox_WetherSend);
            this.tabPage_Run.Controls.Add(this.label5);
            this.tabPage_Run.Controls.Add(this.Run_combin_chooseEnvior);
            this.tabPage_Run.Controls.Add(this.label4);
            this.tabPage_Run.Controls.Add(this.label3);
            this.tabPage_Run.Controls.Add(this.Run_txt_StateStartTime);
            this.tabPage_Run.Controls.Add(this.label2);
            this.tabPage_Run.Controls.Add(this.Run_radio_startInOrder);
            this.tabPage_Run.Controls.Add(this.Run_radio_startInParallel);
            this.tabPage_Run.Controls.Add(this.Run_txt_singleStateRunTime);
            this.tabPage_Run.Controls.Add(this.label1);
            this.tabPage_Run.Controls.Add(this.Run_but_addState);
            this.tabPage_Run.Controls.Add(this.Run_but_RUN);
            this.tabPage_Run.Controls.Add(this.Run_CheckList_checkStates);
            this.tabPage_Run.Controls.Add(this.Run_setting_Panel);
            this.tabPage_Run.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Run.Name = "tabPage_Run";
            this.tabPage_Run.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Run.Size = new System.Drawing.Size(424, 376);
            this.tabPage_Run.TabIndex = 1;
            this.tabPage_Run.Text = "   运行   ";
            this.tabPage_Run.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(167, 337);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 17);
            this.label15.TabIndex = 22;
            this.label15.Text = "分钟";
            // 
            // Run_txt_totalTime
            // 
            this.Run_txt_totalTime.Location = new System.Drawing.Point(114, 334);
            this.Run_txt_totalTime.Name = "Run_txt_totalTime";
            this.Run_txt_totalTime.Size = new System.Drawing.Size(47, 22);
            this.Run_txt_totalTime.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 337);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 17);
            this.label14.TabIndex = 20;
            this.label14.Text = "总运行时间：";
            // 
            // Run_but_changeFilePath
            // 
            this.Run_but_changeFilePath.Location = new System.Drawing.Point(321, 3);
            this.Run_but_changeFilePath.Name = "Run_but_changeFilePath";
            this.Run_but_changeFilePath.Size = new System.Drawing.Size(51, 27);
            this.Run_but_changeFilePath.TabIndex = 19;
            this.Run_but_changeFilePath.Text = "更改";
            this.Run_but_changeFilePath.UseVisualStyleBackColor = true;
            this.Run_but_changeFilePath.Click += new System.EventHandler(this.Run_but_changeFilePath_Click);
            // 
            // Run_lab_scriptFilePath
            // 
            this.Run_lab_scriptFilePath.AutoSize = true;
            this.Run_lab_scriptFilePath.Location = new System.Drawing.Point(101, 7);
            this.Run_lab_scriptFilePath.Name = "Run_lab_scriptFilePath";
            this.Run_lab_scriptFilePath.Size = new System.Drawing.Size(54, 17);
            this.Run_lab_scriptFilePath.TabIndex = 18;
            this.Run_lab_scriptFilePath.Text = "label11";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "脚本路径：";
            // 
            // Run_checkBox_WetherSend
            // 
            this.Run_checkBox_WetherSend.AutoSize = true;
            this.Run_checkBox_WetherSend.Location = new System.Drawing.Point(16, 299);
            this.Run_checkBox_WetherSend.Name = "Run_checkBox_WetherSend";
            this.Run_checkBox_WetherSend.Size = new System.Drawing.Size(86, 21);
            this.Run_checkBox_WetherSend.TabIndex = 15;
            this.Run_checkBox_WetherSend.Text = "发送邮件";
            this.Run_checkBox_WetherSend.UseVisualStyleBackColor = true;
            this.Run_checkBox_WetherSend.CheckedChanged += new System.EventHandler(this.Run_checkBox_WetherSend_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "运行环境：";
            // 
            // Run_combin_chooseEnvior
            // 
            this.Run_combin_chooseEnvior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Run_combin_chooseEnvior.FormattingEnabled = true;
            this.Run_combin_chooseEnvior.Items.AddRange(new object[] {
            "Prep",
            "Production",
            "Test"});
            this.Run_combin_chooseEnvior.Location = new System.Drawing.Point(98, 40);
            this.Run_combin_chooseEnvior.Name = "Run_combin_chooseEnvior";
            this.Run_combin_chooseEnvior.Size = new System.Drawing.Size(275, 24);
            this.Run_combin_chooseEnvior.TabIndex = 13;
            this.Run_combin_chooseEnvior.SelectedIndexChanged += new System.EventHandler(this.Run_combin_chooseEnvior_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "M";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(366, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "S";
            // 
            // Run_txt_StateStartTime
            // 
            this.Run_txt_StateStartTime.Enabled = false;
            this.Run_txt_StateStartTime.Location = new System.Drawing.Point(291, 164);
            this.Run_txt_StateStartTime.Name = "Run_txt_StateStartTime";
            this.Run_txt_StateStartTime.Size = new System.Drawing.Size(74, 22);
            this.Run_txt_StateStartTime.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(218, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "间隔时间：";
            // 
            // Run_radio_startInOrder
            // 
            this.Run_radio_startInOrder.AutoSize = true;
            this.Run_radio_startInOrder.Location = new System.Drawing.Point(202, 134);
            this.Run_radio_startInOrder.Name = "Run_radio_startInOrder";
            this.Run_radio_startInOrder.Size = new System.Drawing.Size(113, 21);
            this.Run_radio_startInOrder.TabIndex = 8;
            this.Run_radio_startInOrder.TabStop = true;
            this.Run_radio_startInOrder.Text = "各州间隔启动";
            this.Run_radio_startInOrder.UseVisualStyleBackColor = true;
            this.Run_radio_startInOrder.CheckedChanged += new System.EventHandler(this.Run_radio_startInOrder_CheckedChanged);
            // 
            // Run_radio_startInParallel
            // 
            this.Run_radio_startInParallel.AutoSize = true;
            this.Run_radio_startInParallel.Checked = true;
            this.Run_radio_startInParallel.Location = new System.Drawing.Point(202, 106);
            this.Run_radio_startInParallel.Name = "Run_radio_startInParallel";
            this.Run_radio_startInParallel.Size = new System.Drawing.Size(113, 21);
            this.Run_radio_startInParallel.TabIndex = 7;
            this.Run_radio_startInParallel.TabStop = true;
            this.Run_radio_startInParallel.Text = "各州同时启动";
            this.Run_radio_startInParallel.UseVisualStyleBackColor = true;
            this.Run_radio_startInParallel.CheckedChanged += new System.EventHandler(this.Run_radio_startInParallel_CheckedChanged);
            // 
            // Run_txt_singleStateRunTime
            // 
            this.Run_txt_singleStateRunTime.Location = new System.Drawing.Point(213, 241);
            this.Run_txt_singleStateRunTime.Name = "Run_txt_singleStateRunTime";
            this.Run_txt_singleStateRunTime.Size = new System.Drawing.Size(113, 22);
            this.Run_txt_singleStateRunTime.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "各州运行时间：";
            // 
            // Run_but_addState
            // 
            this.Run_but_addState.Location = new System.Drawing.Point(13, 232);
            this.Run_but_addState.Name = "Run_but_addState";
            this.Run_but_addState.Size = new System.Drawing.Size(64, 43);
            this.Run_but_addState.TabIndex = 3;
            this.Run_but_addState.Text = "Add";
            this.Run_but_addState.UseVisualStyleBackColor = true;
            this.Run_but_addState.Click += new System.EventHandler(this.Run_but_addState_Click);
            // 
            // Run_but_RUN
            // 
            this.Run_but_RUN.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Run_but_RUN.Font = new System.Drawing.Font("Segoe Print", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Run_but_RUN.ForeColor = System.Drawing.Color.Red;
            this.Run_but_RUN.Location = new System.Drawing.Point(231, 299);
            this.Run_but_RUN.Name = "Run_but_RUN";
            this.Run_but_RUN.Size = new System.Drawing.Size(174, 57);
            this.Run_but_RUN.TabIndex = 1;
            this.Run_but_RUN.Text = "RUN";
            this.Run_but_RUN.UseVisualStyleBackColor = false;
            this.Run_but_RUN.Click += new System.EventHandler(this.Run_but_Click);
            // 
            // Run_CheckList_checkStates
            // 
            this.Run_CheckList_checkStates.FormattingEnabled = true;
            this.Run_CheckList_checkStates.Location = new System.Drawing.Point(13, 92);
            this.Run_CheckList_checkStates.Name = "Run_CheckList_checkStates";
            this.Run_CheckList_checkStates.Size = new System.Drawing.Size(148, 123);
            this.Run_CheckList_checkStates.TabIndex = 0;
            // 
            // Run_setting_Panel
            // 
            this.Run_setting_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Run_setting_Panel.Controls.Add(this.Run_but_deleteState);
            this.Run_setting_Panel.Location = new System.Drawing.Point(3, 77);
            this.Run_setting_Panel.Name = "Run_setting_Panel";
            this.Run_setting_Panel.Size = new System.Drawing.Size(402, 205);
            this.Run_setting_Panel.TabIndex = 16;
            // 
            // Run_but_deleteState
            // 
            this.Run_but_deleteState.Location = new System.Drawing.Point(94, 154);
            this.Run_but_deleteState.Name = "Run_but_deleteState";
            this.Run_but_deleteState.Size = new System.Drawing.Size(64, 43);
            this.Run_but_deleteState.TabIndex = 2;
            this.Run_but_deleteState.Text = "Delete";
            this.Run_but_deleteState.UseVisualStyleBackColor = true;
            this.Run_but_deleteState.Click += new System.EventHandler(this.Run_but_deleteState_Click);
            // 
            // tabPage_Logview
            // 
            this.tabPage_Logview.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Logview.Name = "tabPage_Logview";
            this.tabPage_Logview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Logview.Size = new System.Drawing.Size(424, 376);
            this.tabPage_Logview.TabIndex = 2;
            this.tabPage_Logview.Text = "   运行监视  ";
            this.tabPage_Logview.UseVisualStyleBackColor = true;
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 405);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(450, 450);
            this.MinimumSize = new System.Drawing.Size(440, 440);
            this.Name = "Monitor";
            this.Text = "PPL Testing Monitor";
            this.Load += new System.EventHandler(this.Monitor_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Monitor_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_MailConfig.ResumeLayout(false);
            this.Config_setGroup_allState.ResumeLayout(false);
            this.Config_setGroup_allState.PerformLayout();
            this.Config_setGroup_singleState.ResumeLayout(false);
            this.Config_setGroup_singleState.PerformLayout();
            this.tabPage_Run.ResumeLayout(false);
            this.tabPage_Run.PerformLayout();
            this.Run_setting_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_MailConfig;
        private System.Windows.Forms.TabPage tabPage_Run;
        private System.Windows.Forms.TabPage tabPage_Logview;
        private System.Windows.Forms.Button Config_but_Cancel;
        private System.Windows.Forms.Button Config_but_OK;
        private System.Windows.Forms.GroupBox Config_setGroup_allState;
        private System.Windows.Forms.GroupBox Config_setGroup_singleState;
        private System.Windows.Forms.CheckedListBox Run_CheckList_checkStates;
        private System.Windows.Forms.Button Run_but_RUN;
        private System.Windows.Forms.Button Run_but_addState;
        private System.Windows.Forms.Button Run_but_deleteState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Run_txt_StateStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton Run_radio_startInOrder;
        private System.Windows.Forms.RadioButton Run_radio_startInParallel;
        private System.Windows.Forms.TextBox Run_txt_singleStateRunTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Run_combin_chooseEnvior;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox Run_checkBox_WetherSend;
        private System.Windows.Forms.Panel Run_setting_Panel;
        private System.Windows.Forms.Button Run_but_changeFilePath;
        private System.Windows.Forms.Label Run_lab_scriptFilePath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Config_txt_All_timeoutNum;
        private System.Windows.Forms.TextBox Config_txt_All_timeSpan;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Config_txt_All_maxTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox Run_txt_totalTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Config_txt_fun_maxTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox Config_txt_fun_timeoutNum;
        private System.Windows.Forms.TextBox Config_txt_fun_timeSpan;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}

