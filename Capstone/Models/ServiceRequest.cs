using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ServiceRequest
    {
        public int RequestID { get; set; }

        [Display(Name = "Please enter your Tenant ID #")]
        [Required(ErrorMessage = "You must input your Tenant ID #")]
        [Range(1, int.MaxValue, ErrorMessage = "Please input a valid number")]
        public int TenantID { get; set; }

        [Required(ErrorMessage = "You must describe the nature of the service request.")]
        public string Description { get; set; }

        [Display(Name = "Is this an Emergency?")]
        public bool IsEmergency { get; set; }

        [Display(Name = "What kind of service request is this?")]
        [Required]
        public string Category { get; set; }

        public bool IsCompleted { get; set; }

        public IList<SelectListItem> CategoriesList = new List<SelectListItem>()
        {
        new SelectListItem() { Text="Plumbing"},
        new SelectListItem() { Text="Electrical"},
        new SelectListItem() { Text="Air Conditioning"},
        new SelectListItem() { Text="Appliances"},
        new SelectListItem() { Text="Other"}
        };
    }
}
