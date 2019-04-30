using Microsoft.AspNetCore.Mvc;
using SwWebServiceRabbit.Web.Data;
using SwWebServiceRabbit.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwWebServiceRabbit.Web.Controllers
{
    public class SyncController : Controller
    {
        readonly HttpClient _client;
        readonly ToonContext _context;

        public SyncController(ToonContext context)
        {
            _client = new HttpClient();
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Toons = _context.Toons.Select(o => new ToonViewModel
            {
                Name = o.Name,
                Order = o.Order,
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ToonViewModel model)
        {
            await _context.Toons.AddAsync(new Toon { Name = model.Name, Order = model.Order });
            await _context.SaveChangesAsync();

            var url = string.Empty;

            switch (model.Order)
            {
                case Order.Jedi:
                    url = "http://localhost:51585/api/jedis";
                    break;
                case Order.Sith:
                    url = "http://localhost:51586/api/siths";
                    break;
            }

            var response = await _client.PostAsJsonAsync<IDictionary<string, string>>(url, new Dictionary<string, string> { { "name", model.Name } });

            if (!response.IsSuccessStatusCode)
            {
                
            }

            return RedirectToAction("Index");
        }
    }
}