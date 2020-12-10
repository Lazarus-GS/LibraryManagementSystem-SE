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

    public class clsBookManagement
    {

        clsLogWriter logWriter = new clsLogWriter();

        List<Tuple<int, string>> categoryList = new List<Tuple<int, string>>();
        List<Tuple<int, string>> shelfList = new List<Tuple<int, string>>();

        static string dBaseLocation = "";
        static string table = "";
        clsConnection connection = new clsConnection(dBaseLocation, table);
        clsConnection categories = new clsConnection(dBaseLocation, "Categories");
        clsConnection shelves = new clsConnection(dBaseLocation, "Shelves");

        public static int noFilter = 0;
        public static int filterName = 1;
        public static int filterAuthor = 2;
        public static int filterISBN = 3;
        public static int filterCategory = 4;
        public static int filterShelf = 5;

        public static int available = 0;
        public static int maintenance = 1;

        string[] filterList = { "Title", "Author", "ISBN" };

        public static int success = 0;
        public static int fail = 1;

        int filter = noFilter;
        string filterTerm = "";
        int categoryFilter = 0;
        int shelfFilter = 0;

        public clsBookManagement(string _dBaseLocation, string _table)
        {

            log("");
            log("Initialized Book Management with databaselocation '" + _dBaseLocation.ToString() + "' and table '" + _table.ToString() + "'");

            dBaseLocation = _dBaseLocation;
            table = _table;
            connection.setDBLocation(dBaseLocation);
            connection.setTable(table);
            categories.setDBLocation(dBaseLocation);
            shelves.setDBLocation(dBaseLocation);
            getCategoryFilters();
            getShelfFilters();

        }

        public DataSet getData()
        {

            log("Called getData with no parameters");

            DataSet returnData = null;

            if (filter == noFilter)
            {
                log("No filter applied");
                returnData = connection.getData();
            }
            else if (filter == filterCategory)
            {
                log("Category filter applied");
                returnData = connection.getData(Tuple.Create<string, string>("Category", categoryFilter.ToString()), true);
            }
            else if (filter == filterShelf)
            {
                log("Shelf filter applied");
                returnData = connection.getData(Tuple.Create<string, string>("Shelf", shelfFilter.ToString()), true);
            }
            else
            {
                log("Filter applied: " + filterList[filter - 1] + ", " + filterTerm);
                returnData = connection.getData(Tuple.Create<string, string>(filterList[filter -1], filterTerm), true);
            }
            log("Successfully returned");

            return returnData;

        }

        public DataSet getData(int iD)
        {
            log("Called getData with iD parameter: " + iD.ToString());
            DataSet returnData = null;

            if (filter == noFilter)
            {
                returnData = connection.getData(iD);
            }
            log("data returned successfully");

            return returnData;

        }

        public Tuple<string, string, string, string, string, string> getInfo(int iD)
        {
            log("getInfo called with iD parameter: " + iD.ToString());

            DataSet book = connection.getData(iD);

            string title = book.Tables[0].Rows[0].ItemArray[1].ToString();
            string author = book.Tables[0].Rows[0].ItemArray[2].ToString();
            string isbn = book.Tables[0].Rows[0].ItemArray[3].ToString();
            string category = "";
            string shelf = "";
            string description = book.Tables[0].Rows[0].ItemArray[6].ToString();
            try
            {
                for (int i = 0; i < categoryList.Count; i++)
                {
                    if (categoryList[i].Item1 == int.Parse(book.Tables[0].Rows[0].ItemArray[4].ToString()))
                    {
                        category = categoryList[i].Item2;
                    }
                }
            }
            catch
            {
                category = "No Category";
            }
            try
            {
                for (int i = 0; i < shelfList.Count; i++)
                {
                    if (shelfList[i].Item1 == int.Parse(book.Tables[0].Rows[0].ItemArray[5].ToString()))
                    {
                        shelf = shelfList[i].Item2;
                    }
                }
            }
            catch
            {
                shelf = "No Category";
            }

            Tuple<string, string, string, string, string, string> returnData = Tuple.Create<string, string, string, string, string, string>(title, author, isbn, category, shelf, description);

            log("Data returned successfully");

            return returnData;

        }

        public int createBook(string _title, string _author, string _ISBN, int _categoryID, int _shelfID, string _description, string _status)
        {
            log("createBook called");
            int error = 0;
            try
            {
                Tuple<string, string>[] data =
                    { Tuple.Create <string, string> ("Title", "'" + _title + "'"),
                Tuple.Create <string, string> ("Author", "'" + _author + "'"),
                Tuple.Create <string, string> ("ISBN", "'" + _ISBN + "'"),
                Tuple.Create <string, string> ("Category", _categoryID.ToString()),
                Tuple.Create <string, string> ("Shelf", _shelfID.ToString()),
                Tuple.Create <string, string> ("Description", "'" + _description.ToString() + "'"),
                Tuple.Create <string, string> ("Status", _status)};
                connection.add(data);
                error = success;
                log("Book successfully created");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                error = fail;
            }
            return error;
        }

        public Tuple <int, string>[] getCategoryFilters()
        {
            log("getCategoryFilter called");
            categoryList.Clear();
            categoryList.Add(Tuple.Create<int, string>(0, "All Categories"));
            DataSet categoryData = categories.getData();
            for (int i = 0; i < categoryData.Tables[0].Rows.Count; i++)
            {
                categoryList.Add(Tuple.Create<int, string>(int.Parse(categoryData.Tables[0].Rows[i].ItemArray[0].ToString()), categoryData.Tables[0].Rows[i].ItemArray[1].ToString()));
            }
            log("Category list returned");
            return categoryList.ToArray();
        }

        public Tuple<int, string>[] getShelfFilters()
        {
            log("getShelfFilters called");
            shelfList.Clear();
            shelfList.Add(Tuple.Create<int, string>(0, "All Shelves"));
            DataSet shelfData = shelves.getData();
            for (int i = 0; i < shelfData.Tables[0].Rows.Count; i++)
            {
                shelfList.Add(Tuple.Create<int, string>(int.Parse(shelfData.Tables[0].Rows[i].ItemArray[0].ToString()), shelfData.Tables[0].Rows[i].ItemArray[1].ToString()));
            }
            log("Shelf filters returned");
            return shelfList.ToArray();
        }

        public void setDBaseLocation(string location)
        {
            dBaseLocation = location;
            connection.setDBLocation(location);
            log("Set dBaseLocation to '" + location.ToString() + "'");
        }

        public void setTableName(string name)
        {
            log("Table name set to '" + name.ToString() + "'");
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
            log("Filter applied " + filterType.ToString() + ". Term: " + term.ToString());
            filter = filterType;
            filterTerm = term;
        }

        public void applyCategoryFilter(int categoryID)
        {
            log("Category filter applied " + categoryID.ToString());
            filter = filterCategory;
            categoryFilter = categoryID;
        }

        public void applyShelfFilter(int shelfID)
        {
            log("Shelf filter applied " + shelfID.ToString());
            filter = filterShelf;
            shelfFilter = shelfID;
        }

        public int editBookData(int _iD, string _title, string _author, string _ISBN, string _categoryID, string _shelfID, string _description, string _status)
        {
            log("editBookData called with iD: " + _iD.ToString());
            int returnError = success;

            try
            {
                Tuple<string, string>[] data =
                    { Tuple.Create <string, string> ("Title", "'" + _title + "'"),
                Tuple.Create <string, string> ("Author", "'" + _author + "'"),
                Tuple.Create <string, string> ("ISBN", "'" + _ISBN + "'"),
                Tuple.Create <string, string> ("Category", _categoryID.ToString()),
                Tuple.Create <string, string> ("Shelf", _shelfID.ToString()),
                Tuple.Create <string, string> ("Description", "'" + _description.ToString() + "'"),
                Tuple.Create <string, string> ("Status", _status)};

                connection.update(_iD, data);
                returnError = success;
                log("Update Successful");
            }
            catch(Exception e)
            {
                log("Update failed. Error: " + e.Message.ToString());
                returnError = fail;
            }

            return returnError;

        }

        public int editBookData(int _iD, string item, string value)
        {
            log("editBookData called with iD: " + _iD.ToString());
            int returnError = success;

            try
            {
                Tuple<string, string>[] data =
                    { Tuple.Create <string, string> (item, value)};

                connection.update(_iD, data);
                returnError = success;
                log("Update Successful");
            }
            catch (Exception e)
            {
                log("Update failed. Error: " + e.Message.ToString());
                returnError = fail;
            }

            return returnError;

        }

        public int deleteBook(int _iD)
        {
            log("deleteBook called with iD " + _iD);
            int returnError = success;

            try
            {
                connection.delete(_iD);
                log("Successfully deleted");
                returnError = success;
            }
            catch(Exception e)
            {
                log("Delete Failed");
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
