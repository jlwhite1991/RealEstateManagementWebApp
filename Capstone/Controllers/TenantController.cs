using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAL;
using Capstone.DAL.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class TenantController : Controller
    {
        private IServiceRequestDAL serviceRequestDAL;

        public TenantController(IServiceRequestDAL serviceRequestDAL)
        {
            this.serviceRequestDAL = serviceRequestDAL;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ServiceRequest serviceRequest = new ServiceRequest();
            return View(serviceRequest);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(ServiceRequest serviceRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceRequest);
            }
            else
            {
                serviceRequestDAL.AddServiceRequest(serviceRequest);

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult PayRent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PayRent(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return View(payment);
            }
            else
            {
                serviceRequestDAL.PayRent(payment);

                return RedirectToAction("PayRent");
            }
        }
    }
}