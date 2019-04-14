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

        [Required(ErrorMessage = "Please provide a Unit ID")]
        [Display(Name = "Enter your Unit ID: ")]
        public int UnitID { get; set; }

        [Required(ErrorMessage = "Please provide a Tenant ID")]
        [Display(Name = "Enter your Tenant ID: ")]
        public int TenantID { get; set; }

        [Required(ErrorMessage = "Please provide a Payment Amount")]
        [Display(Name = "Enter the amount you would like to Pay: ")]
        public decimal PaymentAmount { get; set; }
    }
}
