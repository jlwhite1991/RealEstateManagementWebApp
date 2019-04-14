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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Submit()
        {
            ServiceRequest serviceRequest = new ServiceRequest();
            return View(serviceRequest);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Submit(ServiceRequest serviceRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceRequest);
            }
            else
            {
                serviceRequestDAL.AddServiceRequest(serviceRequest);

                return RedirectToAction("Submit");
            }
        }

        [HttpGet]
        public IActionResult Rent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Rent(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return View(payment);
            }
            else
            {
                serviceRequestDAL.SubmitPayment(payment);

                return RedirectToAction("Rent");
            }
        }
    }
}