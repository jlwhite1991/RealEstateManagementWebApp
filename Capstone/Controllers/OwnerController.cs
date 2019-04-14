using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAL.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class OwnerController : Controller
    {
        private IPropertyDAL propertyDAL;
        private IUnitDAL unitDAL;
        private IApplicationDAL applicationDAL;

        public OwnerController(IPropertyDAL propertyDAL, IUnitDAL unitDAL, IApplicationDAL applicationDAL)
        {
            this.propertyDAL = propertyDAL;
            this.unitDAL = unitDAL;
            this.applicationDAL = applicationDAL;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(Property property)
        {
            propertyDAL.AddProperty(property);

            return RedirectToAction("UnitForm");
        }

        [HttpGet]
        public IActionResult UnitForm()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult UnitForm(Unit unit)
        {
            unitDAL.AddUnit(unit);

            return RedirectToAction("UnitForm");
        }

        [HttpGet]
        public IActionResult Applicants()
        {
            List<Application> applications = applicationDAL.GetAllApplications();

            return View(applications);
        }

    }
}