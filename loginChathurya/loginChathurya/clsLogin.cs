/*----------------------------------------------
 * 
 * Library Management System v1.0
 * Librarian Management v1.0
 * LoginLibrarian.exe
 * Manages all the functions related to Members.
 * 02/12/2020 10:20PM
 * © W.M.S.C.Bandara
 * 
 * -------------------------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using logWriter;


namespace loginLibrarian
{
    public class clsLogin
    {

        //Login class. All the variables and functions needed to login is within this class.

        clsLogWriter logWriter = new clsLogWriter();

        string dbaseLocation = "";//Location of database.
        string key = "";//Hash key.
        List<Tuple<string, string>> users = new List<Tuple<string, string>>();//List of users.
        
        //Error codes.
        public static int success = 0;
        public static int unknownError = 1;
        public static int invalidCharError = 2;
        public static int reuseError = 3;
        public static int wrongPWordError = 4;
        public static int adminUser = 5;

        public clsLogin(string _dbaseLocation, string _key)
        {
            //Parameters to accept when creating the class. Location of the database is accepted and assigned to
            //the variable. Hash code is accepted.

            log("");
            log("Login initialized with dBaseLocation: " + _dbaseLocation.ToString());

            dbaseLocation = _dbaseLocation;
            key = _key;
            readDatabase();
        }

        public string[] allUsers()
        {
            //Returns a list of all the registered librarians.
            log("allUsers called");
            List<string> returnUsers = new List<string>();
            bool item0 = true;
            foreach (var item in users)
            {
                if (item0)
                {
                    returnUsers.Add(item.Item1 + " (ADMIN)");
                    item0 = false;
                }
                else
                {
                    returnUsers.Add(item.Item1);
                }
                
            }
            log("Data returned");
            return returnUsers.ToArray();

        }

        public int loginUser(int iD, string pWord)
        {
            //Logs on a librarian.
            log("loginUser called for iD: " + iD.ToString());
            int returnError = 0;

            try
            {
                if ((iD >= users.Count) || (!(pWord.Equals(users[iD].Item2))))
                {
                    returnError = wrongPWordError;
                }
                else
                {
                    returnError = success;
                }
                log("Successfully logged in");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                returnError = unknownError;
            }

            return returnError;

        }

        public string getUName(int iD)
        {
            //Gets the username of an ID.
            log("getUName called with iD " + iD.ToString());
            string returnString = "";
            try
            {
                returnString = users[iD].Item1;
                log("Successfully returend");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
            }

            return returnString;
        }

        public int addUser(string uName, string pWord)
        {
            //Adds a user to the database.
            log("addUser called");
            int returnError = 0;

            try {
                if (uName.Contains('|') || uName.Contains('\n') || pWord.Contains('(') || pWord.Contains(')') || pWord.Contains('|') || pWord.Contains(' ') || pWord.Contains('\n') || pWord.Equals("") || uName.Equals(""))
                {
                    returnError = invalidCharError;
                }
                else
                {
                    bool acceptable = true;
                    foreach (var item in users)
                    {
                        if (uName.Equals(item.Item1))
                        {
                            acceptable = false;
                        }
                    }

                    if (acceptable)
                    {
                        users.Add(Tuple.Create<string, string>(uName, pWord));
                        writeDatabase();
                        readDatabase();
                        returnError = success;
                    }
                    else
                    {
                        returnError = reuseError;
                    }
                }
                log("Successfully added");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
               returnError = unknownError;
            }

            return returnError;

        }

        public int changePWord(int iD, string newPWord, string oldPWord)
        {
            //Changes the password of a librarian.
            log("changePWord called for iD " + iD.ToString());
            int returnError = 0;

            try
            {
                if ((iD > users.Count) || (oldPWord != users[iD].Item2))
                {
                    returnError = wrongPWordError;
                }
                else if (newPWord.Contains('|') || newPWord.Contains('\n') || newPWord.Contains('(') || newPWord.Contains(')') || newPWord.Contains(' ') || newPWord.Equals(""))
                {
                    returnError = invalidCharError;
                }
                else if (oldPWord.Equals(newPWord))
                {
                    returnError = reuseError;
                }
                else
                {
                    string uName = users[iD].Item1;
                    users.RemoveAt(iD);
                    users.Insert(iD, Tuple.Create<string, string>(uName, newPWord));
                    writeDatabase();
                    readDatabase();
                    returnError = success;
                }
                log("Successfully edited");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                returnError = unknownError;
            }

            return returnError;

        }

        public int deleteUser(int iD, string pWord)
        {
            //Deletes a librarian.
            log("deleteUser called for iD " + iD.ToString());
            int returnError = 0;

            try
            {

                if ((iD >= users.Count) || ((pWord != users[iD].Item2) && (pWord != users[0].Item2)))
                {
                    returnError = wrongPWordError;
                }
                else if (iD == 0)
                {
                    returnError = adminUser;
                }
                else
                {
                    users.RemoveAt(iD);
                    writeDatabase();
                    readDatabase();
                    returnError = success;
                }
                log("Successfully edited");
            }
            catch(Exception e)
            {
                log("Failed. Error: " + e.Message.ToString());
                returnError = unknownError;
            }

            return returnError;

        }

        private void readDatabase()
        {
            //Reading the database.
            System.IO.StreamReader reader = new System.IO.StreamReader(dbaseLocation);
            users.Clear();
            while (!(reader.EndOfStream))
            {
                string[] dataStream = reader.ReadLine().Replace("\n", "").Split('|');
                users.Add(Tuple.Create(CryptoEngine.Decrypt(dataStream[0], key), CryptoEngine.Decrypt(dataStream[1], key)));
            }
            reader.Dispose();

        }

        private void writeDatabase()
        {
            //Writes the database file.
            string stringStream = "";
            foreach (var item in users)
            {
                stringStream += CryptoEngine.Encrypt(item.Item1, key) + "|" + CryptoEngine.Encrypt(item.Item2, key) + "\n";
            }
            System.IO.StreamWriter writer = new System.IO.StreamWriter(dbaseLocation, false);
            writer.Write(stringStream);
            writer.Flush();
            writer.Dispose();
            writer.Close();

        }

        void log(string data)
        {
            logWriter.newEvent(data);
        }
    }
}
