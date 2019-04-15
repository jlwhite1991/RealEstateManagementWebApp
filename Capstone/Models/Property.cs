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
        public int OwnerID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Manager ID required")]
        [Display(Name = "Please submit your manager's ID #: ")]
        public int ManagerID { get; set; }

        [Required(ErrorMessage = "Please provide a property name")]
        [Display(Name = "Enter in the name of your property")]
        public string PropertyName { get; set; }

        [Required(ErrorMessage = "Please provide a property type")]
        [Display(Name = "Property Type")]
        public string PropertyType { get; set; }

        [Required(ErrorMessage = "Please provide number of Units")]
        [Range(0, 2000)]
        [Display(Name = "Enter in the number of units")]
        public int NumberOfUnits { get; set; }

        [DataType(DataType.ImageUrl)]
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
