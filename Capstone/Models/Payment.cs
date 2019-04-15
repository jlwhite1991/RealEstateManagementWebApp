using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        [Required(ErrorMessage = "A unit ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid number")]
        [Display(Name = "Please enter your unit ID: ")]
        public int UnitID { get; set; }

        [Required(ErrorMessage = "A tenant ID is required")]
        [Display(Name = "Please enter your tenant ID: ")]
        public int TenantID { get; set; }

        [Required(ErrorMessage = "Payment amount is required")]
        [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0.00")]
        [Display(Name = "Payment Amount: ")]
        public decimal PaymentAmount { get; set; }

        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Please enter a payment month")]
        [Display(Name = "This rent is being submitted for what month of rent: ")]
        public int PaymentForMonth { get; set; }
    }
}
