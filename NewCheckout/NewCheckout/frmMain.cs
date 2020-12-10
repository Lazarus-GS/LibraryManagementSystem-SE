using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageCheckout
{
    public partial class frmMain : Form
    {

        clsManageCheckout checkout = new clsManageCheckout(@"D:\SLTC\Semester 04\Software Engineering project\Assignments\Assignment Main\My Work\Database\LMS.accdb", "Book_Issues", 5, 2, 100);

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            dgvMain.DataSource = checkout.getData().Tables[0].DefaultView;

        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Tuple<int, int, DateTime, DateTime> data = checkout.getData(int.Parse(dgvMain.SelectedRows[0].Cells[0].Value.ToString()));
            Tuple<string, string, string, string> info = checkout.getInfo(int.Parse(dgvMain.SelectedRows[0].Cells[0].Value.ToString()));

            txtBookID.Text = data.Item2.ToString();
            txtBookName.Text = info.Item2.ToString();
            txtUserID.Text = data.Item1.ToString();
            txtUsername.Text = info.Item1.ToString();
            txtIssueDate.Text = info.Item3.ToString();
            txtDueDate.Text = info.Item4.ToString();
            Tuple<int, int> penalties = checkout.checkPenalties(int.Parse(dgvMain.SelectedRows[0].Cells[0].Value.ToString()));
            txtOverdue.Text = penalties.Item1.ToString();
            if (penalties.Item1 <= 0)
            {
                txtPenalty.Text = "On Time";
            }
            else
            {
                txtPenalty.Text = "Overdue";
            }
            txtPenaltyFee.Text = penalties.Item2.ToString();

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {

            string error = checkout.bookCheckout(int.Parse(txtBook.Text.ToString()), int.Parse(txtMember.Text.ToString()));
            MessageBox.Show(error.ToString());
            dgvMain.DataSource = checkout.getData().Tables[0].DefaultView;

        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            int error = checkout.extendTime(int.Parse(dgvMain.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(txtExtend.Text.ToString()));
            MessageBox.Show(error.ToString());
            dgvMain.DataSource = checkout.getData().Tables[0].DefaultView;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

            int error = checkout.returnCheckout(int.Parse(dgvMain.SelectedRows[0].Cells[0].Value.ToString()));
            MessageBox.Show(error.ToString());

        }

        private void btnByID_Click(object sender, EventArgs e)
        {
            MessageBox.Show(checkout.returnCheckoutByBook(int.Parse(txtreturnBookID.Text)).ToString());
        }
    }
}
