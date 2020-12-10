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

    public partial class frmAddMember : Form
    {

        string dBase = "";
        string table = "";

        public frmAddMember(string _dBase, string _table)
        {
            InitializeComponent();

            dBase = _dBase;
            table = _table;

        }

        private void frmAddMember_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            clsMemberManagement manager = new clsMemberManagement(dBase, table);
            int error = manager.createMember(txtFullName.Text, txtLibraryCard.Text, Convert.ToBoolean(cmbGender.SelectedIndex), dtpBDay.Value, txtNICNo.Text, txtTPNo.Text, txtAddress.Text);

            MessageBox.Show(error.ToString());
            this.Close();

        }
    }
}
