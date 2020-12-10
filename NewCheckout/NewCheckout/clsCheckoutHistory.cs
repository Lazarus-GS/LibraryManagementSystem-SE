/*----------------------------------------------
 * 
 * Library Management System v1.0
 * Checkout Management v1.0
 * NewCheckout.exe
 * Manages all the functions related to Checkouts.
 * 02/12/2020 10:20PM
 * © K.K.T.N.Kasiwatta
 * © K.I.U.M. Premasiri
 * 
 * -------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataRetrieval;
using logWriter;

namespace NManageCheckout
{
    public class clsCheckoutHistory
    {

        clsLogWriter logWriter = new clsLogWriter();

        static string dBaseLocation = "";
        static string table = "";

        public static string dateFormat = "hh:mm:ss tt MM/dd/yyyy";

        clsConnection connection = new clsConnection(dBaseLocation, table);

        public static int success = 0;
        public static int bookBorrowed = 1;
        public static int userCapped = 2;
        public static int systemError = 3;

        public clsCheckoutHistory(string _dBaseLocation, string _table)
        {

            log("");
            log("Login initialized with dBaseLocation: " + _dBaseLocation.ToString() + ", table: " + _table);

            dBaseLocation = _dBaseLocation;
            table = _table;
            connection.setDBLocation(_dBaseLocation);
            connection.setTable(_table);

        }

        public void setDBaseLocation(string _dBaseLocation)
        {
            log("dBaseLocation changed to '" + _dBaseLocation.ToString() + "'");
            dBaseLocation = _dBaseLocation;
            connection.setDBLocation(_dBaseLocation);
        }

        public void setTable(string _table)
        {
            log("table changed to '" + _table.ToString() + "'");
            table = _table;
            connection.setTable(_table);
        }

        public DataSet getData()
        {
            log("getData called with no parameters");
            log("Data returned");
            return connection.getData();

        }

        public Tuple<int, int, int, DateTime, DateTime, DateTime, int> getData(int checkoutID)
        {

            log("getData called with checkoutID " + checkoutID.ToString());
            Tuple<int, int, int, DateTime, DateTime, DateTime, int> returnData = null;

            DataSet checkout = connection.getData(checkoutID);

            returnData =
                    Tuple.Create<int, int, int, DateTime, DateTime, DateTime, int>(int.Parse(checkout.Tables[0].Rows[0].ItemArray[1].ToString()),
                    int.Parse(checkout.Tables[0].Rows[0].ItemArray[2].ToString()),
                    int.Parse(checkout.Tables[0].Rows[0].ItemArray[3].ToString()),
                    DateTime.Parse(checkout.Tables[0].Rows[0].ItemArray[4].ToString()),
                    DateTime.Parse(checkout.Tables[0].Rows[0].ItemArray[5].ToString()),
                    DateTime.Parse(checkout.Tables[0].Rows[0].ItemArray[6].ToString()),
                    int.Parse(checkout.Tables[0].Rows[0].ItemArray[6].ToString()));
            log("Data returned");
            return returnData;
        }

        public Tuple<string, string, string, string, string, string, string> getInfo(int checkoutID)
        {
            log("getInfo called with checkoutID " + checkoutID.ToString());
            Tuple<string, string, string, string, string, string, string> returnData = null;

            Tuple<int, int, int, DateTime, DateTime, DateTime, int> infoList = getData(checkoutID);

            clsConnection bookConnection = new clsConnection(dBaseLocation, "Books");
            clsConnection userConnection = new clsConnection(dBaseLocation, "Members");

            string bookName = bookConnection.getData(infoList.Item2).Tables[0].Rows[0].ItemArray[1].ToString();
            string userName = userConnection.getData(infoList.Item1).Tables[0].Rows[0].ItemArray[1].ToString();

            returnData = Tuple.Create<string, string, string, string, string, string, string>
                (infoList.Item1.ToString(), userName, bookName, infoList.Item4.ToString("dd/MM/yyyy"), infoList.Item5.ToString("dd/MM/yyyy"), infoList.Item6.ToString("dd/MM/yyyy"), infoList.Item7.ToString());
            log("Returned successfully");
            return returnData;
        }

        public DataSet returnUserBooks(int userID)
        {
            log("returnUserBooks called with userID " + userID.ToString());
            Tuple<string, string> retrievalData = Tuple.Create<string, string>("Member", userID.ToString());

            log("Data returned");
            return connection.getData(retrievalData, false);
        }

        public DataSet returnBookCheckouts(int bookID)
        {
            log("returnBookCheckout called with bookID " + bookID.ToString());
            Tuple<string, string> retrievalData = Tuple.Create<string, string>("Book", bookID.ToString());

            log("Successfully returned");
            return connection.getData(retrievalData, false);
        }

        void log(string data)
        {
            logWriter.newEvent(data);
        }

    }
}
