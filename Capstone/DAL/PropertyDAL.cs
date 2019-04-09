using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAL
{
    public class PropertyDAL : IPropertyDAL
    {
        private const string SQL_AddProperty = "INSERT INTO Property (PropertyOwnerID, NumberOfUnits, PropertyType, ManagerID, ImageSource, PropertyName) VALUES (@PropertyOwnerID, @NumberOfUnits, @PropertyType, @ManagerID, @ImageSource, @PropertyName);";
        private const string SQL_GetAllProperties = "SELECT * FROM Property;";

        private string connectionString;

        public PropertyDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool AddProperty(Property property)
        {
            bool result = false;

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

                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }

            return result;
        }

        public List<Property> GetAllProperties()
        {
            List<Property> returnedProperties = new List<Property>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllProperties, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Property property = new Property();

                        property.PropertyID = Convert.ToInt32(reader["PropertyID"]);
                        property.PropertyOwnerID = Convert.ToInt32(reader["PropertyOwnerID"]);
                        property.NumberOfUnits = Convert.ToInt32(reader["NumberOfUnits"]);
                        property.PropertyType = Convert.ToString(reader["PropertyType"]);
                        property.ManagerID = Convert.ToInt32(reader["ManagerID"]);
                        property.ImageSource = Convert.ToString(reader["ImageSource"]);
                        property.PropertyName = Convert.ToString(reader["PropertyName"]);

                        returnedProperties.Add(property);
                    }
                }
            }
            catch (SqlException)
            {
                returnedProperties = new List<Property>();
            }

            return returnedProperties;
        }
    }
}
