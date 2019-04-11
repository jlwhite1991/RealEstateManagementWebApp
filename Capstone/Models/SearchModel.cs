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
            
        }


    }
}
