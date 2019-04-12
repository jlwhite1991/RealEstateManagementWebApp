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
        public int MonthlyRentMin { get; set; }
        public int MonthlyRentMax { get; set; }
        public int SquareFeetMin { get; set; }
        public int SquareFeetMax { get; set; }
        public int ZipCode { get; set; }

        public void HandleAdvancedSearch()
        {
            List<Property> result = new List<Property>();

            foreach (Property property in AvailableProperties)
            {
                List<Unit> validUnits = new List<Unit>();

                foreach (Unit unit in property.UnitsAtThisProperty)
                {
                    bool isValid = CheckNumberOfBedsMin(unit) && CheckNumberOfBedsMax(unit) && CheckNumberOfBathsMin(unit) && CheckNumberOfBathsMax(unit) && CheckMonthlyRentMin(unit) && CheckMonthlyRentMax(unit) && CheckSquareFeetMin(unit) && CheckSquareFeetMax(unit) && CheckZipCode(unit);

                    if (isValid)
                    {
                        validUnits.Add(unit);
                    }
                }

                if (validUnits.Count > 0)
                {
                    property.UnitsAtThisProperty = validUnits;
                    result.Add(property);
                }
            }

            AvailableProperties = result;
        }

        public bool CheckNumberOfBedsMin(Unit unit)
        {
            bool checkResult = true;

            if (NumberofBedsMin > 0)
            {
                checkResult = unit.NumberOfBeds >= NumberofBedsMin;
            }

            return checkResult;
        }

        public bool CheckNumberOfBedsMax(Unit unit)
        {
            bool checkResult = true;

            if (NumberofBedsMax > 0)
            {
                checkResult = unit.NumberOfBeds <= NumberofBedsMax;
            }

            return checkResult;
        }

        public bool CheckNumberOfBathsMin(Unit unit)
        {
            bool checkResult = true;

            if (NumberofBathsMin > 0)
            {
                checkResult = unit.NumberOfBaths >= NumberofBathsMin;
            }

            return checkResult;
        }

        public bool CheckNumberOfBathsMax(Unit unit)
        {
            bool checkResult = true;

            if (NumberofBathsMax > 0)
            {
                checkResult = unit.NumberOfBaths <= NumberofBathsMax;
            }

            return checkResult;
        }

        public bool CheckMonthlyRentMin(Unit unit)
        {
            bool checkResult = true;

            if (MonthlyRentMin > 0)
            {
                checkResult = unit.MonthlyRent >= MonthlyRentMin;
            }

            return checkResult;
        }

        public bool CheckMonthlyRentMax(Unit unit)
        {
            bool checkResult = true;

            if (MonthlyRentMax > 0)
            {
                checkResult = unit.MonthlyRent <= MonthlyRentMax;
            }

            return checkResult;
        }

        public bool CheckSquareFeetMin(Unit unit)
        {
            bool checkResult = true;

            if (SquareFeetMin > 0)
            {
                checkResult = unit.SquareFeet >= SquareFeetMin;
            }
            return checkResult;
        }

        public bool CheckSquareFeetMax(Unit unit)
        {
            bool checkResult = true;

            if (SquareFeetMax > 0)
            {
                checkResult = unit.SquareFeet <= SquareFeetMax;
            }

            return checkResult;
        }

        public bool CheckZipCode(Unit unit)
        {
            bool checkResult = true;

            if (ZipCode > 0)
            {
                checkResult = unit.ZipCode == ZipCode;
            }

            return checkResult;
        }
    }
}