using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServices
{
    public class RootClass
    {
        DatabaseQuery dbQuery = new DatabaseQuery();
        static RootClass rootClass = null;

        public int Count { get; set; }
        public List<Entry> Entries { get; set; }
      
        private RootClass()
        {
            Entries = dbQuery.GetEntries();
            Count = Entries != null && Entries.Count() > 0 ? Entries.Count() : 0;
        }

        public static RootClass getInstance()
        {
            if (rootClass == null)
            {
                rootClass = new RootClass();
                return rootClass;
            }
            else
            {
                return rootClass;
            }
        }

        public List<Entry> getAllEntries()
        {
            return Entries;
        }

        public Entry getEntry(int id)
        {
            var entry = new Entry();
            entry = Entries.Where(x => x.Id == id)?.ToList().FirstOrDefault();

            return entry;
        }

        public void AddEntry(Entry entry)
        {
            int newEntryId = dbQuery.AddEntry(entry);

            entry.Id = newEntryId;
            Entries.Add(entry);
        }

        public String RemoveEntry(int id)
        {
            if (Entries.Where(x => x.Id == id) != null && Entries.Where(x => x.Id == id).Count() > 0)
            {
                Entry entry = Entries.Where(x => x.Id == id).FirstOrDefault();

                if (entry != null)
                {
                    Entries.RemoveAll(x => x.Id == id);
                    dbQuery.DeleteEntry(id);
                    return "Delete successful";
                }
            }

            return "Delete un-successful";
        }

        public String UpdateEntry(Entry entry)
        {
            for (int i = 0; i < Entries.Count; i++)
            {
                Entry ent = Entries.ElementAt(i);
                if (ent.Id.Equals(entry.Id))
                {
                    Entries[i] = entry;
                    dbQuery.Update(entry);
                    return "Update successful";
                }
            }
            return "Update un-successful";
        }
    }

    public class Entry
    {
        public int Id { get; set; }
        public string Api { get; set; }
        public string Description { get; set; }
        public string Auth { get; set; }
        public string Https { get; set; }
        public string Cors { get; set; }
        public string Link { get; set; }
        public string Category { get; set; }
    }   
}

