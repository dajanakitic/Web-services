using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Dapper;


namespace WebServices
{
    public class DatabaseFill
    {
        public static void FillDatabase(RootClass root)
        {
            string sql = "";

            if (root.Entries != null && root.Entries.Count() > 0)
            {
                PublicConnection.conn.Execute("truncate table Entry;");

                foreach (var entry in root.Entries)
                {
                    sql = "insert into Entry(Api, Description, Auth, Https, Cors, Link, Category)";
                    sql += " values (@Api,@Description,@Auth,@Https,@Cors,@Link,@Category)";

                    PublicConnection.conn.Execute(sql,
                        new { entry.Api, entry.Description, entry.Auth, entry.Https, entry.Cors, entry.Link, entry.Category });
                }
            }
        }
    }  
}