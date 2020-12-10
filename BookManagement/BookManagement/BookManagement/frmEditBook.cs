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
    public partial class frmEditBook : Form
    {

        List<Tuple<int, string>> categoryList = new List<Tuple<int, string>>();
        List<Tuple<int, string>> shelfList = new List<Tuple<int, string>>();
        Tuple<string, string, string, int, int, string> bookData = Tuple.Create<string, string, string, int, int, string>("", "", "", 0, 0, "");
        clsBookManagement booksManager = new clsBookManagement("Database/LMS.accdb", "Books");
        clsCategories categoryManager = new clsCategories("Database/LMS.accdb", "Categories");
        clsShelves shelfManager = new clsShelves("Database/LMS.accdb", "Shelves");
        int bookID = 0;

        public frmEditBook(string _dBaseLocation, int _bookID)
        {
            InitializeComponent();
            booksManager.setDBaseLocation(_dBaseLocation);
            bookID = _bookID;
        }

        private void frmEditBook_Load(object sender, EventArgs e)
        {

            categoryList = categoryManager.getList().ToList<Tuple<int, string>>();

            for (int i = 0; i < categoryList.Count; i++)
            {
                cmbCategory.Items.Add(categoryList[i].Item2);
            }

            shelfList = shelfManager.getList().ToList<Tuple<int, string>>();
            for (int i = 0; i < shelfList.Count; i++)
            {
                cmbShelf.Items.Add(shelfList[i].Item2);
            }

            Tuple<string, string, string, string, string, string> book = booksManager.getInfo(bookID);
            DataSet book2 = booksManager.getData(bookID);

            txtName.Text = book.Item1;
            txtAuthor.Text = book.Item2;
            txtISBN.Text = book.Item3;
            txtCategory.Text = book.Item4;
            txtShelf.Text = book.Item5;
            txtDesc.Text = book.Item6;

            bookData = Tuple.Create<string, string, string, int, int, string>(book.Item1, book.Item2, book.Item3, int.Parse(book2.Tables[0].Rows[0].ItemArray[4].ToString()), int.Parse(book2.Tables[0].Rows[0].ItemArray[5].ToString()), book.Item6);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int categoryID = bookData.Item4;
            int shelfID = bookData.Item5;

            if (chkCategory.Checked == true)
            {
                categoryID = categoryList[cmbCategory.SelectedIndex].Item1;
            }
            if (chkShelf.Checked == true)
            {
                shelfID = shelfList[cmbShelf.SelectedIndex].Item1;
            }

            bookData = Tuple.Create<string, string, string, int, int, string>(txtName.Text, txtAuthor.Text, txtISBN.Text, categoryID, shelfID, txtDesc.Text);

            int error = booksManager.editBookData(bookID, bookData.Item1, bookData.Item2, bookData.Item3, bookData.Item4.ToString(), bookData.Item5.ToString(), bookData.Item6, "0");
            if (error == 0)
            {
                this.Close();
            }

        }
    }
}
