
namespace dBaseManager
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
            this.txtDBaseHealth = new System.Windows.Forms.TextBox();
            this.lsbBackups = new System.Windows.Forms.ListBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDBaseHealth
            // 
            this.txtDBaseHealth.Location = new System.Drawing.Point(12, 12);
            this.txtDBaseHealth.Multiline = true;
            this.txtDBaseHealth.Name = "txtDBaseHealth";
            this.txtDBaseHealth.Size = new System.Drawing.Size(212, 228);
            this.txtDBaseHealth.TabIndex = 0;
            // 
            // lsbBackups
            // 
            this.lsbBackups.FormattingEnabled = true;
            this.lsbBackups.ItemHeight = 16;
            this.lsbBackups.Location = new System.Drawing.Point(231, 12);
            this.lsbBackups.Name = "lsbBackups";
            this.lsbBackups.Size = new System.Drawing.Size(295, 228);
            this.lsbBackups.TabIndex = 1;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(415, 246);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(111, 32);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.lsbBackups);
            this.Controls.Add(this.txtDBaseHealth);
            this.Name = "frmMain";
            this.Text = "Database Manager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDBaseHealth;
        private System.Windows.Forms.ListBox lsbBackups;
        private System.Windows.Forms.Button btnRestore;
    }
}

