
namespace MemberManagement
{
    partial class frmMain
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
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rdbName = new System.Windows.Forms.RadioButton();
            this.rdbLibID = new System.Windows.Forms.RadioButton();
            this.rdbNID = new System.Windows.Forms.RadioButton();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtNameInitials = new System.Windows.Forms.TextBox();
            this.txtRegDate = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtTPNo = new System.Windows.Forms.TextBox();
            this.txtNICNo = new System.Windows.Forms.TextBox();
            this.txtBDay = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.txtLibraryCard = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtExpDate = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(12, 40);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersWidth = 51;
            this.dgvMain.RowTemplate.Height = 24;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(607, 552);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(13, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(323, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // rdbName
            // 
            this.rdbName.AutoSize = true;
            this.rdbName.Location = new System.Drawing.Point(352, 14);
            this.rdbName.Name = "rdbName";
            this.rdbName.Size = new System.Drawing.Size(66, 21);
            this.rdbName.TabIndex = 2;
            this.rdbName.TabStop = true;
            this.rdbName.Text = "Name";
            this.rdbName.UseVisualStyleBackColor = true;
            // 
            // rdbLibID
            // 
            this.rdbLibID.AutoSize = true;
            this.rdbLibID.Location = new System.Drawing.Point(424, 14);
            this.rdbLibID.Name = "rdbLibID";
            this.rdbLibID.Size = new System.Drawing.Size(90, 21);
            this.rdbLibID.TabIndex = 3;
            this.rdbLibID.TabStop = true;
            this.rdbLibID.Text = "Library ID";
            this.rdbLibID.UseVisualStyleBackColor = true;
            // 
            // rdbNID
            // 
            this.rdbNID.AutoSize = true;
            this.rdbNID.Location = new System.Drawing.Point(521, 13);
            this.rdbNID.Name = "rdbNID";
            this.rdbNID.Size = new System.Drawing.Size(98, 21);
            this.rdbNID.TabIndex = 4;
            this.rdbNID.TabStop = true;
            this.rdbNID.Text = "National ID";
            this.rdbNID.UseVisualStyleBackColor = true;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(626, 40);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(443, 22);
            this.txtFullName.TabIndex = 5;
            // 
            // txtNameInitials
            // 
            this.txtNameInitials.Location = new System.Drawing.Point(625, 67);
            this.txtNameInitials.Name = "txtNameInitials";
            this.txtNameInitials.Size = new System.Drawing.Size(443, 22);
            this.txtNameInitials.TabIndex = 6;
            // 
            // txtRegDate
            // 
            this.txtRegDate.Location = new System.Drawing.Point(625, 319);
            this.txtRegDate.Name = "txtRegDate";
            this.txtRegDate.Size = new System.Drawing.Size(443, 22);
            this.txtRegDate.TabIndex = 7;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(626, 291);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(443, 22);
            this.txtAddress.TabIndex = 8;
            // 
            // txtTPNo
            // 
            this.txtTPNo.Location = new System.Drawing.Point(626, 263);
            this.txtTPNo.Name = "txtTPNo";
            this.txtTPNo.Size = new System.Drawing.Size(443, 22);
            this.txtTPNo.TabIndex = 9;
            // 
            // txtNICNo
            // 
            this.txtNICNo.Location = new System.Drawing.Point(625, 235);
            this.txtNICNo.Name = "txtNICNo";
            this.txtNICNo.Size = new System.Drawing.Size(443, 22);
            this.txtNICNo.TabIndex = 10;
            // 
            // txtBDay
            // 
            this.txtBDay.Location = new System.Drawing.Point(625, 207);
            this.txtBDay.Name = "txtBDay";
            this.txtBDay.Size = new System.Drawing.Size(443, 22);
            this.txtBDay.TabIndex = 11;
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(626, 179);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(443, 22);
            this.txtGender.TabIndex = 12;
            // 
            // txtLibraryCard
            // 
            this.txtLibraryCard.Location = new System.Drawing.Point(625, 151);
            this.txtLibraryCard.Name = "txtLibraryCard";
            this.txtLibraryCard.Size = new System.Drawing.Size(443, 22);
            this.txtLibraryCard.TabIndex = 13;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(625, 123);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(443, 22);
            this.txtLastName.TabIndex = 14;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(626, 95);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(443, 22);
            this.txtFirstName.TabIndex = 15;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(625, 375);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(443, 22);
            this.txtStatus.TabIndex = 17;
            // 
            // txtExpDate
            // 
            this.txtExpDate.Location = new System.Drawing.Point(626, 347);
            this.txtExpDate.Name = "txtExpDate";
            this.txtExpDate.Size = new System.Drawing.Size(443, 22);
            this.txtExpDate.TabIndex = 18;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(944, 403);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(124, 30);
            this.btnRegister.TabIndex = 19;
            this.btnRegister.Text = "Register Member";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtUpdate
            // 
            this.txtUpdate.Location = new System.Drawing.Point(783, 403);
            this.txtUpdate.Name = "txtUpdate";
            this.txtUpdate.Size = new System.Drawing.Size(144, 29);
            this.txtUpdate.TabIndex = 20;
            this.txtUpdate.Text = "Update Info";
            this.txtUpdate.UseVisualStyleBackColor = true;
            this.txtUpdate.Click += new System.EventHandler(this.txtUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(944, 439);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 31);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete Member";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSuspend
            // 
            this.btnSuspend.Location = new System.Drawing.Point(783, 439);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(143, 31);
            this.btnSuspend.TabIndex = 22;
            this.btnSuspend.Text = "Suspend User";
            this.btnSuspend.UseVisualStyleBackColor = true;
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.Location = new System.Drawing.Point(626, 403);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(145, 30);
            this.btnRenew.TabIndex = 23;
            this.btnRenew.Text = "Renew User";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 604);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnSuspend);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtUpdate);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtExpDate);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtLibraryCard);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.txtBDay);
            this.Controls.Add(this.txtNICNo);
            this.Controls.Add(this.txtTPNo);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtRegDate);
            this.Controls.Add(this.txtNameInitials);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.rdbNID);
            this.Controls.Add(this.rdbLibID);
            this.Controls.Add(this.rdbName);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvMain);
            this.Name = "frmMain";
            this.Text = "Member Management";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdbName;
        private System.Windows.Forms.RadioButton rdbLibID;
        private System.Windows.Forms.RadioButton rdbNID;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtNameInitials;
        private System.Windows.Forms.TextBox txtRegDate;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtTPNo;
        private System.Windows.Forms.TextBox txtNICNo;
        private System.Windows.Forms.TextBox txtBDay;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.TextBox txtLibraryCard;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtExpDate;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button txtUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSuspend;
        private System.Windows.Forms.Button btnRenew;
    }
}

