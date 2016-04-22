namespace E信自由版
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.pwdTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.RouterModelComboBox = new System.Windows.Forms.ComboBox();
            this.getRouterInfoButton = new System.Windows.Forms.Button();
            this.status2Label = new System.Windows.Forms.Label();
            this.IPComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.id2TextBox = new System.Windows.Forms.TextBox();
            this.pwd2TextBox = new System.Windows.Forms.TextBox();
            this.save2CheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.getIPAgainButton = new System.Windows.Forms.Button();
            this.setRouterButton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.notifyIconSystem = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPage1);
            this.mainTabControl.Controls.Add(this.tabPage2);
            this.mainTabControl.Controls.Add(this.tabPage3);
            this.mainTabControl.Location = new System.Drawing.Point(-4, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(545, 291);
            this.mainTabControl.TabIndex = 1;
            this.mainTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.mainTabControl_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.statusLabel);
            this.tabPage1.Controls.Add(this.ConnectButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(537, 265);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "本地拨号";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.saveCheckBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.idTextBox);
            this.groupBox1.Controls.Add(this.pwdTextBox);
            this.groupBox1.Location = new System.Drawing.Point(27, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 143);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "E信";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名：";
            // 
            // saveCheckBox
            // 
            this.saveCheckBox.AutoSize = true;
            this.saveCheckBox.Location = new System.Drawing.Point(79, 112);
            this.saveCheckBox.Name = "saveCheckBox";
            this.saveCheckBox.Size = new System.Drawing.Size(120, 16);
            this.saveCheckBox.TabIndex = 1;
            this.saveCheckBox.Text = "保存用户名和密码";
            this.saveCheckBox.UseVisualStyleBackColor = true;
            this.saveCheckBox.CheckedChanged += new System.EventHandler(this.saveCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "密码：";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(79, 40);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 21);
            this.idTextBox.TabIndex = 3;
            this.idTextBox.TextChanged += new System.EventHandler(this.idTextBox_TextChanged);
            // 
            // pwdTextBox
            // 
            this.pwdTextBox.Font = new System.Drawing.Font("Segoe WP", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdTextBox.Location = new System.Drawing.Point(79, 72);
            this.pwdTextBox.Name = "pwdTextBox";
            this.pwdTextBox.PasswordChar = '●';
            this.pwdTextBox.Size = new System.Drawing.Size(100, 21);
            this.pwdTextBox.TabIndex = 4;
            this.pwdTextBox.TextChanged += new System.EventHandler(this.pwdTextBox_TextChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(268, 33);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 12);
            this.statusLabel.TabIndex = 7;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(100, 187);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "连接";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.RouterModelComboBox);
            this.tabPage2.Controls.Add(this.getRouterInfoButton);
            this.tabPage2.Controls.Add(this.status2Label);
            this.tabPage2.Controls.Add(this.IPComboBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.getIPAgainButton);
            this.tabPage2.Controls.Add(this.setRouterButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(537, 265);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "路由器拨号";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(250, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "请选择路由器型号：";
            // 
            // RouterModelComboBox
            // 
            this.RouterModelComboBox.FormattingEnabled = true;
            this.RouterModelComboBox.Location = new System.Drawing.Point(252, 96);
            this.RouterModelComboBox.Name = "RouterModelComboBox";
            this.RouterModelComboBox.Size = new System.Drawing.Size(169, 20);
            this.RouterModelComboBox.TabIndex = 14;
            this.RouterModelComboBox.SelectedIndexChanged += new System.EventHandler(this.RouterModelComboBox_SelectedIndexChanged);
            // 
            // getRouterInfoButton
            // 
            this.getRouterInfoButton.Location = new System.Drawing.Point(129, 180);
            this.getRouterInfoButton.Name = "getRouterInfoButton";
            this.getRouterInfoButton.Size = new System.Drawing.Size(97, 23);
            this.getRouterInfoButton.TabIndex = 13;
            this.getRouterInfoButton.Text = "获取路由器信息";
            this.getRouterInfoButton.UseVisualStyleBackColor = true;
            this.getRouterInfoButton.Click += new System.EventHandler(this.getRouterInfoButton_Click);
            // 
            // status2Label
            // 
            this.status2Label.AutoSize = true;
            this.status2Label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.status2Label.Location = new System.Drawing.Point(263, 133);
            this.status2Label.Name = "status2Label";
            this.status2Label.Size = new System.Drawing.Size(0, 17);
            this.status2Label.TabIndex = 12;
            // 
            // IPComboBox
            // 
            this.IPComboBox.FormattingEnabled = true;
            this.IPComboBox.Location = new System.Drawing.Point(252, 51);
            this.IPComboBox.Name = "IPComboBox";
            this.IPComboBox.Size = new System.Drawing.Size(169, 20);
            this.IPComboBox.TabIndex = 11;
            this.IPComboBox.SelectedIndexChanged += new System.EventHandler(this.IPComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "请选择路由器IP地址：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.id2TextBox);
            this.groupBox2.Controls.Add(this.pwd2TextBox);
            this.groupBox2.Controls.Add(this.save2CheckBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(27, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 143);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "路由器管理员";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "用户名：";
            // 
            // id2TextBox
            // 
            this.id2TextBox.Location = new System.Drawing.Point(79, 40);
            this.id2TextBox.Name = "id2TextBox";
            this.id2TextBox.Size = new System.Drawing.Size(100, 21);
            this.id2TextBox.TabIndex = 8;
            this.id2TextBox.TextChanged += new System.EventHandler(this.id2TextBox_TextChanged);
            // 
            // pwd2TextBox
            // 
            this.pwd2TextBox.Font = new System.Drawing.Font("Segoe WP", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwd2TextBox.Location = new System.Drawing.Point(79, 72);
            this.pwd2TextBox.Name = "pwd2TextBox";
            this.pwd2TextBox.PasswordChar = '●';
            this.pwd2TextBox.Size = new System.Drawing.Size(100, 21);
            this.pwd2TextBox.TabIndex = 10;
            this.pwd2TextBox.TextChanged += new System.EventHandler(this.pwd2TextBox_TextChanged);
            // 
            // save2CheckBox
            // 
            this.save2CheckBox.AutoSize = true;
            this.save2CheckBox.Location = new System.Drawing.Point(79, 112);
            this.save2CheckBox.Name = "save2CheckBox";
            this.save2CheckBox.Size = new System.Drawing.Size(120, 16);
            this.save2CheckBox.TabIndex = 11;
            this.save2CheckBox.Text = "保存用户名和密码";
            this.save2CheckBox.UseVisualStyleBackColor = true;
            this.save2CheckBox.CheckedChanged += new System.EventHandler(this.save2CheckBox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "密码：";
            // 
            // getIPAgainButton
            // 
            this.getIPAgainButton.Location = new System.Drawing.Point(437, 49);
            this.getIPAgainButton.Name = "getIPAgainButton";
            this.getIPAgainButton.Size = new System.Drawing.Size(75, 23);
            this.getIPAgainButton.TabIndex = 3;
            this.getIPAgainButton.Text = "重新获取";
            this.getIPAgainButton.UseVisualStyleBackColor = true;
            this.getIPAgainButton.Click += new System.EventHandler(this.getIPAgainButton_Click);
            // 
            // setRouterButton
            // 
            this.setRouterButton.Location = new System.Drawing.Point(27, 180);
            this.setRouterButton.Name = "setRouterButton";
            this.setRouterButton.Size = new System.Drawing.Size(75, 23);
            this.setRouterButton.TabIndex = 0;
            this.setRouterButton.Text = "连接";
            this.setRouterButton.UseVisualStyleBackColor = true;
            this.setRouterButton.Click += new System.EventHandler(this.setRouterButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(537, 265);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "关于";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(238, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 221);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(30, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(185, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Email：LOH1024@qq.com";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(30, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Power by here";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(29, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Version：1.0.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(26, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 38);
            this.label7.TabIndex = 0;
            this.label7.Text = "E信自由版";
            // 
            // notifyIconSystem
            // 
            this.notifyIconSystem.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIconSystem.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconSystem.Icon")));
            this.notifyIconSystem.Text = "notifyIcon1";
            this.notifyIconSystem.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMenuItem,
            this.aboutMenuItem,
            this.exitMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 70);
            // 
            // showMenuItem
            // 
            this.showMenuItem.Name = "showMenuItem";
            this.showMenuItem.Size = new System.Drawing.Size(136, 22);
            this.showMenuItem.Text = "显示主面板";
            this.showMenuItem.Click += new System.EventHandler(this.showMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(136, 22);
            this.aboutMenuItem.Text = "关于";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exitMenuItem.Text = "退出";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 289);
            this.Controls.Add(this.mainTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(552, 328);
            this.MinimumSize = new System.Drawing.Size(552, 328);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E信自由版";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.mainTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pwdTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox saveCheckBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button getIPAgainButton;
        private System.Windows.Forms.Button setRouterButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox id2TextBox;
        private System.Windows.Forms.TextBox pwd2TextBox;
        private System.Windows.Forms.CheckBox save2CheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox IPComboBox;
        private System.Windows.Forms.Label status2Label;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button getRouterInfoButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox RouterModelComboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon notifyIconSystem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;



    }
}

