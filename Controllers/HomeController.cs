using IOT.Context;
using IOT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IOT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(FormViewModel form)
        {
            if (ModelState.IsValid)
            {
                var entity = _context.FormViewModels.FirstOrDefault();
                entity.Off = form.Off;
                entity.On = form.On;
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(form);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}