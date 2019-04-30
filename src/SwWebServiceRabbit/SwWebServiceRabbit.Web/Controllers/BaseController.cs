using Microsoft.AspNetCore.Mvc;
using SwWebServiceRabbit.Web.Data;
using SwWebServiceRabbit.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SwWebServiceRabbit.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected abstract string Title { get; }

        protected readonly ToonContext _context;

        protected BaseController(ToonContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = Title;

            ViewBag.Toons = _context.Toons.Select(o => new ToonViewModel
            {
                Name = o.Name,
                Order = o.Order,
            });

            return View("Toons");
        }

        [HttpPost]
        public virtual async Task<IActionResult> Index(ToonViewModel model)
        {
            await _context.Toons.AddAsync(new Toon { Name = model.Name, Order = model.Order });
            await _context.SaveChangesAsync();

            try
            {
                await ChildIndex(model);
            }
            catch (Exception ex)
            {
                ViewBag.Ex = ex;

                return Index();
            }

            return RedirectToAction("Index");
        }

        protected abstract Task ChildIndex(ToonViewModel model);
    }
}
