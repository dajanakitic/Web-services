using Dapper;
using DbUp;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace WebServices
{   
    public class DatabaseCreate
    {
        public static void RunScripts()
        {
            var connectionString = ConfigurationManager.AppSettings["connString"];
            var splitter = new string[] { "initial catalog=" };
            var dbName = connectionString.ToLower().Split(splitter, StringSplitOptions.RemoveEmptyEntries).Last().Split(';').First();

            EnsureDatabase.For.SqlDatabase(connectionString); //Creates database if not exist

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), f => f.Contains("SQLScripts"))
                    .WithVariable("DatabaseName", dbName)
                    .LogToTrace()
                    .WithExecutionTimeout(new TimeSpan(0, 10, 0))
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                //throw result.Error;
                Debug.WriteLine(result.Error.ToString());
            }
            Debug.WriteLine("Success!");
        }
    }
}