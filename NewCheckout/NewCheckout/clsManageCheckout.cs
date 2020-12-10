/*----------------------------------------------
 * 
 * Library Management System v1.0
 * Checkout Management v1.0
 * NewCheckout.exe
 * Manages all the functions related to Checkouts.
 * 02/12/2020 10:20PM
 * © K.K.T.N.Kasiwatta
 * © K.I.U.M. Premasirii
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

namespace ManageCheckout
{
    public class clsManageCheckout
    {

        clsLogWriter logWriter = new clsLogWriter();

        static string dBaseLocation = "";
        static string table = "";
        int allowedDays = 0;
        int maxBorrowable = 0;
        int penaltyFees = 0;

        public static string dateFormat = "hh:mm:ss tt MM/dd/yyyy";

        clsConnection connection = new clsConnection(dBaseLocation, table);

        public static int success = 0;
        public static int bookBorrowed = 1;
        public static int userCapped = 2;
        public static int systemError = 3;

        public clsManageCheckout(string _dBaseLocation, string _table, int _allowedDays, int _maxBorrowable, int _penaltyFees)
        {

            log("");
            log("Login initialized with dBaseLocation: " + _dBaseLocation.ToString() + ", table: " + _table);

            dBaseLocation = _dBaseLocation;
            table = _table;
            allowedDays = _allowedDays;
            maxBorrowable = _maxBorrowable;
            penaltyFees = _penaltyFees;
            connection.setDBLocation(_dBaseLocation);
            connection.setTable(_table);

        }

        public void setDBaseLocation(string _dBaseLocation)
        {
            log("dBaseLocation changed to " + _dBaseLocation.ToString());
            dBaseLocation = _dBaseLocation;
            connection.setDBLocation(_dBaseLocation);
        }

        public void setTable(string _table)
        {
            log("table changed to " + _table.ToString());
            table = _table;
            connection.setTable(_table);
        }

        public void setAllowedDays(int _allowedDays)
        {
            log("Allowed days set to " + _allowedDays.ToString());
            allowedDays = _allowedDays;
        }

        public void setMaxBorrowable(int _maxBorrowable)
        {
            log("maxBorrowable set to " + _maxBorrowable.ToString());
            maxBorrowable = _maxBorrowable;
        }

        public void setPenaltyFees(int _penaltyFees)
        {
            log("penaltyFees set to " + _penaltyFees.ToString());
            penaltyFees = _penaltyFees;
        }

        public int getAllowedDays()
        {
            return allowedDays;
        }

        public int getMaxBorrowable()
        {
            return maxBorrowable;
        }

        public int getPenaltyFees()
        {
            return penaltyFees;
        }

        public bool bookAvailable(int bookID)
        {

            bool bookAvailable = false;

            Tuple<string, string> retrievalData = Tuple.Create<string, string>("Book", bookID.ToString());

            DataSet data = connection.getData(retrievalData, false);

            if (data.Tables[0].Rows.Count == 0)
            {
                bookAvailable = true;
            }
            else
            {
                bookAvailable = false;
            }

            return bookAvailable;

        }

        public DataSet returnUserBooks(int userID)
        {
            Tuple<string, string> retrievalData = Tuple.Create<string, string>("Member", userID.ToString());

            return connection.getData(retrievalData, false);
        }

        public int userBookCount(int userID)
        {

            DataSet data = returnUserBooks(userID);

            return data.Tables[0].Rows.Count;

        }

        public bool userEligible(int userID)
        {

            bool eligible = false;

            if (userBookCount(userID) < maxBorrowable)
            {
                eligible = true;
            }
            else
            {
                eligible = false;
            }

            return eligible;
        }

        public string bookCheckout(int bookID, int userID)
        {
            string returnDate = "";

            log("Checkout for User: " + userID.ToString() + ", Book: " + bookID.ToString());

            if (bookAvailable(bookID) == false)
            {
                log("Book borrowed");
            }
            else if (userEligible(userID) == false)
            {
                log("User not eligible");
            }
            else
            {

                try
                {
                    DateTime regDate = DateTime.Now;

                    Tuple<string, string>[] data =
                        { Tuple.Create <string, string> ("Member", userID.ToString()),
                    Tuple.Create <string, string> ("Book", bookID.ToString()),
                    Tuple.Create <string, string> ("Issue_Date", "'" + regDate.ToString(dateFormat) + "'"),
                    Tuple.Create <string, string> ("Due_Date", "'" + calculateExpDate(regDate).ToString(dateFormat) + "'")};
                    connection.add(data);

                    returnDate = calculateExpDate(regDate).ToString("dd/MM/yyyy");
                    log("Successfully logged out");
                }
                catch(Exception e)
                {
                    log("Failed. Error: " + e.Message.ToString());
                }

            }

            return returnDate;

        }

        public Tuple<int, int> checkPenalties(int checkoutID)
        {
            Tuple<int, int> penalty = null;

            DataSet checkout = connection.getData(checkoutID);

            DateTime dueDate = DateTime.Parse(checkout.Tables[0].Rows[0].ItemArray[4].ToString());
            DateTime returnDate = DateTime.Now;

            int lateDayCount = lateDays(returnDate, dueDate);
            int penaltyFee = calculatePenalty(returnDate, dueDate);

            penalty = Tuple.Create<int, int>(lateDayCount, penaltyFee);

            return penalty;
        }

        public int getCheckoutIDByBook(int bookID)
        {
            log("Return checkoutID for bookID " + bookID.ToString());
            int error = success;

            try
            {
                Tuple<string, string> filter = Tuple.Create<string, string>("Book", bookID.ToString());

                DataSet checkout = connection.getData(filter);

                if (checkout.Tables[0].Rows.Count < 1)
                {
                    error = -1;
                }
                else
                {
                    error = int.Parse(checkout.Tables[0].Rows[0].ItemArray[0].ToString());
                    //error = returnCheckout(int.Parse(checkout.Tables[0].Rows[0].ItemArray[0].ToString()));
                }

                log("Successfully returned");
            }
            catch (Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                error = -1;
            }
            return error;

        }

        public int returnCheckoutByBook(int bookID)
        {
            log("Return checkout for bookID " + bookID.ToString());
            int error = success;

            try
            {
                Tuple<string, string> filter = Tuple.Create<string, string>("Book", bookID.ToString());

                DataSet checkout = connection.getData(filter);

                if (checkout.Tables[0].Rows.Count < 1)
                {
                    error = -1;
                }
                else
                {
                    //error = int.Parse(checkout.Tables[0].Rows[0].ItemArray[0].ToString());
                    error = returnCheckout(int.Parse(checkout.Tables[0].Rows[0].ItemArray[0].ToString()));
                }

                log("Successfully returned");
            }
            catch (Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                error = systemError;
            }
            return error;

        }

        public int returnCheckout(int checkoutID)
        {
            log("Return checkout for checkoutID " + checkoutID.ToString());
            int error = success;

            try
            {

                DataSet checkout = connection.getData(checkoutID);

                DateTime dueDate = DateTime.Parse(checkout.Tables[0].Rows[0].ItemArray[4].ToString());
                DateTime returnedDate = DateTime.Now;

                Tuple<string, string>[] checkoutData =
                    { Tuple.Create <string, string> ("Issue_ID", checkout.Tables[0].Rows[0].ItemArray[0].ToString()),
                    Tuple.Create <string, string> ("Member", checkout.Tables[0].Rows[0].ItemArray[1].ToString()),
                    Tuple.Create <string, string> ("Book", checkout.Tables[0].Rows[0].ItemArray[2].ToString()),
                    Tuple.Create <string, string> ("Issue_Date", "'" + checkout.Tables[0].Rows[0].ItemArray[3].ToString() + "'"),
                    Tuple.Create <string, string> ("Due_Date", "'" + dueDate.ToString(dateFormat) + "'")};

                List<Tuple<string, string>> historyData = new List<Tuple<string, string>>();

                historyData.AddRange(checkoutData);
                historyData.Add(Tuple.Create<string, string>("Returned_Date", "'" + returnedDate.ToString(dateFormat) +"'"));
                historyData.Add(Tuple.Create<string, string>("Paid_Fee", calculatePenalty(returnedDate, dueDate).ToString()));

                clsConnection historyConnection = new clsConnection(dBaseLocation, "Issue_History");

                historyConnection.add(historyData.ToArray());
                connection.delete(checkoutID);

                error = success;
                log("Successfully returned");
        }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                error = systemError;
            }

            return error;

        }

        public int extendTime(int checkoutID, int extendDays)
        {
            log("Extend time called for checkoutID: " + checkoutID.ToString() + " for days: " + extendDays.ToString());
            int error = systemError;

            try
            {
                DateTime returnDate = getData(checkoutID).Item4.AddDays(extendDays);
                Tuple<string, string>[] data =
                     { Tuple.Create<string, string>("Due_Date", "'" + returnDate.ToString(dateFormat) + "'") };
                connection.update(checkoutID, data);
                error = success;
                log("Successfully extended");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                error = systemError;
            }

            return error;
        }

        public int extendTimeByBook(int bookID, int extendDays)
        {
            log("Extend time for bookID " + bookID.ToString());
            int error = success;

            try
            {
                Tuple<string, string> filter = Tuple.Create<string, string>("Book", bookID.ToString());

                DataSet checkout = connection.getData(filter);

                if (checkout.Tables[0].Rows.Count < 1)
                {
                    error = -1;
                }
                else
                {
                    //error = int.Parse(checkout.Tables[0].Rows[0].ItemArray[0].ToString());
                    error = extendTime(int.Parse(checkout.Tables[0].Rows[0].ItemArray[0].ToString()), extendDays);
                }

                log("Successfully extended");
            }
            catch (Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                error = systemError;
            }
            return error;

        }

        public Tuple<int, int, DateTime, DateTime> getData(int checkoutID)
        {
            log("getData called for checkoutID " + checkoutID.ToString());
            Tuple<int, int, DateTime, DateTime> returnData = null;

            DataSet checkout = connection.getData(checkoutID);

            returnData =
                    Tuple.Create<int, int, DateTime, DateTime>(int.Parse(checkout.Tables[0].Rows[0].ItemArray[1].ToString()),
                    int.Parse(checkout.Tables[0].Rows[0].ItemArray[2].ToString()),
                    DateTime.Parse(checkout.Tables[0].Rows[0].ItemArray[3].ToString()),
                    DateTime.Parse(checkout.Tables[0].Rows[0].ItemArray[4].ToString()));

            log("Data returned");
            return returnData;
        }

        public DataSet getData()
        {
            log("getData called with no parameters");
            log("Data returned");
            return connection.getData();

        }

        public Tuple<string, string, string, string> getInfo(int checkoutID)
        {
            log("getInfo called for checkoutID " + checkoutID.ToString());
            Tuple<string, string, string, string> returnData = null;

            Tuple<int, int, DateTime, DateTime> infoList = getData(checkoutID);

            clsConnection bookConnection = new clsConnection(dBaseLocation, "Books");
            clsConnection userConnection = new clsConnection(dBaseLocation, "Members");

            string bookName = bookConnection.getData(infoList.Item2).Tables[0].Rows[0].ItemArray[1].ToString();
            string userName = userConnection.getData(infoList.Item1).Tables[0].Rows[0].ItemArray[1].ToString();

            returnData = Tuple.Create<string, string, string, string>
                (userName, bookName, infoList.Item3.ToString("dd/MM/yyyy"), infoList.Item4.ToString("dd/MM/yyyy"));

            log("Data returned");
            return returnData;
        }

        public DateTime calculateExpDate(DateTime regDate)
        {
            //Need Work

            return regDate.AddDays(allowedDays);
        }

        public int lateDays(DateTime returnDate, DateTime expectedDate)
        {
            return Convert.ToInt32(Math.Ceiling(returnDate.Subtract(expectedDate).TotalDays));
        }

        public int calculatePenalty(DateTime returnDate, DateTime expectedDate)
        {

            int fee = penaltyFees * lateDays(returnDate, expectedDate);

            if (fee < 0)
            {
                fee = 0;
            }

            return fee;
        }

        void log(string data)
        {
            logWriter.newEvent(data);
        }

    }
}
