using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Unit
    {
        public int UnitID { get; set; }

        public int PropeertyID { get; set; }

        public int TenantID { get; set; }

        public int AddressID { get; set; }

        public decimal MonthlyRent { get; set; }

        public int SquareFeet { get; set; }

        public double NumberOfBaths { get; set; }

        public int NumberOfBeds { get; set; }

        public decimal ApplicationFee { get; set; }

        public decimal SecurityDeposit { get; set; }

        public decimal PetDeposit { get; set; }

        public string UnitDescription { get; set; }

        public string UnitTagline { get; set; }

        public string ImageSource { get; set; }
    }
}
