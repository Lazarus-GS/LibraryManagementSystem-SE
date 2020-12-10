using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; //Library to access database which is vital
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;  //Library to access database which is vital

namespace LibrarySystem
{
    class clsSearch
    {
        //Search Books class. All the variables and functions needed to search the required book entered is within this class.
        string dbaseLocation = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chathurya\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30";

        public clsSearch(string _dbaseLocation)
        {
            //Parameters to accept when creating the class. Location of the database is accepted and assigned to
            //the variable.
            dbaseLocation = _dbaseLocation;
        }

        //Function that searches for the book. Accepts the book name that is entered in the textbox on the form
        public DataTable search(string Bookname)
        {
            //Creates a new connection to a database called 'con' which is of type SqlConnection.
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chathurya\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30");
            
            //Create a new command to the database to extract if the book name matches to the name entered in the textbox
            // i.e. returns a count.
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from BOOKS_TABLE where BOOK_TITLE='" + Bookname + " '", con);
            
            //Create a new data table to hold the data sent by the database.
            DataTable d = new DataTable();
            
            //da is asked to fill the data table d with the data that database sent.
            da.Fill(d);

            // Checking if there is any record that is available in the data table d. Note that there is only a record available if the book name entered
            // in the text box matches with that of the name of the book available in our database.
            if (d.Rows[0][0].ToString() == "1")
            {
                // Note: In the table all columns are set to varchar(50) as we work with strings
                //Create a new command to the database to extract the entire record with book name matching.
                SqlDataAdapter sda = new SqlDataAdapter("Select 'Book Found'+'\n' + 'Book Details:'+'\n' +'Book ID: '+ ID_BOOK+ '\n' +'Title: '+ BOOK_TITLE + '\n' +'Author: ' + BOOK_AUTHOR + '\n'+'ISBN no: '+ ISBN +'\n'+ 'Category: '+ CATEGORY from BOOKS_TABLE where BOOK_TITLE='" + Bookname + " '", con);

                //Create a new data table to hold the data sent by the database.
                DataTable dt = new DataTable();

                //sda is asked to fill the data table dt with the data that database sent.
                sda.Fill(dt);

                // Returns the datatable to the main class if a record exists.
                return dt;
            }
            // If the entered book name in the text box does not match to any book title in our database the following runs.
            // Display that the Book is not found.
            else
            {
                //Create a new data table to hold data
                DataTable error = new DataTable();

                // Clear all the records before adding in the new information
                error.Clear();

                // Add a column called Message to our datatable
                error.Columns.Add("Message");

                //  Initiate a new record in our error datatable
                DataRow _message = error.NewRow();

                // Pass a record called Book not found under the table column Message
                _message["Message"] = "Book not found";

                // Add the record to the table 
                error.Rows.Add(_message);

                // Returns the datatable to the main class if a record does not exist.
                // We return a datatable because our class type is datatable.
                return error;
            }
            //Once all the work from the database is done, connection is closed and disposed.
            con.Close();
            con.Dispose();
        }
    }
}
