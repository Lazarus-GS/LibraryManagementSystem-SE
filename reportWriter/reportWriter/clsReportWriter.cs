/*----------------------------------------------
 * 
 * Library Management System v1.0
 * Report Writer v1.0
 * ReportWriter.exe
 * Manages all the functions related to Reports.
 * 02/12/2020 10:20PM
 * © I.D.N.Hirunika
 * © G.G.D.A.Deshapriya
 * © K.L.S.M.Perera
 * 
 * -------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using logWriter;

namespace reportWriter
{

    public class clsReportWriter
    {

        string dBaseLocation = "";
        string key = "";//Hash key.
        string report = "";

        clsLogWriter logWriter = new clsLogWriter();

        public clsReportWriter(string _key)
        {
            log("");
            log("report Writer Initialized");
            dBaseLocation = "Report " + DateTime.Today.ToString("dd-MM-yyyy") + ".rpt";
            key = _key;
            if (!(System.IO.File.Exists(AppContext.BaseDirectory + "\\" + dBaseLocation)))
            {
                log("Initialized new report");
                report = report + "Library Management System v1.0\n";
                report = report + "Report for " + DateTime.Today.ToString("dd-MM-yyyy") + "\n";
                writeDatabase();
                readDatabase();
            }
            readDatabase();
            manage();
        }

        public string[] getAllReports()
        {
            System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(AppContext.BaseDirectory + "\\Reports\\");
            System.IO.FileInfo[] logs = d.GetFiles("*.rpt");

            List<String> returnList = new List<String>();

            foreach (var item in logs)
            {
                returnList.Add(item.Name);
            }

            return returnList.ToArray();
        }

        public void manage()
        {
            log("Attempting Report Management");
            System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(AppContext.BaseDirectory);
            System.IO.FileInfo[] logs = d.GetFiles("*.rpt");

            System.IO.Directory.CreateDirectory(AppContext.BaseDirectory + "\\Reports\\");

            foreach (var item in logs)
            {
                if (!(item.Name == "Report " + DateTime.Today.ToString("dd-MM-yyyy") + ".rpt"))
                {
                    log("Old Report '" + item.Name + "' found. Moving to 'Reports' folder");
                    try
                    {
                        item.MoveTo(AppContext.BaseDirectory + "\\Reports\\" + item.Name);
                        log("Moved successfully");
                    }
                    catch (Exception e)
                    {
                        log("Moving failed. Error: " + e.Message.ToString());
                    }
                }
            }

        }

        public void newEvent(string eventData)
        {
            report = report + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt ") + eventData;
            writeDatabase();
            readDatabase();
        }

        public string readReport()
        {
            return report;
        }

        public string readReport(DateTime date)
        {
            log("Attempting to read Report for " + date.ToString("dd-MM-yyyy"));
            string oldReport = null;

            try
            {
                oldReport = readDatabase(AppContext.BaseDirectory + "\\Reports\\Report " + date.ToString("dd-MM-yyyy") + ".rpt");
            }
            catch (Exception e)
            {
                log("Failed to read Report. Error: " + e.Message.ToString());
            }
            log("Successfully read");
            return oldReport;
        }

        public string readReport(string file)
        {
            log("Attempting to read Report file " + file);
            string oldReport = null;

            try
            {
                oldReport = readDatabase(AppContext.BaseDirectory + "\\Reports\\" + file);
                log("Successfully read");
            }
            catch (Exception e)
            {
                log("Failed to read Report. Error: " + e.Message.ToString());
            }

            return oldReport;
        }

        public string getDBaseLocation()
        {
            return dBaseLocation;
        }

        private void readDatabase()
        {
            //Reading the database.
            report = "";
            System.IO.StreamReader reader = new System.IO.StreamReader(dBaseLocation);
            while (!(reader.EndOfStream))
            {
                report = report + CryptoEngine.Decrypt(reader.ReadLine(), key) + "\n" ;
            }
            reader.Dispose();

        }

        private string readDatabase(string filename)
        {
            //Reading the database.
            string returnReport = "";
            System.IO.StreamReader reader = new System.IO.StreamReader(filename);
            while (!(reader.EndOfStream))
            {
                returnReport = returnReport + CryptoEngine.Decrypt(reader.ReadLine(), key) + "\n";
            }
            reader.Dispose();
            return returnReport;

        }

        private void writeDatabase()
        {
            //Writes the database file.
            string writeString = "";
            string[] stringStream  = report.Split('\n');
            foreach (var item in stringStream)
            {
                writeString = writeString + CryptoEngine.Encrypt(item, key) + "\n";
            }
                
            System.IO.StreamWriter writer = new System.IO.StreamWriter(dBaseLocation, false);
            writer.Write(writeString);
            writer.Flush();
            writer.Dispose();
            writer.Close();

        }

        private void log(string data)
        {
            logWriter.newEvent(data);
        }

    }
}
