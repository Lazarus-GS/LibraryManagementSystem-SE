/*----------------------------------------------
 * 
 * Library Management System v1.0
 * Database Management v1.0
 * dBaseManager.exe
 * Manages all the functions related to database.
 * 02/12/2020 10:20PM
 * © L.V.G.S.Perera
 * 
 * -------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRetrieval;
using logWriter;

namespace dBaseManager
{
    class clsDBaseManager
    {

        clsLogWriter logWriter = new clsLogWriter();

        string dBaseLocation = "";
        int maxBackup = 0;

        static int normal = 0;
        static int error = 1;
        static int missing = 2;

        static int success = 0;
        static int dBaseDamaged = 1;
        static int backupMissing = 2;
        static int unknownError = 3;

        string[] tableNames = { "Book_Issues", "Books", "Categories", "Issue_History", "Members", "Shelves" };

        public clsDBaseManager(string _dBaseLocation, int _maxBackups)
        {
            log("");
            log("Database Manager initialized with dBaseLocation: " + _dBaseLocation.ToString() + ", maxBackups: " + _maxBackups.ToString()); ;

            dBaseLocation = _dBaseLocation;
            maxBackup = _maxBackups;
            manage();
        }

        public Tuple <int, Dictionary<string, bool>> checkDBase()
        {
            log("checkDBase called");
            int returnError = missing;
            Dictionary<string, bool> tables = new Dictionary<string, bool>();

            if (!(System.IO.File.Exists(dBaseLocation)))
            {
                returnError = missing;
                foreach (var item in tableNames)
                {
                    tables.Add(item, false);
                }
            }
            else
            {

                foreach (var item in tableNames)
                {
                    tables.Add(item, checkTable(item, dBaseLocation));
                }

                bool dBaseHealth = true;
                foreach (var item in tables)
                {
                    dBaseHealth = item.Value && dBaseHealth;
                }

                if(dBaseHealth)
                {
                    returnError = normal;
                }
                else
                {
                    returnError = error;
                }

            }
            log("checkDBase ended with error " + returnError.ToString());

            return Tuple.Create<int, Dictionary<string, bool>>(returnError, tables);

        }

        public Tuple<int, Dictionary<string, bool>> checkDBase(string location)
        {
            log("checkDBase called with location '" + location.ToString() + "'");
            int returnError = missing;
            Dictionary<string, bool> tables = new Dictionary<string, bool>();

            if (!(System.IO.File.Exists(location)))
            {
                returnError = missing;
                foreach (var item in tableNames)
                {
                    tables.Add(item, false);
                }
            }
            else
            {

                foreach (var item in tableNames)
                {
                    tables.Add(item, checkTable(item, location));
                }

                bool dBaseHealth = true;
                foreach (var item in tables)
                {
                    dBaseHealth = item.Value && dBaseHealth;
                }

                if (dBaseHealth)
                {
                    returnError = normal;
                }
                else
                {
                    returnError = error;
                }

            }
            log("checkDBase ended with error " + returnError.ToString());

            return Tuple.Create<int, Dictionary<string, bool>>(returnError, tables);

        }

        public bool manage()
        {
            log("manager called");
            bool returnError = true;

            if (!(System.IO.File.Exists("Backups\\Backup " + DateTime.Now.ToString("dd-MM-yyyy") + ".accdb")))
            {
                try
                {
                    log("backupDBase called");
                    backupDBase();
                    log("backupDBase ended successfully");
                }
                catch(Exception e)
                {
                    log("backupDBase failed. Error: " + e.Message.ToString());
                }
            }

            try
            {
                log("deleteOldBackups called");
                deleteOldBackups();
                log("deleteOldBackups ended successfully");
            }
            catch(Exception e)
            {
                log("deleteOldBackups failed. Error: " + e.Message.ToString());
            }

            if(checkDBase().Item1 != normal)
            {
                returnError = true;
            }
            else
            {
                returnError = false;
            }
            log("manage ended with error: " + returnError.ToString());

            return returnError;
        }

        public System.IO.FileInfo[] getAllBackups()
        {
            log("getAllBackups called");
            System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(AppContext.BaseDirectory + "\\Backups\\");
            System.IO.FileInfo[] backups = d.GetFiles("*.accdb");

            log("Returned backup files");
            return backups;
        }

        public int restoreBackup(System.IO.FileInfo file)
        {
            log("Restore backup called for file: " + file.FullName.ToString());
            int returnError = success;

            log("checkDBase called for '" + file.FullName.ToString() + "'");
            int error = checkDBase(file.FullName).Item1;

            if (error == normal)
            {
                log("Backup file is healthy");
                try
                {
                    log("Attempting to copy file: " + file.FullName);
                    file.CopyTo("LMS.accdb", true);
                    log("Successfully copied");
                    returnError = success;
                }
                catch(Exception e)
                {
                    log("Copy failed. Error: " + e.Message.ToString());
                    returnError = unknownError;
                }

            }else if(error == 1)
            {
                log("Error in backup file. Error: 'Backup Damaged'");
                returnError = dBaseDamaged;
            }
            else
            {
                log("Error in backup file. Error: 'Backup Missing'");
                returnError = backupMissing;
            }
            log("restoreBackup ended with error " + returnError.ToString());

            return returnError;
        }

        public void backupDBase()
        {
            log("backupDBase called. Backing up for " + DateTime.Now.ToString());
            System.IO.Directory.CreateDirectory("Backups");

            try
            {
                System.IO.File.Copy(dBaseLocation, "Backups\\Backup " + DateTime.Now.ToString("dd-MM-yyyy") + ".accdb", true);
                log("Backup successful");
            }
            catch(Exception e)
            {
                log("Backup failed. Error: " + e.Message.ToString());
            }

        }

        void deleteOldBackups()
        {
            log("deleteOldBackups called");
            try
            {
                System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(AppContext.BaseDirectory + "\\Backups\\");
                System.IO.FileInfo[] backups = d.GetFiles("*.accdb");

                System.IO.FileInfo oldestBackup = backups[0];

                backups.OrderBy(x => x.CreationTime).FirstOrDefault();

                int noToDelete = backups.Count() - maxBackup;
                if (noToDelete < 0)
                {
                    noToDelete = 0;
                }

                for (int i = 0; i < noToDelete; i++)
                {
                    backups[i].Delete();
                }
                log("deleteBackups done successfully");
            }
            catch(Exception e)
            {
                log("deleteBackup failed. Error: " + e.Message.ToString());
            }

        }

        bool checkTable(string tableName, string dBase)
        {
            bool returnData = false;
            try
            {
                clsConnection test = new clsConnection(dBase, tableName);
                test.getData();
                returnData = true;
            }
            catch (Exception e)
            {
                returnData = false;
            }

            return returnData;
        }

        void log(string data)
        {
            logWriter.newEvent(data);
        }

    }
}
