using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    [WebService(Namespace = "/Service.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        //GET record
        [WebMethod]
        public Entry GetEntry(int id)
        {
            return RootClass.getInstance().getEntry(id);
        }

        //GET all records
        [WebMethod]
        public List<Entry> GetAllEntries()
        {
            return RootClass.getInstance().getAllEntries();
        }

        //POST 
        [WebMethod]
        public Entry AddEntry(Entry entry)
        {
            Console.WriteLine("In process");
            Entry newEntry = new Entry();
            RootClass.getInstance().AddEntry(entry);
            newEntry.Api = entry.Api;
            newEntry.Description = entry.Description;
            newEntry.Auth = entry.Auth;
            newEntry.Https = entry.Https;
            newEntry.Cors = entry.Cors;
            newEntry.Link = entry.Link;
            newEntry.Category = entry.Category;

            return newEntry;
        }

        //PUT
        [WebMethod]
        public String PutEntryRecord(Entry entry)
        {
            Console.WriteLine("Update entry in progress");
            return RootClass.getInstance().UpdateEntry(entry);
        }

        //DELETE 
        [WebMethod]
        public String DeleteEntryRecord(int id)
        {
            Console.WriteLine("Deleting entry");
            return RootClass.getInstance().RemoveEntry(id);
        }
    }
}
