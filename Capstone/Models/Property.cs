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

        [Required(ErrorMessage = "An owner ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid number")]
        [Display(Name = "Please enter your owner ID #: ")]
        public int OwnerID { get; set; }

        [Required(ErrorMessage = "A manager ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid number")]
        [Display(Name = "Please enter your manager's ID #: ")]
        public int ManagerID { get; set; }

        [Required(ErrorMessage = "A property name is required")]
        [Display(Name = "Property Name: ")]
        public string PropertyName { get; set; }

        [Required(ErrorMessage = "Please choose a property type")]
        public string PropertyType { get; set; }

        [Required(ErrorMessage = "Number of units is required")]
        [Range(1, 100, ErrorMessage = "Please enter a valid number")]
        [Display(Name = "Please provide the number of units at this location: ")]
        public int NumberOfUnits { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Please enter a valid URL")]
        [Display(Name = "Add a link to an image of your property: ")]
        public string ImageSource { get; set; } = "";

        public List<Unit> UnitsAtThisProperty { get; set; }


        // Get Vacancy % at property(?)
        public decimal GetVacancyRate()
        {
            int vacantCount = 0;
            foreach (var unit in UnitsAtThisProperty)
            {
                if(unit.IsVacant)
                {
                    vacantCount++;
                }
            }

            return vacantCount / UnitsAtThisProperty.Count;
        }

        public decimal GetTotalScheduledGrossRents()
        {
            decimal result = 0.0M;

            // TODO: Consider this a placeholder. 
            // Would need to add actually get payments for a month, or account for additional fees.
            //Technically this would need all "Occupied Units" 
            foreach (Unit unit in UnitsAtThisProperty)
            {
                result += unit.MonthlyRent;
            }

            return result * 12;
        }

        public decimal GetVacancyLoss()
        {
            return GetTotalScheduledGrossRents() * GetVacancyRate();
        }

        public decimal GetEffectiveGrossIncome()
        {
            return GetTotalScheduledGrossRents() - GetVacancyLoss();
        }

        // Get Potential Fees for occupied (though this would need a call to applications to get occupants)
    }
}
