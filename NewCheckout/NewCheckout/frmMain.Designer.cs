
namespace ManageCheckout
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
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.txtIssueDate = new System.Windows.Forms.TextBox();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.txtPenalty = new System.Windows.Forms.TextBox();
            this.txtOverdue = new System.Windows.Forms.TextBox();
            this.txtPenaltyFee = new System.Windows.Forms.TextBox();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.txtMember = new System.Windows.Forms.TextBox();
            this.txtBook = new System.Windows.Forms.TextBox();
            this.txtExtend = new System.Windows.Forms.TextBox();
            this.btnExtend = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.txtreturnBookID = new System.Windows.Forms.TextBox();
            this.btnByID = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(12, 12);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersWidth = 51;
            this.dgvMain.RowTemplate.Height = 24;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(641, 517);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(660, 13);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(67, 22);
            this.txtUserID.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(734, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(307, 22);
            this.txtUsername.TabIndex = 2;
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(734, 40);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(307, 22);
            this.txtBookName.TabIndex = 4;
            // 
            // txtBookID
            // 
            this.txtBookID.Location = new System.Drawing.Point(660, 41);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(67, 22);
            this.txtBookID.TabIndex = 3;
            // 
            // txtIssueDate
            // 
            this.txtIssueDate.Location = new System.Drawing.Point(660, 70);
            this.txtIssueDate.Name = "txtIssueDate";
            this.txtIssueDate.Size = new System.Drawing.Size(187, 22);
            this.txtIssueDate.TabIndex = 5;
            // 
            // txtDueDate
            // 
            this.txtDueDate.Location = new System.Drawing.Point(853, 70);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.Size = new System.Drawing.Size(188, 22);
            this.txtDueDate.TabIndex = 6;
            // 
            // txtPenalty
            // 
            this.txtPenalty.Location = new System.Drawing.Point(660, 99);
            this.txtPenalty.Name = "txtPenalty";
            this.txtPenalty.Size = new System.Drawing.Size(129, 22);
            this.txtPenalty.TabIndex = 7;
            // 
            // txtOverdue
            // 
            this.txtOverdue.Location = new System.Drawing.Point(660, 128);
            this.txtOverdue.Name = "txtOverdue";
            this.txtOverdue.Size = new System.Drawing.Size(187, 22);
            this.txtOverdue.TabIndex = 8;
            // 
            // txtPenaltyFee
            // 
            this.txtPenaltyFee.Location = new System.Drawing.Point(660, 157);
            this.txtPenaltyFee.Name = "txtPenaltyFee";
            this.txtPenaltyFee.Size = new System.Drawing.Size(187, 22);
            this.txtPenaltyFee.TabIndex = 9;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(659, 242);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(129, 36);
            this.btnCheckout.TabIndex = 10;
            this.btnCheckout.Text = "New Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // txtMember
            // 
            this.txtMember.Location = new System.Drawing.Point(660, 214);
            this.txtMember.Name = "txtMember";
            this.txtMember.Size = new System.Drawing.Size(100, 22);
            this.txtMember.TabIndex = 11;
            // 
            // txtBook
            // 
            this.txtBook.Location = new System.Drawing.Point(766, 214);
            this.txtBook.Name = "txtBook";
            this.txtBook.Size = new System.Drawing.Size(100, 22);
            this.txtBook.TabIndex = 12;
            // 
            // txtExtend
            // 
            this.txtExtend.Location = new System.Drawing.Point(660, 314);
            this.txtExtend.Name = "txtExtend";
            this.txtExtend.Size = new System.Drawing.Size(100, 22);
            this.txtExtend.TabIndex = 13;
            // 
            // btnExtend
            // 
            this.btnExtend.Location = new System.Drawing.Point(779, 309);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(108, 33);
            this.btnExtend.TabIndex = 14;
            this.btnExtend.Text = "Extend";
            this.btnExtend.UseVisualStyleBackColor = true;
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(660, 371);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(129, 36);
            this.btnReturn.TabIndex = 15;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // txtreturnBookID
            // 
            this.txtreturnBookID.Location = new System.Drawing.Point(660, 419);
            this.txtreturnBookID.Name = "txtreturnBookID";
            this.txtreturnBookID.Size = new System.Drawing.Size(106, 22);
            this.txtreturnBookID.TabIndex = 16;
            // 
            // btnByID
            // 
            this.btnByID.Location = new System.Drawing.Point(794, 412);
            this.btnByID.Name = "btnByID";
            this.btnByID.Size = new System.Drawing.Size(145, 37);
            this.btnByID.TabIndex = 17;
            this.btnByID.Text = "Return By Book ID";
            this.btnByID.UseVisualStyleBackColor = true;
            this.btnByID.Click += new System.EventHandler(this.btnByID_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 541);
            this.Controls.Add(this.btnByID);
            this.Controls.Add(this.txtreturnBookID);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnExtend);
            this.Controls.Add(this.txtExtend);
            this.Controls.Add(this.txtBook);
            this.Controls.Add(this.txtMember);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.txtPenaltyFee);
            this.Controls.Add(this.txtOverdue);
            this.Controls.Add(this.txtPenalty);
            this.Controls.Add(this.txtDueDate);
            this.Controls.Add(this.txtIssueDate);
            this.Controls.Add(this.txtBookName);
            this.Controls.Add(this.txtBookID);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.dgvMain);
            this.Name = "frmMain";
            this.Text = "Checkout Window";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.TextBox txtIssueDate;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.TextBox txtPenalty;
        private System.Windows.Forms.TextBox txtOverdue;
        private System.Windows.Forms.TextBox txtPenaltyFee;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.TextBox txtMember;
        private System.Windows.Forms.TextBox txtBook;
        private System.Windows.Forms.TextBox txtExtend;
        private System.Windows.Forms.Button btnExtend;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.TextBox txtreturnBookID;
        private System.Windows.Forms.Button btnByID;
    }
}

