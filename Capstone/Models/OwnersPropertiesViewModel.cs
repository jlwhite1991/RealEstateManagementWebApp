using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class OwnersPropertiesViewModel
    {
        public List<Property> ownersProperties { get; set; }


        public decimal AverageBaseRentAllUnits()
        {
            decimal result = 0.0M;
            int numOfUnits = 0;

            foreach (Property prop in ownersProperties)
            {
                foreach (Unit unit in prop.UnitsAtThisProperty)
                {
                    result += unit.MonthlyRent;
                    numOfUnits++;
                }
            }
            return result /= numOfUnits;
        }

        // TODO: Unsure how to calculate this just yet. Currently we have no lease details or loan payments
        public decimal AvgVacancyForAllUnits()
        {
            decimal result = 0.0M;
            int numOfUnits = 0;
            foreach (var prop in ownersProperties)
            {
                result += prop.GetVacancyRate();
                numOfUnits += prop.UnitsAtThisProperty.Count;
            }

            return Math.Round(result / numOfUnits, 2);
        }

        public decimal SumRentCollectedYTD()
        {
            decimal result = 0.0M;

            foreach(Property prop in ownersProperties)
            {
                foreach (Unit unit in prop.UnitsAtThisProperty)
                {
                    result += unit.RentCollectedYTD;
                }

            }

            return result;
        }
    }
}