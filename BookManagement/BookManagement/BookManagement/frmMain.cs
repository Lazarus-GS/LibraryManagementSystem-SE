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
    public partial class frmMain : Form
    {

        public static List<Tuple<int, string>> categoryList = new List<Tuple<int, string>>();
        public static List<Tuple<int, string>> shelfList = new List<Tuple<int, string>>();

        clsBookManagement booksManager = new clsBookManagement(@"D:\SLTC\Semester 04\Software Engineering project\Assignments\Assignment Main\My Work\Database\LMS.accdb", "Books");

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            booksManager.removeFilter();
            dgvBooks.DataSource = booksManager.getData().Tables[0].DefaultView;

            shelfList = booksManager.getShelfFilters().ToList<Tuple<int, string>>();
            categoryList = booksManager.getCategoryFilters().ToList<Tuple<int, string>>();
            for (int i = 0; i < categoryList.Count; i++)
            {
                cmbCategory.Items.Add(categoryList[i].Item2);
            }
            cmbCategory.SelectedIndex = 0;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                booksManager.applyFilter(Convert.ToInt32(rdbName.Checked) + (Convert.ToInt32(rdbAuthor.Checked) * 2) + (Convert.ToInt32(rdbISBN.Checked) * 3), "'%" + txtSearch.Text + "%'");
            }
            else
            {
                booksManager.removeFilter();
            }

            dgvBooks.DataSource = booksManager.getData().Tables[0].DefaultView;
        }

        private void rdbName_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbAuthor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbISBN_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            frmAddBook addNewBook = new frmAddBook(@"D:\SLTC\Semester 04\Software Engineering project\Assignments\Assignment Main\My Work\Database\LMS.accdb");
            addNewBook.ShowDialog();
            dgvBooks.DataSource = booksManager.getData().Tables[0].DefaultView;
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {

            frmCategories categoryForm = new frmCategories();
            categoryForm.ShowDialog();

        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            frmEditBook edit = new frmEditBook("Database/LMS.accdb", int.Parse(dgvBooks.Rows[dgvBooks.SelectedRows[0].Index].Cells[0].Value.ToString()));
            edit.ShowDialog();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbCategory.SelectedIndex == 0)
            {
                booksManager.removeFilter();
            }
            else
            {
                booksManager.applyCategoryFilter(categoryList[cmbCategory.SelectedIndex].Item1);
            }
            dgvBooks.DataSource = booksManager.getData().Tables[0].DefaultView;

        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            MessageBox.Show(booksManager.deleteBook(int.Parse(dgvBooks.Rows[dgvBooks.SelectedRows[0].Index].Cells[0].Value.ToString())).ToString());
            dgvBooks.DataSource = booksManager.getData().Tables[0].DefaultView;
        }
    }
}
