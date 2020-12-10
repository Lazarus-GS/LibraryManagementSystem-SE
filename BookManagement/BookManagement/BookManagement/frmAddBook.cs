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
    public partial class frmAddBook : Form
    {

        clsBookManagement booksManager = new clsBookManagement(@"D:\SLTC\Semester 04\Software Engineering project\Assignments\Assignment Main\My Work\Database\LMS.accdb", "Books");

        public frmAddBook(string _dBaseLocation)
        {
            InitializeComponent();
            booksManager.setDBaseLocation(_dBaseLocation);
        }

        private void frmAddBook_Load(object sender, EventArgs e)
        {

            for (int i = 1; i < frmMain.categoryList.Count; i++)
            {
                cmbCategory.Items.Add(frmMain.categoryList[i].Item2);
            }

            for (int i = 1; i < frmMain.shelfList.Count; i++)
            {
                cmbShelf.Items.Add(frmMain.shelfList[i].Item2);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            int error = booksManager.createBook(txtName.Text, txtAuthor.Text, txtISBN.Text, frmMain.categoryList[cmbCategory.SelectedIndex + 1].Item1, frmMain.shelfList[cmbShelf.SelectedIndex + 1].Item1, txtDesc.Text, "1");
            if (error == 0)
            {
                this.Close();
            }

        }
    }
}
