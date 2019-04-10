using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAL.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    public class SearchController : Controller
    {
        private IPropertyDAL propertyDAL;
        private IUnitDAL unitDAL;

        public SearchController(IPropertyDAL propertyDAL, IUnitDAL unitDAL)
        {
            this.propertyDAL = propertyDAL;
            this.unitDAL = unitDAL;
        }

        public IActionResult Index()
        {
            List<Property> properties = propertyDAL.GetAvailableProperties();
            
            return View(properties);
        }
    }
}