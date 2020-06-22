using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using Newtonsoft.Json;

namespace WebServices
{
    public class Initializer
    {
        public static void InitialData()
        {
            //initial API used for retrieving data to fill the database
            var client = new RestClient("https://api.publicapis.org/entries");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var result = JsonConvert.DeserializeObject<RootClass>(response.Content);

            DatabaseFill.FillDatabase(result);
        }
    }
}