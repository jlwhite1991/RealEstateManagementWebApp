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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Property()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Property(Property property)
        {
            propertyDAL.AddProperty(property);

            return RedirectToAction("Unit");
        }

        [HttpGet]
        public IActionResult Unit()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Unit(Unit unit)
        {
            unitDAL.AddUnit(unit);

            return RedirectToAction("Unit");
        }

        [HttpGet]
        public IActionResult Review()
        {
            List<Application> applications = applicationDAL.GetAllUnreviewedApplications();

            return View(applications);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Approve(int applicationID)
        {
                applicationDAL.ApproveApplication(applicationID);

                return RedirectToAction("Review");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Deny(int applicationID)
        {
            applicationDAL.DenyApplication(applicationID);

            return RedirectToAction("Review");
        }

        [HttpGet]
        public IActionResult MyProperties()
        {
            // Get ownersID
            int myID = 2;

            List<Property> ownerProperties = propertyDAL.GetPropertiesForOwner(myID);

            OwnersPropertiesViewModel myProperties = new OwnersPropertiesViewModel();

            myProperties.ownersProperties = ownerProperties;

            return View(myProperties);
        }
    }
}