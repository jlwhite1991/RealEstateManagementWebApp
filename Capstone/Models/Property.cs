using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Property
    {
        public int PropertyID { get; set; }

        public int PropertyOwnerID { get; set; }

        public int ManagerID { get; set; }

        public int NumberOfUnits { get; set; }

        public string PropertyType { get; set; }

        public string ImageSource { get; set; }

        public List<Unit> UnitsAtThisProperty { get; set; }
    }
}
