using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class frmCategories : Form
    {

        clsShelves categoryManager = new clsShelves("Database/LMS.accdb", "Shelves");

        public frmCategories()
        {
            InitializeComponent();
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {

            dgvMain.DataSource = categoryManager.getData().Tables[0].DefaultView;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            MessageBox.Show(categoryManager.addShelf(txtAddTitle.Text, txtAddDesc.Text).ToString());
            dgvMain.DataSource = categoryManager.getData().Tables[0].DefaultView;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            MessageBox.Show(categoryManager.editShelf(int.Parse(dgvMain.Rows[dgvMain.SelectedRows[0].Index].Cells[0].Value.ToString()), txtEditName.Text, txtEditDesc.Text).ToString());
            dgvMain.DataSource = categoryManager.getData().Tables[0].DefaultView;

        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEditName.Text = dgvMain.Rows[dgvMain.SelectedRows[0].Index].Cells[1].Value.ToString();
            txtEditDesc.Text = dgvMain.Rows[dgvMain.SelectedRows[0].Index].Cells[2].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(categoryManager.deleteShelf(int.Parse(dgvMain.Rows[dgvMain.SelectedRows[0].Index].Cells[0].Value.ToString())).ToString());
            dgvMain.DataSource = categoryManager.getData().Tables[0].DefaultView;
        }
    }
}
