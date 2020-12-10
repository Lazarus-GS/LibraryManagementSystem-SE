using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace MemberManagement
{
    public partial class frmMain : Form
    {

        clsMemberManagement memberManager = new clsMemberManagement("Database\\LMS.accdb", "Members");

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            dgvMain.DataSource = memberManager.getData().Tables[0].DefaultView;
            dgvMain.Columns[1].HeaderText = "Full Name";
            dgvMain.Columns.Remove(dgvMain.Columns[3]);

        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string[] data = memberManager.getInfo(int.Parse(dgvMain.SelectedRows[0].Cells[0].Value.ToString()));

            txtFullName.Text = data[0];
            txtNameInitials.Text = data[1];
            txtFirstName.Text = data[2];
            txtLastName.Text = data[3];
            txtLibraryCard.Text = data[4];
            txtGender.Text = data[5];
            txtBDay.Text = data[6];
            txtNICNo.Text = data[7];
            txtTPNo.Text = data[8];
            txtAddress.Text = data[9];
            txtRegDate.Text = data[10];
            txtExpDate.Text = data[11];
            txtStatus.Text = data[12];
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmAddMember registration = new frmAddMember("Database\\LMS.accdb", "Members");
            registration.ShowDialog();
            dgvMain.DataSource = memberManager.getData().Tables[0].DefaultView;
        }

        private void txtUpdate_Click(object sender, EventArgs e)
        {
            frmEdit editInfo = new frmEdit("Database\\LMS.accdb", "Members", int.Parse(dgvMain.SelectedRows[0].Cells[0].Value.ToString()));
            editInfo.ShowDialog();
            dgvMain.DataSource = memberManager.getData().Tables[0].DefaultView;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {

            memberManager.renewUser(int.Parse(dgvMain.SelectedRows[0].Cells[0].Value.ToString()));
            dgvMain.DataSource = memberManager.getData().Tables[0].DefaultView;

        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            memberManager.suspendUser(int.Parse(dgvMain.SelectedRows[0].Cells[0].Value.ToString()));
            dgvMain.DataSource = memberManager.getData().Tables[0].DefaultView;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            memberManager.deleteUser(int.Parse(dgvMain.SelectedRows[0].Cells[0].Value.ToString()));
            dgvMain.DataSource = memberManager.getData().Tables[0].DefaultView;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                memberManager.removeFilter();
            }
            else
            {
                memberManager.applyFilter(Convert.ToInt32(rdbName.Checked) + (Convert.ToInt32(rdbLibID.Checked) * 2) + (Convert.ToInt32(rdbNID.Checked) * 3), "'%" + txtSearch.Text + "%'");
            }
            dgvMain.DataSource = memberManager.getData().Tables[0].DefaultView;
        }
    }
}
