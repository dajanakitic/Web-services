using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace WebServices
{
    public class DatabaseQuery
    {
        public List<Entry> GetEntries(int id = 0)
        {
            List<Entry> entryList = new List<Entry>();

            if (id == 0)
            {
                entryList = PublicConnection.conn.Query<Entry>("select * from Entry").ToList();
            }
            else
            {
                entryList = PublicConnection.conn.Query<Entry>("select * from Entry where Id=@Id", new { id }).ToList();
            }

            return entryList;
        }

        public int GetEntryCount()
        {
            int num = 0;
            num = PublicConnection.conn.Query<int>("select Count(Id) from Entry").FirstOrDefault();

            return num;
        }

        public int AddEntry(Entry entry)
        {
            string sql = "";
            int newEntryId = 0;

            if(entry != null)
            {
                sql += "insert into Entry (Api,Description,Auth,Https,Cors,Link,Category) ";
                sql += "values (@Api,@Description,@Auth,@Https,@Cors,@Link,@Category)";

                PublicConnection.conn.Execute(sql, new { entry.Api, entry.Description, entry.Auth, entry.Https, entry.Cors, entry.Link, entry.Category });

                newEntryId = PublicConnection.conn.Query<int>("select MAX(Id) from Entry").FirstOrDefault();
            }
            
            return newEntryId;
        }

        public void DeleteEntry(Entry entry)
        {
            PublicConnection.conn.Execute("delete from Entry where Id=@Id", new { entry.Id });
        }

        public void DeleteEntry(int id)
        {
            PublicConnection.conn.Execute("delete from Entry where Id=@Id", new { id });
        }

        public void Update(Entry entry)
        {
            string sql = "";

            sql += "update Entry set ";
            sql += "Api='" + entry.Api + "',";
            sql += "Description='" + entry.Description + "',";
            sql += "Auth='" + entry.Auth + "',";
            sql += "Https='" + entry.Https + "',";
            sql += "Cors='" + entry.Cors + "',";
            sql += "Link='" + entry.Link + "',";
            sql += "Category='" + entry.Category + "'";
            sql += " where Id=" + entry.Id;

            PublicConnection.conn.Execute(sql);
        }
    }
}
