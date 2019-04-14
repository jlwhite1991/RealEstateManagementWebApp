using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using Capstone.DAL.Interfaces;

namespace Capstone.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationDAL applicationDAL;

        public HomeController(IApplicationDAL applicationDAL)
        {
            this.applicationDAL = applicationDAL;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Apply(Application application)
        {
            if (!ModelState.IsValid)
            {
                return View(application);
            }
            else
            {
                applicationDAL.AddApplication(application);

                return RedirectToAction("Apply");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SubmitedForm([FromBody] FormViewModel form)
        {
            string message = "";

            //Insert to Database, send email, etc

            return Json(new { message });
        }
    }
}
