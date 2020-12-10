/*----------------------------------------------
 * 
 * Library Management System v1.0
 * Library System v1.0
 * LoginLibrarian.exe
 * Manages all the functions related to Members.
 * 02/12/2020 10:20PM
 * © W.M.A.A.Sovis
 * 
 * -------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb; //Library to access database which is vital
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace LibrarySystem
{
    class Clssearchmember
    {
        //Search member class. All the variables and functions needed to search for the required member is within this class.
        string dbaseLocation = "";

        public Clssearchmember(string _dbaseLocation)
        {
            //Parameters to accept when creating the class. Location of the database is accepted and assigned to
            //the variable.
            dbaseLocation = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + _dbaseLocation + "; Persist Security Info = False;";
        }

        public (int, DataSet) searchmember(string MemberID)
        {

            //Create a new data table to hold the data sent by the database.
            DataSet d = new DataSet();

            //Created a tuple to return data. Tuple is a variable type that can hold multiple variables.
            //(int, DataTable) means a new variable type with an int and a DataTable.
            //int holds the state of the return. If 0, then no user is there.
            //If 1, then a user is there and his details are returned in the DataTable.
            (int, DataSet) returnTuple = (0, d);

            //Function that searches for the member. Accepts the member ID that is entered in the textbox on the form
            OleDbConnection con = new OleDbConnection(dbaseLocation);
            con.Open();

            //Create a new command to the database to extract if the member ID matches to the ID entered in the textbox
            // i.e. returns a count.
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM MEMBER_TABLE WHERE ID_MEMBER=" + MemberID, con);

            //da is asked to fill the data table d with the data that database sent.
            da.Fill(d);

            // Checking if there is any record that is available in the data table d. Note that there is only a record available if the member ID entered
            // in the text box matches with that of the member ID available in our database.

            //If there are no rows in the returned table, there is no user.
            //If there are rows, then there is a user and it is added to the returned table.
            if (d.Tables[0].Rows.Count > 0)
            {
                returnTuple.Item1 = 1;
                returnTuple.Item2 = d;
            }

            con.Close();
            con.Dispose();

            //Data is returned.
            return returnTuple;
        }
    }
}
