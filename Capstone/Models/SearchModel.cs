using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class SearchModel
    {
        public List<Property> AvailableProperties { get; set; }

        public int NumberofBedsMin { get; set; }
        public int NumberofBedsMax { get; set; }
        public int NumberofBathsMin { get; set; }
        public int NumberofBathsMax { get; set; }

        public int ZipCode { get; set; }
        public int MonthlyRentMax { get; set; }
        public int MonthlyRentMin { get; set; }
        public int SquareFeetMax { get; set; }
        public int SquareFeetMin { get; set; }

        public void HandleAdvancedSearch()
        {
            List<Property> result = new List<Property>();

            foreach (Property property in AvailableProperties)
            {
                foreach (Unit unit in property.UnitsAtThisProperty)
                {
                    if (NumberofBathsMin > 0)
                    {


                    }

                }


            }

            //return result;
        
            ////HandleBedNumber
            //if (NumberofBathsMin > 0)
            //{
            //    AvailableProperties = AvailableProperties.Where(property => property.UnitsAtThisProperty.Where(unit => unit.NumberOfBaths >= NumberofBathsMin) != null).ToList();
            //}
            //if (NumberofBathsMax > 0)
            //{
            //    AvailableProperties = AvailableProperties.Where(property => property.UnitsAtThisProperty.Where(unit => unit.NumberOfBaths <= NumberofBathsMax) != null).ToList();
            //}
            //if (NumberofBedsMin > 0)
            //{
            //    AvailableProperties = AvailableProperties.Where(property => property.UnitsAtThisProperty.Where(unit => unit.NumberOfBeds >= NumberofBedsMin) != null).ToList();
            //}
            //if (NumberofBedsMax > 0)
            //{
            //    AvailableProperties = AvailableProperties.Where(property => property.UnitsAtThisProperty.Where(unit => unit.NumberOfBeds <= NumberofBedsMax) != null).ToList();
            //}
            //if (MonthlyRentMin > 0)
            //{
            //    AvailableProperties = AvailableProperties.Where(property => property.UnitsAtThisProperty.Where(unit => unit.MonthlyRent >= MonthlyRentMin) != null).ToList();
            //}
            //if (MonthlyRentMax > 0)
            //{
            //    AvailableProperties = AvailableProperties.Where(property => property.UnitsAtThisProperty.Where(unit => unit.MonthlyRent <= MonthlyRentMax) != null).ToList();
            //}
            //if (SquareFeetMin > 0)
            //{
            //    AvailableProperties = AvailableProperties.Where(property => property.UnitsAtThisProperty.Where(unit => unit.SquareFeet >= SquareFeetMin) != null).ToList();

            //}
            //if (SquareFeetMax > 0)
            //{
            //    AvailableProperties = AvailableProperties.Where(property => property.UnitsAtThisProperty.Where(unit => unit.SquareFeet <= SquareFeetMax) != null).ToList();
            //}
            //if (ZipCode > 0)
            //{
            //    AvailableProperties = AvailableProperties.Where(property => property.UnitsAtThisProperty.Where(unit => unit.ZipCode == ZipCode) != null).ToList();
            //}
        }


    }
}
