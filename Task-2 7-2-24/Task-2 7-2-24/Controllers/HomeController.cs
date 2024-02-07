using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using Task_2_7_2_24.Models;


namespace Task_2_7_2_24.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [HttpGet]
        public ActionResult Index()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Index(Student s)
        {
            if (ModelState.IsValid)
            { //checking the rules imposed in Person class
                return RedirectToAction("Contact");
            }
            return View(s);
        }
        public ActionResult Contact()
        {
            return View();
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
