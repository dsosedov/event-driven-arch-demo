using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwWebServiceRabbit.Web.Models;
using System.Diagnostics;

namespace SwWebServiceRabbit.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ToonViewModel model)
        {
            QueueConnector.Instance.Publish(JsonConvert.SerializeObject(model));

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
