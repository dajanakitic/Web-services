using System.Configuration;
using System.Web.Mvc;

namespace WebServices
{
    public class HomeController : Controller
    {
        public virtual ActionResult RunScripts()
        {
            DatabaseCreate.RunScripts();

            return Content("great success");
        }

        public ActionResult Index()
        {           
            ViewBag.Title = "Home Page";

            var viewModel = new IndexViewModel();

            var restUrl = "http://" + Request.Url.Authority + ConfigurationManager.AppSettings["RESTBASE"];
            var soapUrl = "http://" + Request.Url.Authority + ConfigurationManager.AppSettings["SOAPBASE"] + "/GetAllEntries";

            viewModel.restApiUrl = restUrl;
            viewModel.soapApiUrl = soapUrl;

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Title = "About project";

            var viewModel = new IndexViewModel();

            var restUrl = "http://" + Request.Url.Authority + ConfigurationManager.AppSettings["RESTBASE"];
            var soapUrl = "http://" + Request.Url.Authority + ConfigurationManager.AppSettings["SOAPBASE"] + "/GetAllEntries";

            viewModel.restApiUrl = restUrl;
            viewModel.soapApiUrl = soapUrl;

            return View(viewModel);
        }       
    }
}
