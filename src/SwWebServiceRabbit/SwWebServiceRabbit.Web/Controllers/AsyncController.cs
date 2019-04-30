using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwWebServiceRabbit.Web.Models;

namespace SwWebServiceRabbit.Web.Controllers
{
    public class AsyncController : Controller
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
    }
}