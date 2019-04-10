using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Unit
    {
        public int UnitID { get; set; }

        public int PropertyID { get; set; }

        public int TenantID { get; set; }

        public decimal MonthlyRent { get; set; }

        public int SquareFeet { get; set; }

        public int NumberOfBeds { get; set; }

        public double NumberOfBaths { get; set; }

        public string Description { get; set; }

        public string Tagline { get; set; }

        public string ImageSource { get; set; }

        public decimal ApplicationFee { get; set; }

        public decimal SecurityDeposit { get; set; }

        public decimal PetDeposit { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }

        public bool WasherDryer { get; set; }

        public bool AllowCats { get; set; }

        public bool AllowDogs { get; set; }

        public string ParkingSpots { get; set; }

        public bool Gym { get; set; }

        public bool Pool { get; set; }
    }
}
