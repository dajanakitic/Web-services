﻿using System.Configuration;
using StackExchange.Profiling.Data;
using StackExchange.Profiling;
using System.Data.SqlClient;

namespace WebServices
{
    public class PublicConnection
    {
        private ProfiledDbConnection _conn { get; set; }

        public static ProfiledDbConnection conn
        {
            get
            {
                return getConn();
            }
        }
        public static ProfiledDbConnection getConn()
        {
            return new ProfiledDbConnection(new SqlConnection(ConfigurationManager.AppSettings["connString"]), MiniProfiler.Current);
        }

        public static SqlConnection nonProfiledConn
        {
            get
            {
                return getConnNonProfiled();
            }
        }

        public static SqlConnection getConnNonProfiled()
        {
            return new SqlConnection(ConfigurationManager.AppSettings["connString"]);
        }

    }

}