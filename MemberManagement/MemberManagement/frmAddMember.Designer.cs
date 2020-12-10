
namespace MemberManagement
{
    partial class frmAddMember
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
            this.txtLibraryCard = new System.Windows.Forms.TextBox();
            this.txtNICNo = new System.Windows.Forms.TextBox();
            this.txtTPNo = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.dtpBDay = new System.Windows.Forms.DateTimePicker();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLibraryCard
            // 
            this.txtLibraryCard.Location = new System.Drawing.Point(12, 40);
            this.txtLibraryCard.Name = "txtLibraryCard";
            this.txtLibraryCard.Size = new System.Drawing.Size(443, 22);
            this.txtLibraryCard.TabIndex = 27;
            // 
            // txtNICNo
            // 
            this.txtNICNo.Location = new System.Drawing.Point(12, 124);
            this.txtNICNo.Name = "txtNICNo";
            this.txtNICNo.Size = new System.Drawing.Size(443, 22);
            this.txtNICNo.TabIndex = 24;
            // 
            // txtTPNo
            // 
            this.txtTPNo.Location = new System.Drawing.Point(13, 152);
            this.txtTPNo.Name = "txtTPNo";
            this.txtTPNo.Size = new System.Drawing.Size(443, 22);
            this.txtTPNo.TabIndex = 23;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(13, 180);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(443, 22);
            this.txtAddress.TabIndex = 22;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(12, 12);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(443, 22);
            this.txtFullName.TabIndex = 19;
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(13, 68);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(442, 24);
            this.cmbGender.TabIndex = 32;
            // 
            // dtpBDay
            // 
            this.dtpBDay.Location = new System.Drawing.Point(14, 96);
            this.dtpBDay.Name = "dtpBDay";
            this.dtpBDay.Size = new System.Drawing.Size(442, 22);
            this.dtpBDay.TabIndex = 33;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(311, 208);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(143, 30);
            this.btnRegister.TabIndex = 34;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // frmAddMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 250);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.dtpBDay);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.txtLibraryCard);
            this.Controls.Add(this.txtNICNo);
            this.Controls.Add(this.txtTPNo);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtFullName);
            this.Name = "frmAddMember";
            this.Text = "Add Member";
            this.Load += new System.EventHandler(this.frmAddMember_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtLibraryCard;
        private System.Windows.Forms.TextBox txtNICNo;
        private System.Windows.Forms.TextBox txtTPNo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.DateTimePicker dtpBDay;
        private System.Windows.Forms.Button btnRegister;
    }
}