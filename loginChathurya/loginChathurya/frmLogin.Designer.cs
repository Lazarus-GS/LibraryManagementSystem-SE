
namespace loginApplication
{
    partial class frmLogin
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
            this.txtUname = new System.Windows.Forms.TextBox();
            this.txtPWord = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblUName = new System.Windows.Forms.Label();
            this.lblPWord = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnChangePword = new System.Windows.Forms.Button();
            this.txtnewpword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbUsers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtUname
            // 
            this.txtUname.Location = new System.Drawing.Point(452, 41);
            this.txtUname.Margin = new System.Windows.Forms.Padding(4);
            this.txtUname.Name = "txtUname";
            this.txtUname.ReadOnly = true;
            this.txtUname.Size = new System.Drawing.Size(132, 22);
            this.txtUname.TabIndex = 0;
            // 
            // txtPWord
            // 
            this.txtPWord.Location = new System.Drawing.Point(452, 117);
            this.txtPWord.Margin = new System.Windows.Forms.Padding(4);
            this.txtPWord.Name = "txtPWord";
            this.txtPWord.Size = new System.Drawing.Size(132, 22);
            this.txtPWord.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(676, 14);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "E&XIT";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(676, 44);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 28);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // lblUName
            // 
            this.lblUName.AutoSize = true;
            this.lblUName.Location = new System.Drawing.Point(345, 44);
            this.lblUName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUName.Name = "lblUName";
            this.lblUName.Size = new System.Drawing.Size(93, 17);
            this.lblUName.TabIndex = 4;
            this.lblUName.Text = "USER NAME:";
            // 
            // lblPWord
            // 
            this.lblPWord.AutoSize = true;
            this.lblPWord.Location = new System.Drawing.Point(347, 117);
            this.lblPWord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPWord.Name = "lblPWord";
            this.lblPWord.Size = new System.Drawing.Size(92, 17);
            this.lblPWord.TabIndex = 5;
            this.lblPWord.Text = "PASSWORD:";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(659, 80);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(132, 28);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(676, 117);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnChangePword
            // 
            this.btnChangePword.Location = new System.Drawing.Point(349, 183);
            this.btnChangePword.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangePword.Name = "btnChangePword";
            this.btnChangePword.Size = new System.Drawing.Size(160, 28);
            this.btnChangePword.TabIndex = 10;
            this.btnChangePword.Text = "Change Password";
            this.btnChangePword.UseVisualStyleBackColor = true;
            // 
            // txtnewpword
            // 
            this.txtnewpword.Location = new System.Drawing.Point(500, 236);
            this.txtnewpword.Margin = new System.Windows.Forms.Padding(4);
            this.txtnewpword.Name = "txtnewpword";
            this.txtnewpword.Size = new System.Drawing.Size(132, 22);
            this.txtnewpword.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 240);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Enter New Password:";
            // 
            // lsbUsers
            // 
            this.lsbUsers.FormattingEnabled = true;
            this.lsbUsers.ItemHeight = 16;
            this.lsbUsers.Location = new System.Drawing.Point(12, 12);
            this.lsbUsers.Name = "lsbUsers";
            this.lsbUsers.Size = new System.Drawing.Size(264, 276);
            this.lsbUsers.TabIndex = 13;
            this.lsbUsers.SelectedIndexChanged += new System.EventHandler(this.lsbUsers_SelectedIndexChanged);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(807, 293);
            this.Controls.Add(this.lsbUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtnewpword);
            this.Controls.Add(this.btnChangePword);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblPWord);
            this.Controls.Add(this.lblUName);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtPWord);
            this.Controls.Add(this.txtUname);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLogin";
            this.Text = "LOGIN WINDOW";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUname;
        private System.Windows.Forms.TextBox txtPWord;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUName;
        private System.Windows.Forms.Label lblPWord;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnChangePword;
        private System.Windows.Forms.TextBox txtnewpword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbUsers;
    }
}

