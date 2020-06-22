using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServices
{   
    public class EntriesController : ApiController
    {
        //GET api/entries
        [HttpGet]
        public Entry GetEntry(int id)
        {
            return RootClass.getInstance().getEntry(id);
        }

        //GET api/entries/{id}
        [HttpGet]
        public List<Entry> GetAllEntries()
        {
            return RootClass.getInstance().getAllEntries();
        }

        //POST api/entries
        [HttpPost]
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

        //PUT api/entries/{id}
        [HttpPut]
        public String PutEntryRecord(Entry entry)
        {
            Console.WriteLine("Update entry in progress");
            return RootClass.getInstance().UpdateEntry(entry);
        }

        //DELETE api/entries/{id}
        [HttpDelete]
        public String DeleteEntryRecord(int id)
        {
            Console.WriteLine("Deleting entry");
            return RootClass.getInstance().RemoveEntry(id);
        }
    }
}