using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Serilog;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;

namespace SeriLog_Logger
{
    public class GlobalVariable
    {
        public static ILogger LogObj { get; set; }
        public static ILogger LogDB { get; set; }
        public static ILogger LogFileDB { get; set; } 
      
        public static void SetLog()
        {
            /*
             * Note: When exiting from the app always use CloseAndFlush. Here when we are closing main form then it will be used.
             */
            /*
             * File size is 500 kb = 512000
             * this will shwo the output in text format
             */
            LogObj = new LoggerConfiguration().WriteTo.File("MyLog.log", rollingInterval: RollingInterval.Day,
                fileSizeLimitBytes: 5120, retainedFileCountLimit: 3, rollOnFileSizeLimit: true).CreateLogger();
            /*
            * File size is 500 kb = 512000
            * this is using statis Log class from library just use the reference on any form and use method from Log class
            */
            Log.Logger = new LoggerConfiguration().WriteTo.File("MyLogNew.log", rollingInterval: RollingInterval.Day,
              fileSizeLimitBytes: 5120, retainedFileCountLimit: 3, rollOnFileSizeLimit: true).CreateLogger();
            /*
             * Log everythig in the database
             */
            //string connString = @"Server=SAR-N-PG0145LJ\SQLEXPRESS2016;Database=testdb;Integrated Security=SSPI";
            string connString = @"Server=SAR-N-PG0145LJ\SQLEXPRESS2016;Database=testdb;User Id=sa;Password=sato@123";
            //LogDB = new LoggerConfiguration().WriteTo.MSSqlServer(
            //    connectionString: connString,
            //    sinkOptions: new SinkOptions { TableName = "SeriLogTest", AutoCreateSqlTable = true }).CreateLogger();

            /*
             * Combine File logging with database
             */
            LogFileDB = new LoggerConfiguration().WriteTo.File("FileWithDB.log", rollingInterval: RollingInterval.Day,
            fileSizeLimitBytes: 5120, retainedFileCountLimit: 3, rollOnFileSizeLimit: true)
            .WriteTo.MSSqlServer(
                connectionString: connString,
                sinkOptions: new SinkOptions { TableName = "SeriLogTest", AutoCreateSqlTable = true })
            .CreateLogger();
        }
    }
    public class User
    {
        public int id { get; set; } = 5;
        public string name { get; set; } = "Amit Tomar";
    }
}
