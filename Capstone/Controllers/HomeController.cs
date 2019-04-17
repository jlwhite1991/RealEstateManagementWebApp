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
        private IPropertyDAL propertyDAL;

        public HomeController(IApplicationDAL applicationDAL, IPropertyDAL propertyDAL)
        {
            this.applicationDAL = applicationDAL;
            this.propertyDAL = propertyDAL;
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

        [HttpGet]
        public IActionResult Search()
        {
            SearchModel model = new SearchModel();
            model.CurrentAvailableProperties = propertyDAL.GetAvailableProperties();

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Search(SearchModel model)
        {
            model.CurrentAvailableProperties = propertyDAL.GetAvailableProperties();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                model.AdvancedPropertySearch();
                return View(model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
