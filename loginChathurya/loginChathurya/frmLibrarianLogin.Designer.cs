
namespace loginLibrarian
{
    partial class frmLibrarianLogin
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
            this.lsbUsers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnewpword = new System.Windows.Forms.TextBox();
            this.btnChangePword = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblPWord = new System.Windows.Forms.Label();
            this.lblUName = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtPWord = new System.Windows.Forms.TextBox();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsbUsers
            // 
            this.lsbUsers.FormattingEnabled = true;
            this.lsbUsers.ItemHeight = 16;
            this.lsbUsers.Location = new System.Drawing.Point(12, 12);
            this.lsbUsers.Name = "lsbUsers";
            this.lsbUsers.Size = new System.Drawing.Size(264, 324);
            this.lsbUsers.TabIndex = 25;
            this.lsbUsers.SelectedIndexChanged += new System.EventHandler(this.lsbUsers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Enter New Password:";
            // 
            // txtnewpword
            // 
            this.txtnewpword.Location = new System.Drawing.Point(450, 188);
            this.txtnewpword.Margin = new System.Windows.Forms.Padding(4);
            this.txtnewpword.Name = "txtnewpword";
            this.txtnewpword.Size = new System.Drawing.Size(132, 22);
            this.txtnewpword.TabIndex = 23;
            // 
            // btnChangePword
            // 
            this.btnChangePword.Location = new System.Drawing.Point(359, 218);
            this.btnChangePword.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangePword.Name = "btnChangePword";
            this.btnChangePword.Size = new System.Drawing.Size(160, 28);
            this.btnChangePword.TabIndex = 22;
            this.btnChangePword.Text = "Change Password";
            this.btnChangePword.UseVisualStyleBackColor = true;
            this.btnChangePword.Click += new System.EventHandler(this.btnChangePword_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(316, 260);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(463, 94);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(90, 28);
            this.btnRegister.TabIndex = 20;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblPWord
            // 
            this.lblPWord.AutoSize = true;
            this.lblPWord.Location = new System.Drawing.Point(283, 55);
            this.lblPWord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPWord.Name = "lblPWord";
            this.lblPWord.Size = new System.Drawing.Size(92, 17);
            this.lblPWord.TabIndex = 19;
            this.lblPWord.Text = "PASSWORD:";
            // 
            // lblUName
            // 
            this.lblUName.AutoSize = true;
            this.lblUName.Location = new System.Drawing.Point(283, 20);
            this.lblUName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUName.Name = "lblUName";
            this.lblUName.Size = new System.Drawing.Size(93, 17);
            this.lblUName.TabIndex = 18;
            this.lblUName.Text = "USER NAME:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(316, 94);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 28);
            this.btnLogin.TabIndex = 17;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(482, 308);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "E&XIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtPWord
            // 
            this.txtPWord.Location = new System.Drawing.Point(388, 55);
            this.txtPWord.Margin = new System.Windows.Forms.Padding(4);
            this.txtPWord.Name = "txtPWord";
            this.txtPWord.Size = new System.Drawing.Size(194, 22);
            this.txtPWord.TabIndex = 15;
            // 
            // txtUname
            // 
            this.txtUname.Location = new System.Drawing.Point(390, 17);
            this.txtUname.Margin = new System.Windows.Forms.Padding(4);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(192, 22);
            this.txtUname.TabIndex = 14;
            // 
            // lblLogin
            // 
            this.lblLogin.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLogin.Location = new System.Drawing.Point(282, 126);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(312, 58);
            this.lblLogin.TabIndex = 26;
            this.lblLogin.Text = "Not Logged In";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(463, 260);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 28);
            this.btnLogout.TabIndex = 27;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // frmLibrarianLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 347);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblLogin);
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
            this.Name = "frmLibrarianLogin";
            this.Text = "Librarian Login";
            this.Load += new System.EventHandler(this.clsLibrarianLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnewpword;
        private System.Windows.Forms.Button btnChangePword;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblPWord;
        private System.Windows.Forms.Label lblUName;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtPWord;
        private System.Windows.Forms.TextBox txtUname;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnLogout;
    }
}