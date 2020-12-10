/*----------------------------------------------
 * 
 * Library Management System v1.0
 * Book Management v1.0
 * BookManagement.exe
 * Manages all the functions related to books.
 * 02/12/2020 10:20PM
 * © J.G.D.T.Jamburegoda
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

namespace BookManagement
{
    public class clsShelves
    {

        clsLogWriter logWriter = new clsLogWriter();

        static string dBaseLocation = "";
        static string table = "";
        clsConnection connection = new clsConnection(dBaseLocation, table);

        public static int success = 0;
        public static int fail = 1;
        public static int singleError = 2;

        public clsShelves(string _dBaseLocation, string _table)
        {

            log("");
            log("Initialized Shelf Management with databaselocation '" + _dBaseLocation.ToString() + "' and table '" + _table.ToString() + "'");
            dBaseLocation = _dBaseLocation;
            table = _table;
            connection.setDBLocation(dBaseLocation);
            connection.setTable(table);

        }

        public void setDBaseLocation(string location)
        {
            log("Database location set to '" + location.ToString() + "'");
            dBaseLocation = location;
            connection.setDBLocation(location);
        }

        public void setTableName(string name)
        {
            log("Table name set to '" + name.ToString() + "'");
            table = name;
            connection.setTable(name);
        }

        public DataSet getData()
        {
            log("getData called with no parameters");
            DataSet returnData = connection.getData();

            return returnData;

        }

        public Tuple<int, string>[] getList()
        {
            log("getList called");
            DataSet data = connection.getData();

            List<Tuple<int, string>> shelfList = new List<Tuple<int, string>>();
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
            {
                shelfList.Add(Tuple.Create<int, string>(int.Parse(data.Tables[0].Rows[i].ItemArray[0].ToString()), data.Tables[0].Rows[i].ItemArray[1].ToString()));
            }
            log("Data returned");

            return shelfList.ToArray();

        }

        public int addShelf(string _name, string _description)
        {
            log("addShelf called");
            int error = success;

            try
            {
                Tuple<string, string>[] data =
                    { Tuple.Create <string, string> ("Shelf_Name", "'" + _name + "'"),
                Tuple.Create <string, string> ("Description", "'" + _description + "'")};
                connection.add(data);
                error = success;
                log("Successfully added");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                error = fail;
            }

            return error;

        }

        public int editShelf(int _iD, string _name, string _description)
        {
            log("editShelf called with iD: " + _iD.ToString());
            int returnError = success;

            try
            {
                Tuple<string, string>[] data =
                        { Tuple.Create <string, string> ("Shelf_Name", "'" + _name + "'"),
                Tuple.Create <string, string> ("Description", "'" + _description + "'")};

                connection.update(_iD, data);
                returnError = success;
                log("Added successfully");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                returnError = fail;
            }

            return returnError;

        }

        public int deleteShelf(int _iD)
        {
            log("deleteShelf called with iD " + _iD.ToString());
            int returnError = success;

            try
            {
                if (getData().Tables[0].Rows.Count > 1)
                {
                    connection.delete(_iD);
                    returnError = success;
                }
                else
                {
                    returnError = singleError;
                }
                log("Deleted successfully");
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
