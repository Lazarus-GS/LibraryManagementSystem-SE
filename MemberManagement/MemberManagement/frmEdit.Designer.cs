
namespace MemberManagement
{
    partial class frmEdit
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dtpBDay = new System.Windows.Forms.DateTimePicker();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.txtLibraryCard = new System.Windows.Forms.TextBox();
            this.txtNICNo = new System.Windows.Forms.TextBox();
            this.txtTPNo = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(310, 203);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(143, 30);
            this.btnUpdate.TabIndex = 42;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dtpBDay
            // 
            this.dtpBDay.Location = new System.Drawing.Point(13, 91);
            this.dtpBDay.Name = "dtpBDay";
            this.dtpBDay.Size = new System.Drawing.Size(442, 22);
            this.dtpBDay.TabIndex = 41;
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(12, 63);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(442, 24);
            this.cmbGender.TabIndex = 40;
            // 
            // txtLibraryCard
            // 
            this.txtLibraryCard.Location = new System.Drawing.Point(11, 35);
            this.txtLibraryCard.Name = "txtLibraryCard";
            this.txtLibraryCard.Size = new System.Drawing.Size(443, 22);
            this.txtLibraryCard.TabIndex = 39;
            // 
            // txtNICNo
            // 
            this.txtNICNo.Location = new System.Drawing.Point(11, 119);
            this.txtNICNo.Name = "txtNICNo";
            this.txtNICNo.Size = new System.Drawing.Size(443, 22);
            this.txtNICNo.TabIndex = 38;
            // 
            // txtTPNo
            // 
            this.txtTPNo.Location = new System.Drawing.Point(12, 147);
            this.txtTPNo.Name = "txtTPNo";
            this.txtTPNo.Size = new System.Drawing.Size(443, 22);
            this.txtTPNo.TabIndex = 37;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(12, 175);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(443, 22);
            this.txtAddress.TabIndex = 36;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(11, 7);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(443, 22);
            this.txtFullName.TabIndex = 35;
            // 
            // frmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 238);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dtpBDay);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.txtLibraryCard);
            this.Controls.Add(this.txtNICNo);
            this.Controls.Add(this.txtTPNo);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtFullName);
            this.Name = "frmEdit";
            this.Text = "Update Member Data";
            this.Load += new System.EventHandler(this.frmEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DateTimePicker dtpBDay;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.TextBox txtLibraryCard;
        private System.Windows.Forms.TextBox txtNICNo;
        private System.Windows.Forms.TextBox txtTPNo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtFullName;
    }
}