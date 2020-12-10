using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemberManagement
{
    public partial class frmEdit : Form
    {

        string dBase = "";
        string table = "";
        int userID = 0;

        clsMemberManagement manager = new clsMemberManagement("", "");

        public frmEdit(string _dBase, string _table, int _userID)
        {
            InitializeComponent();

            dBase = _dBase;
            table = _table;
            userID = _userID;

            manager.setDBaseLocation(dBase);
            manager.setTableName(table);

        }

        private void frmEdit_Load(object sender, EventArgs e)
        {

            DataSet member = manager.getData(userID);

            txtFullName.Text = member.Tables[0].Rows[0].ItemArray[1].ToString();
            txtLibraryCard.Text = member.Tables[0].Rows[0].ItemArray[2].ToString();
            cmbGender.SelectedIndex = Convert.ToInt32(bool.Parse(member.Tables[0].Rows[0].ItemArray[3].ToString()));
            dtpBDay.Value = DateTime.Parse(member.Tables[0].Rows[0].ItemArray[4].ToString());
            txtNICNo.Text = member.Tables[0].Rows[0].ItemArray[5].ToString();
            txtTPNo.Text = member.Tables[0].Rows[0].ItemArray[6].ToString();
            txtAddress.Text = member.Tables[0].Rows[0].ItemArray[7].ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int error = manager.editUserData(userID, txtFullName.Text, txtLibraryCard.Text, Convert.ToBoolean(cmbGender.SelectedIndex), dtpBDay.Value, txtNICNo.Text, txtTPNo.Text, txtAddress.Text);

            MessageBox.Show(error.ToString());
            this.Close();

        }
    }
}
