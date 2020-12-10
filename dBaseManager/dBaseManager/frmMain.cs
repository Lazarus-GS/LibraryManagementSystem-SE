using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dBaseManager
{
    public partial class frmMain : Form
    {

        static string dBaseLocation = "LMS.accdb";

        clsDBaseManager manager = new clsDBaseManager(dBaseLocation, 5);
        public System.IO.FileInfo[] backups = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            Tuple<int, Dictionary<string, bool>> test = manager.checkDBase();

            txtDBaseHealth.Text = test.Item1.ToString() + Environment.NewLine + Environment.NewLine;

            foreach (var item in test.Item2)
            {
                txtDBaseHealth.Text += item.Key + "    " + item.Value.ToString() + Environment.NewLine;
            }

            backups = manager.getAllBackups();

            foreach (var item in backups)
            {
                lsbBackups.Items.Add(item.Name.Replace(".accdb", ""));
            }

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {

            MessageBox.Show(manager.restoreBackup(backups[lsbBackups.SelectedIndex]).ToString());

        }
    }
}
