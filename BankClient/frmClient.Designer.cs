namespace BankClient
{
    partial class frmClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClient));
            this.tbControl = new System.Windows.Forms.TabControl();
            this.tpConnected = new System.Windows.Forms.TabPage();
            this.btnTransferToAccount = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbAccAmount = new System.Windows.Forms.Label();
            this.lbNameAcc = new System.Windows.Forms.Label();
            this.tpConnecting = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.mnAccount = new System.Windows.Forms.MenuStrip();
            this.smConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tpConfig = new System.Windows.Forms.TabPage();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ssConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssSeparator = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssContacting = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbControl.SuspendLayout();
            this.tpConnected.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tpConnecting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mnAccount.SuspendLayout();
            this.tpConfig.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbControl
            // 
            this.tbControl.Controls.Add(this.tpConnected);
            this.tbControl.Controls.Add(this.tpConnecting);
            this.tbControl.Controls.Add(this.tpConfig);
            resources.ApplyResources(this.tbControl, "tbControl");
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 0;
            // 
            // tpConnected
            // 
            this.tpConnected.Controls.Add(this.btnTransferToAccount);
            this.tpConnected.Controls.Add(this.panel1);
            resources.ApplyResources(this.tpConnected, "tpConnected");
            this.tpConnected.Name = "tpConnected";
            this.tpConnected.UseVisualStyleBackColor = true;
            // 
            // btnTransferToAccount
            // 
            resources.ApplyResources(this.btnTransferToAccount, "btnTransferToAccount");
            this.btnTransferToAccount.Name = "btnTransferToAccount";
            this.btnTransferToAccount.UseVisualStyleBackColor = true;
            this.btnTransferToAccount.Click += new System.EventHandler(this.btnTransferToAccount_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbAccAmount);
            this.panel1.Controls.Add(this.lbNameAcc);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // lbAccAmount
            // 
            resources.ApplyResources(this.lbAccAmount, "lbAccAmount");
            this.lbAccAmount.ForeColor = System.Drawing.Color.DarkRed;
            this.lbAccAmount.Name = "lbAccAmount";
            // 
            // lbNameAcc
            // 
            resources.ApplyResources(this.lbNameAcc, "lbNameAcc");
            this.lbNameAcc.Name = "lbNameAcc";
            // 
            // tpConnecting
            // 
            this.tpConnecting.Controls.Add(this.pictureBox1);
            this.tpConnecting.Controls.Add(this.btnEnter);
            this.tpConnecting.Controls.Add(this.txtPassword);
            this.tpConnecting.Controls.Add(this.txtAccount);
            this.tpConnecting.Controls.Add(this.mnAccount);
            resources.ApplyResources(this.tpConnecting, "tpConnecting");
            this.tpConnecting.Name = "tpConnecting";
            this.tpConnecting.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BankClient.Properties.Resources._1466373565_bitcoin_dollar_exchange;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnEnter
            // 
            resources.ApplyResources(this.btnEnter, "btnEnter");
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            // 
            // txtAccount
            // 
            resources.ApplyResources(this.txtAccount, "txtAccount");
            this.txtAccount.Name = "txtAccount";
            // 
            // mnAccount
            // 
            this.mnAccount.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smConnect});
            resources.ApplyResources(this.mnAccount, "mnAccount");
            this.mnAccount.Name = "mnAccount";
            // 
            // smConnect
            // 
            this.smConnect.Name = "smConnect";
            resources.ApplyResources(this.smConnect, "smConnect");
            this.smConnect.Click += new System.EventHandler(this.smConnect_Click);
            // 
            // tpConfig
            // 
            this.tpConfig.Controls.Add(this.txtIp);
            this.tpConfig.Controls.Add(this.label2);
            this.tpConfig.Controls.Add(this.txtPort);
            this.tpConfig.Controls.Add(this.label1);
            resources.ApplyResources(this.tpConfig, "tpConfig");
            this.tpConfig.Name = "tpConfig";
            this.tpConfig.UseVisualStyleBackColor = true;
            // 
            // txtIp
            // 
            resources.ApplyResources(this.txtIp, "txtIp");
            this.txtIp.Name = "txtIp";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtPort
            // 
            resources.ApplyResources(this.txtPort, "txtPort");
            this.txtPort.Name = "txtPort";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssConnected,
            this.ssSeparator,
            this.ssContacting});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // ssConnected
            // 
            this.ssConnected.Name = "ssConnected";
            resources.ApplyResources(this.ssConnected, "ssConnected");
            // 
            // ssSeparator
            // 
            this.ssSeparator.Name = "ssSeparator";
            resources.ApplyResources(this.ssSeparator, "ssSeparator");
            // 
            // ssContacting
            // 
            this.ssContacting.Name = "ssContacting";
            resources.ApplyResources(this.ssContacting, "ssContacting");
            // 
            // frmClient
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tbControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnAccount;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClient_FormClosing);
            this.Enter += new System.EventHandler(this.frmClient_Enter);
            this.tbControl.ResumeLayout(false);
            this.tpConnected.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tpConnecting.ResumeLayout(false);
            this.tpConnecting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mnAccount.ResumeLayout(false);
            this.mnAccount.PerformLayout();
            this.tpConfig.ResumeLayout(false);
            this.tpConfig.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage tpConnecting;
        private System.Windows.Forms.TabPage tpConfig;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.ToolStripStatusLabel ssConnected;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.MenuStrip mnAccount;
        private System.Windows.Forms.ToolStripMenuItem smConnect;
        private System.Windows.Forms.ToolStripStatusLabel ssSeparator;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripStatusLabel ssContacting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbNameAcc;
        private System.Windows.Forms.Label lbAccAmount;
        private System.Windows.Forms.Button btnTransferToAccount;
        public System.Windows.Forms.TabControl tbControl;
        public System.Windows.Forms.TabPage tpConnected;
    }
}

