using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reportWriter
{
    public partial class frmReport : Form
    {

        const string hashKey = "sblw-3hn8-sqoy19";//Key should be either of 128 bit or of 192 bit

        clsReportWriter reportWriter = new clsReportWriter(hashKey);

        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            rtbReport.Text = reportWriter.readReport();
            lsbReports.Items.AddRange(reportWriter.getAllReports());
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            reportWriter.newEvent(txtEvent.Text);
            rtbReport.Text = reportWriter.readReport();
        }

        private void lsbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbReport.Text = reportWriter.readReport(lsbReports.SelectedItem.ToString());
        }
    }
}
