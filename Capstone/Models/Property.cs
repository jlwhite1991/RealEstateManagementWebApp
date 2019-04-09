using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Property
    {
        public int PropertyID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please provide a Owner ID")]
        [Display(Name = "Enter your Owner ID: ")]
        public int PropertyOwnerID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please provide a manager ID")]
        [Display(Name = "Enter in the ID of your manager: ")]
        public int ManagerID { get; set; }

        [Required(ErrorMessage = "Please provide a property name")]
        [Display(Name = "Enter in the name of your property")]
        public string PropertyName { get; set; }

        [Required(ErrorMessage = "Please provide number of Units")]
        [Range(0, 2000)]
        [Display(Name = "Enter in the number of units")]
        public int NumberOfUnits { get; set; }

        [Required(ErrorMessage = "Please provide a property type")]
        [Display(Name = "Property Type")]
        public string PropertyType { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Add a link to an image of your property: ")]
        public string ImageSource { get; set; } = "";

        public List<Unit> UnitsAtThisProperty { get; set; }
    }
}
