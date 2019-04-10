using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAL
{
    public class UnitDAL : IUnitDAL
    {
        private const string SQL_AddUnit = "INSERT INTO unit (property_id, tenant_id, monthly_rent, square_feet, number_of_beds, number_of_baths, description, tagline, image_source, application_fee, security_deposit, pet_deposit, address_line_1, address_line_2, city, us_state, zip_code, washer_dryer, allow_cats, allow_dogs, parking_spots, gym, pool) VALUES (@propertyID, @tenantID, @monthlyRent, @squareFeet, @numberOfBeds, @numberOfBaths, @description, @tagline, @imageSource, @applicationFee, @securityDeposit, @petDeposit, @addressLine1, @addressLine2, @city, @state, @zipCode, @washerDryer, @allowCats, @allowDogs, @parkingSpots, @gym, @pool);";

        private string connectionString;

        public UnitDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool AddUnit(Unit unit)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AddUnit, connection);
                    cmd.Parameters.AddWithValue("@propertyID", unit.PropertyID);
                    cmd.Parameters.AddWithValue("@tenantID", unit.TenantID);
                    cmd.Parameters.AddWithValue("@monthlyRent", unit.MonthlyRent);
                    cmd.Parameters.AddWithValue("@squareFeet", unit.SquareFeet);
                    cmd.Parameters.AddWithValue("@numberOfBeds", unit.NumberOfBeds);
                    cmd.Parameters.AddWithValue("@numberOfBaths", unit.NumberOfBaths);
                    cmd.Parameters.AddWithValue("@description", unit.Description);
                    cmd.Parameters.AddWithValue("@tagline", unit.Tagline);
                    cmd.Parameters.AddWithValue("@imageSource", (unit.ImageSource??(object)DBNull.Value));
                    cmd.Parameters.AddWithValue("@applicationFee", unit.ApplicationFee);
                    cmd.Parameters.AddWithValue("@securityDeposit", unit.SecurityDeposit);
                    cmd.Parameters.AddWithValue("@petDeposit", unit.PetDeposit);
                    cmd.Parameters.AddWithValue("@addressLine1", unit.AddressLine1);
                    cmd.Parameters.AddWithValue("@addressLine2", (unit.AddressLine2??(object)DBNull.Value));
                    cmd.Parameters.AddWithValue("@city", unit.City);
                    cmd.Parameters.AddWithValue("@state", unit.State);
                    cmd.Parameters.AddWithValue("@zipCode", unit.ZipCode);
                    cmd.Parameters.AddWithValue("@washerDryer", unit.WasherDryer);
                    cmd.Parameters.AddWithValue("@allowCats", unit.AllowCats);
                    cmd.Parameters.AddWithValue("@allowDogs", unit.AllowDogs);
                    cmd.Parameters.AddWithValue("@parkingSpots", unit.ParkingSpots);
                    cmd.Parameters.AddWithValue("@gym", unit.Gym);
                    cmd.Parameters.AddWithValue("@pool", unit.Pool);

                    cmd.ExecuteNonQuery();
                }

                result = true;
            }
            catch (SqlException ex)
            {
                result = false;
                throw ex;
            }

            return result;
        }
    }
}
