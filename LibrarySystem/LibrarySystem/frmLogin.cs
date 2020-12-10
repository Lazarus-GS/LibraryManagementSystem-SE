using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; //Library required to access database.
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class frmLogin : Form
    {
        //This is the code for the form.
        private static string dbaseLocation = "C:\\Users\\Acer Nitro 5\\Desktop\\LMS.accdb";

        clsSearch search = new clsSearch(dbaseLocation); //A new instance of clsSearch class is made as search.
        Clssearchmember searchmember = new Clssearchmember(dbaseLocation); //A new instance of clssearchmember class is made as searchmember.

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Exit when Exit button is clicked.
            this.Close();
        }

        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            //Book searched when Search Book button is clicked using the book name entered.
            DataTable dy; // Datatable to store the results returned from the class clsSearch
            Task
                .Run(() => search.search(txtBookname.Text)) // The class is called which takes care of searching for the required book in our database
                .ContinueWith(t =>
                {
                    // Each row of the returned datatable content from the class is output.
                    dy = t.Result;
                    foreach (DataRow row in dy.Rows)
                    {
                        MessageBox.Show(row[0].ToString());
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void buttonSearchMember_Click(object sender, EventArgs e)
        {
            //Member contents searched for when Search Member button is clicked using the Member ID entered.

            (int, DataSet) returnData = searchmember.searchmember(txtBookname.Text);// Datatable to store the results returned from the class Clssearchmember
            if (returnData.Item1 == 0)
            {
                MessageBox.Show("No Users with this ID!");
            }
            else
            {
                MessageBox.Show("User is there!");
            }


        }
    }
}
