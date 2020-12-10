
namespace reportWriter
{
    partial class frmReport
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
            this.rtbReport = new System.Windows.Forms.RichTextBox();
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.lsbReports = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // rtbReport
            // 
            this.rtbReport.Location = new System.Drawing.Point(12, 12);
            this.rtbReport.Name = "rtbReport";
            this.rtbReport.Size = new System.Drawing.Size(569, 387);
            this.rtbReport.TabIndex = 0;
            this.rtbReport.Text = "";
            // 
            // txtEvent
            // 
            this.txtEvent.Location = new System.Drawing.Point(12, 411);
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.Size = new System.Drawing.Size(659, 22);
            this.txtEvent.TabIndex = 1;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(678, 405);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(110, 34);
            this.btnWrite.TabIndex = 2;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // lsbReports
            // 
            this.lsbReports.FormattingEnabled = true;
            this.lsbReports.ItemHeight = 16;
            this.lsbReports.Location = new System.Drawing.Point(587, 12);
            this.lsbReports.Name = "lsbReports";
            this.lsbReports.Size = new System.Drawing.Size(201, 388);
            this.lsbReports.TabIndex = 3;
            this.lsbReports.SelectedIndexChanged += new System.EventHandler(this.lsbReports_SelectedIndexChanged);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lsbReports);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.txtEvent);
            this.Controls.Add(this.rtbReport);
            this.Name = "frmReport";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbReport;
        private System.Windows.Forms.TextBox txtEvent;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.ListBox lsbReports;
    }
}

