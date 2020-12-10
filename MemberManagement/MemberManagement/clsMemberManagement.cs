/*----------------------------------------------
 * 
 * Library Management System v1.0
 * Member Management v1.0
 * MemberManagement.exe
 * Manages all the functions related to Members.
 * 02/12/2020 10:20PM
 * © D.Y.Senanayake
 * 
 * -------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRetrieval;
using System.Data;
using logWriter;

namespace MemberManagement
{
    public class clsMemberManagement
    {

        clsLogWriter logWriter = new clsLogWriter();

        static string dBaseLocation = "";
        static string table = "";
        clsConnection connection = new clsConnection(dBaseLocation, table);

        public static int noFilter = 0;
        public static int filterName = 1;
        public static int filterLibraryID = 2;
        public static int filterNationalID = 3;

        public static string dateFormat = "hh:mm:ss tt MM/dd/yyyy";

        string[] filterList = { "Full_Name", "Library_Card_No", "NIC_No" };

        public static int success = 0;
        public static int fail = 1;

        public static bool male = false;
        public static bool female = true;

        public static int active = 0;
        public static int suspended = 1;

        int filter = noFilter;
        string filterTerm = "";

        public clsMemberManagement(string _dBaseLocation, string _table)
        {

            log("Login initialized with dBaseLocation: " + _dBaseLocation.ToString() + ", Table: " + _table.ToString()); ;

            dBaseLocation = _dBaseLocation;
            table = _table;
            connection.setDBLocation(dBaseLocation);
            connection.setTable(table);

        }

        public DataSet getData()
        {
            log("getData called with no parameters");
            DataSet returnData = null;

            if (filter == noFilter)
            {
                returnData = connection.getData();
            }
            else
            {
                returnData = connection.getData(Tuple.Create<string, string>(filterList[filter - 1], filterTerm), true);
            }
            log("Data returned");
            return returnData;

        }

        public DataSet getData(int iD)
        {
            log("getData called with iD: " + iD.ToString());
            DataSet returnData = null;

            if (filter == noFilter)
            {
                returnData = connection.getData(iD);
            }
            log("Data returned");

            return returnData;

        }

        public static string getNameInitials(string name)
        {

            string returnString = "";

            try
            {
                string[] namesArray = name.Split(' ');

                for (int i = 0; i < (namesArray.Length - 1); i++)
                {
                    returnString += namesArray[i].Substring(0, 1) + ". ";
                }

                returnString += namesArray[namesArray.Length - 1];
            }
            catch
            {

            }

            return returnString;

        }

        public static string getFirstName(string name)
        {

            string returnString = "";

            try
            {
                string[] namesArray = name.Split(' ');

                returnString += namesArray[0];
            }
            catch
            {

            }

            return returnString;

        }

        public static string getLastName(string name)
        {

            string returnString = "";

            try
            {
                string[] namesArray = name.Split(' ');

                returnString += namesArray[namesArray.Length -1];
            }
            catch
            {

            }

            return returnString;

        }

        public static string getGenderString(bool gender)
        {
            string returnString = "";

            if (gender == male)
            {
                returnString = "Male";
            }
            else
            {
                returnString = "Female";
            }

            return returnString;
        }

        public static string getSuspensionString(int suspension)
        {
            string returnString = "";

            if (suspension == suspended)
            {
                returnString = "Suspended";
            }
            else
            {
                returnString = "Active";
            }

            return returnString;
        }

        public string[] getInfo(int iD)
        {
            log("getInfo called with iD " + iD.ToString());
            DataSet member = connection.getData(iD);

            string fullName = member.Tables[0].Rows[0].ItemArray[1].ToString();
            string nameInitials = getNameInitials(fullName);
            string firstName = getFirstName(fullName);
            string lastName = getLastName(fullName);
            string libraryCardNo = member.Tables[0].Rows[0].ItemArray[2].ToString();
            string gender = getGenderString(bool.Parse(member.Tables[0].Rows[0].ItemArray[3].ToString()));
            string bDay = member.Tables[0].Rows[0].ItemArray[4].ToString();
            string nicNo = member.Tables[0].Rows[0].ItemArray[5].ToString();
            string telephoneNo = member.Tables[0].Rows[0].ItemArray[6].ToString();
            string address = member.Tables[0].Rows[0].ItemArray[7].ToString();
            string regDate = member.Tables[0].Rows[0].ItemArray[8].ToString();
            string expDay = member.Tables[0].Rows[0].ItemArray[9].ToString();
            string status = getSuspensionString(int.Parse(member.Tables[0].Rows[0].ItemArray[10].ToString()));

            string[] returnData = { fullName, nameInitials, firstName, lastName, libraryCardNo, gender, bDay, nicNo, telephoneNo, address, regDate, expDay, status };
            log("Data returned");
            return returnData;

        }

        public int createMember(string _fullName, string _cardNo, bool _gender, DateTime _bDay, string _nicNo, string _telephoneNo, string _address)
        {
            log("Create member called");
            int error = 0;
            DateTime regDate = DateTime.Now;

            try
            {
                Tuple<string, string>[] data =
                    { Tuple.Create <string, string> ("Full_Name", "'" + _fullName + "'"),
                Tuple.Create <string, string> ("Library_Card_No", "'" + _cardNo + "'"),
                Tuple.Create <string, string> ("Gender", _gender.ToString()),
                Tuple.Create <string, string> ("Birthday", "'" + _bDay.ToString(dateFormat) + "'"),
                Tuple.Create <string, string> ("NIC_No", "'" + _nicNo + "'"),
                Tuple.Create <string, string> ("Telephone_No", "'" + _telephoneNo + "'"),
                Tuple.Create <string, string> ("Address", "'" + _address + "'"),
                Tuple.Create <string, string> ("Reg_Date", "'" + regDate.ToString(dateFormat) + "'"),
                Tuple.Create <string, string> ("Exp_Date", "'" + calculateExpDate(regDate).ToString(dateFormat) + "'"),
                Tuple.Create <string, string> ("Status", active.ToString())};
                connection.add(data);
                error = success;
                log("Member successfully created");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                error = fail;
            }
            return error;
        }

        public DateTime calculateExpDate(DateTime regDate)
        {
            //Need Work

            return regDate.AddYears(2);
        }

        public Tuple<int, int> returnPenalty(int _userID, int _fee)
        {
            Tuple<int, int> penalty = null;

            DataSet userData = connection.getData(_userID);

            DateTime dueDate = DateTime.Parse(userData.Tables[0].Rows[0].ItemArray[9].ToString());
            DateTime returnDate = DateTime.Now;

            int lateDayCount = lateDays(returnDate, dueDate);
            int penaltyFee = calculatePenalty(_fee, returnDate, dueDate);

            penalty = Tuple.Create<int, int>(lateDayCount, penaltyFee);

            return penalty;
        }

        int calculatePenalty(int penaltyFees, DateTime returnDate, DateTime expectedDate)
        {

            int fee = penaltyFees * lateDays(returnDate, expectedDate);

            if (fee < 0)
            {
                fee = 0;
            }

            return fee;
        }

        int lateDays(DateTime returnDate, DateTime expectedDate)
        {
            return Convert.ToInt32(Math.Ceiling(returnDate.Subtract(expectedDate).TotalDays));
        }

        public void setDBaseLocation(string location)
        {
            log("dBaseLocation set to :" + location);
            dBaseLocation = location;
            connection.setDBLocation(location);
        }

        public void setTableName(string name)
        {
            log("table set to: " + name.ToString());
            table = name;
            connection.setTable(name);
        }

        public void removeFilter()
        {
            log("Filter removed");
            filter = noFilter;
            filterTerm = "";

        }

        public void applyFilter(int filterType, string term)
        {
            log("Filter applied: " + filterType.ToString() + " Term: " + term.ToString());
            filter = filterType;
            filterTerm = term;
        }

        public int editUserData(int _iD, string _fullName, string _cardNo, bool _gender, DateTime _bDay, string _nicNo, string _telephoneNo, string _address)
        {
            log("editUserData called with iD " + _iD.ToString());
            int returnError = success;

            try
            {
                Tuple<string, string>[] data =
                    { Tuple.Create <string, string> ("Full_Name", "'" + _fullName + "'"),
                Tuple.Create <string, string> ("Library_Card_No", "'" + _cardNo + "'"),
                Tuple.Create <string, string> ("Gender", _gender.ToString()),
                Tuple.Create <string, string> ("Birthday", "'" + _bDay.ToString(dateFormat) + "'"),
                Tuple.Create <string, string> ("NIC_No", "'" + _nicNo + "'"),
                Tuple.Create <string, string> ("Telephone_No", "'" + _telephoneNo + "'"),
                Tuple.Create <string, string> ("Address", "'" + _address + "'")};

                connection.update(_iD, data);
                returnError = success;
                log("Successfully edited");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                returnError = fail;
            }

            return returnError;

        }

        public int deleteUser(int _iD)
        {
            log("Delete user called for iD " + _iD.ToString());
            int returnError = success;

            try
            {
                connection.delete(_iD);

                returnError = success;
                log("Successfully deleted");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                returnError = fail;
            }

            return returnError;
        }

        public int suspendUser(int _iD)
        {
            log("suspendUser called for iD " + _iD.ToString());
            int returnError = success;

            try
            {
                Tuple<string, string>[] data =
                    {Tuple.Create <string, string> ("Status", suspended.ToString()),
                    Tuple.Create <string, string> ("Exp_Date", "'" + DateTime.Now.ToString(dateFormat) + "'")};

                connection.update(_iD, data);
                returnError = success;
                log("Successfully suspended");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                returnError = fail;
            }

            return returnError;

        }

        public int renewUser(int _iD)
        {
            log("renewUser called for iD " + _iD.ToString());
            int returnError = success;

            try
            {
                Tuple<string, string>[] data =
                    {Tuple.Create <string, string> ("Exp_Date", "'" + calculateExpDate(DateTime.Now).ToString(dateFormat) + "'"),
                    Tuple.Create <string, string> ("Status", active.ToString())};

                connection.update(_iD, data);
                returnError = success;
                log("Successfully renewed");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                returnError = fail;
            }

            return returnError;

        }

        void log(string data)
        {
            logWriter.newEvent(data);
        }

    }
}
