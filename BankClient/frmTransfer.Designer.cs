namespace BankClient
{
    partial class frmTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransfer));
            this.lbAccount = new System.Windows.Forms.Label();
            this.lbValor = new System.Windows.Forms.Label();
            this.mTxtAccount = new System.Windows.Forms.MaskedTextBox();
            this.mTxtValue = new System.Windows.Forms.MaskedTextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbAccount
            // 
            this.lbAccount.AutoSize = true;
            this.lbAccount.Location = new System.Drawing.Point(56, 26);
            this.lbAccount.Name = "lbAccount";
            this.lbAccount.Size = new System.Drawing.Size(59, 17);
            this.lbAccount.TabIndex = 0;
            this.lbAccount.Text = "Account";
            // 
            // lbValor
            // 
            this.lbValor.AutoSize = true;
            this.lbValor.Location = new System.Drawing.Point(56, 77);
            this.lbValor.Name = "lbValor";
            this.lbValor.Size = new System.Drawing.Size(44, 17);
            this.lbValor.TabIndex = 1;
            this.lbValor.Text = "Value";
            // 
            // mTxtAccount
            // 
            this.mTxtAccount.Location = new System.Drawing.Point(59, 46);
            this.mTxtAccount.Name = "mTxtAccount";
            this.mTxtAccount.Size = new System.Drawing.Size(100, 22);
            this.mTxtAccount.TabIndex = 2;
            // 
            // mTxtValue
            // 
            this.mTxtValue.Location = new System.Drawing.Point(59, 97);
            this.mTxtValue.Name = "mTxtValue";
            this.mTxtValue.Size = new System.Drawing.Size(100, 22);
            this.mTxtValue.TabIndex = 3;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(59, 143);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(100, 23);
            this.btnTransfer.TabIndex = 4;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // frmTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 197);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.mTxtValue);
            this.Controls.Add(this.mTxtAccount);
            this.Controls.Add(this.lbValor);
            this.Controls.Add(this.lbAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransfer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAccount;
        private System.Windows.Forms.Label lbValor;
        private System.Windows.Forms.MaskedTextBox mTxtAccount;
        private System.Windows.Forms.MaskedTextBox mTxtValue;
        private System.Windows.Forms.Button btnTransfer;
    }
}