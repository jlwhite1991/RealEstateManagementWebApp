using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAL
{
    public class PropertyDAL
    {
        private const string SQL_AddProperty = "INSERT INTO Property (PropertyOwnerID, NumberOfUnits, PropertyType, ManagerID, ImageSource, PropertyName) VALUES (@PropertyOwnerID, @NumberOfUnits, @PropertyType, @ManagerID, @ImageSource, @PropertyName)";

        private string connectionString;

        public PropertyDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddProperty(Property property)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AddProperty, connection);
                    cmd.Parameters.AddWithValue("@PropertyOwnerID", property.PropertyOwnerID);
                    cmd.Parameters.AddWithValue("@NumberOfUnits", property.NumberOfUnits);
                    cmd.Parameters.AddWithValue("@PropertyType", property.PropertyType);
                    cmd.Parameters.AddWithValue("@ManagerID", property.ManagerID);
                    cmd.Parameters.AddWithValue("@ImageSource", property.ImageSource);
                    cmd.Parameters.AddWithValue("@PropertyName", property.PropertyName);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
