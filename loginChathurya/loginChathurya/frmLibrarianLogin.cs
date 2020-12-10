using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginLibrarian
{
    public partial class frmLibrarianLogin : Form
    {

        const string librarianDBase = "librarianDBase.enc";//Location of librarian database. This is an encrypted file.
        const string hashKey = "sblw-3hn8-sqoy19";//Key should be either of 128 bit or of 192 bit

        Tuple<int, string> loggedLibrarian = null;//Current logged librarian.

        clsLogin librarianLogin = new clsLogin(librarianDBase, hashKey);//Calling the librarian class.

        public frmLibrarianLogin()
        {
            InitializeComponent();
        }

        private void clsLibrarianLogin_Load(object sender, EventArgs e)
        {
            
            lsbUsers.Items.AddRange(librarianLogin.allUsers());
            try
            {
                lsbUsers.SelectedIndex = 0;
            }
            catch
            {

            }
            this.Text = "Login Form - " + loggedLibrarian;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (loggedLibrarian == null)
            {
                int error = librarianLogin.loginUser(lsbUsers.SelectedIndex, txtPWord.Text);
                showMessage(error);
                if (error == 0)
                {
                    loggedLibrarian = Tuple.Create<int, string>(lsbUsers.SelectedIndex, librarianLogin.getUName(lsbUsers.SelectedIndex));
                    lblLogin.Text = "Welcome back " + loggedLibrarian.Item2;
                    //btnLogin.Enabled = false;
                }
            }
            else
            {
                lblLogin.Text = "Please logout to login as other user.";
            }
            this.Text = "Login Form - " + loggedLibrarian;
        }

        private void lsbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtUname.Text = lsbUsers.SelectedItem.ToString();
                txtPWord.Text = "";
            }
            catch
            {
                btnLogin.Enabled = false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            if (loggedLibrarian != null)//Tuple.Create<int, string> (0, ""))
            {
                int error = librarianLogin.addUser(txtUname.Text, txtPWord.Text);

                if (error == clsLogin.success)
                {
                    lsbUsers.Items.Clear();
                    lsbUsers.Items.AddRange(librarianLogin.allUsers());
                    loggedLibrarian = Tuple.Create(lsbUsers.SelectedIndex, librarianLogin.getUName(lsbUsers.SelectedIndex));
                    lblLogin.Text = "User " + loggedLibrarian.Item2 + " registered successfully";
                }
                else
                {
                    showMessage(error);
                }
            }
            else
            {
                MessageBox.Show("Please login to register a new user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (loggedLibrarian != null)
            {
                loggedLibrarian = null;
                lblLogin.Text = "Logged out.";
            }
            else
            {
                lblLogin.Text = "You are already logged out.";
            }
            this.Text = "Login Form - " + loggedLibrarian;
        }

        private void btnChangePword_Click(object sender, EventArgs e)
        {
            if (loggedLibrarian != null)
            {
                int error = librarianLogin.changePWord(loggedLibrarian.Item1, txtnewpword.Text, txtPWord.Text);
                showMessage(error);
                if (error == 0)
                {
                    loggedLibrarian = Tuple.Create<int, string>(lsbUsers.SelectedIndex, librarianLogin.getUName(lsbUsers.SelectedIndex));
                    lblLogin.Text = loggedLibrarian.Item2 + ", your password changed. Login back again.";
                    loggedLibrarian = null;
                }
            }
            else
            {
                lblLogin.Text = "You have to be logged in to change the password.";
            }
            this.Text = "Login Form - " + loggedLibrarian;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (loggedLibrarian != null)
            {
                int error = librarianLogin.deleteUser(lsbUsers.SelectedIndex, txtPWord.Text);
                showMessage(error);
                if (error == clsLogin.success)
                {
                    lblLogin.Text = "User deleted. Login with another user.";
                    loggedLibrarian = null;
                    lsbUsers.Items.Clear();
                    lsbUsers.Items.AddRange(librarianLogin.allUsers());
                    this.Text = "Login Form - " + loggedLibrarian;
                    try
                    {
                        lsbUsers.SelectedIndex = 0;
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                lblLogin.Text = "You have to be logged into your account to delete it.";
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showMessage(int errorID)
        {
            lblLogin.BackColor = Color.Red;
            if (errorID == clsLogin.unknownError)
            {
                MessageBox.Show("An unsexpected error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (errorID == clsLogin.invalidCharError)
            {
                MessageBox.Show("You have entered an unacceptable character. Do not include |, \\ in username or password. Also, do not leave them empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (errorID == clsLogin.reuseError)
            {
                MessageBox.Show("Username already exist, please user another name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (errorID == clsLogin.wrongPWordError)
            {
                MessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (errorID == clsLogin.adminUser)
            {
                MessageBox.Show("Cannot delete the admin user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                lblLogin.BackColor = Color.Green;
            }

        }
    }
}