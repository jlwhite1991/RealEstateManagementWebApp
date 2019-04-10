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
        private const string SQL_AddProperty = "INSERT INTO property (owner_id, manager_id, property_name, property_type, number_of_units, image_source) VALUES (@ownerID, @managerID, @propertyName, @propertyType, @numberOfUnits, @imageSource);";
        private const string SQL_GetAllProperties = "SELECT * FROM property;";
        private const string SQL_GetAvailableProperties = "SELECT * FROM property JOIN unit ON property.property_id = unit.property_id WHERE tenant_id IS NULL;";
        private IUnitDAL unitDAL;

        private string connectionString;



        public PropertyDAL(string connectionString)
        {
            this.connectionString = connectionString;
            this.unitDAL = new UnitDAL(connectionString);
        }

        public bool AddProperty(Property property)
        {
            bool result;
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AddProperty, connection);
                    cmd.Parameters.AddWithValue("@ownerID", property.OwnerID);
                    cmd.Parameters.AddWithValue("@managerID", property.ManagerID);
                    cmd.Parameters.AddWithValue("@propertyName", property.PropertyName);
                    cmd.Parameters.AddWithValue("@propertyType", property.PropertyType);
                    cmd.Parameters.AddWithValue("@numberOfUnits", property.NumberOfUnits);
                    cmd.Parameters.AddWithValue("@imageSource", (property.ImageSource??(object)DBNull.Value));

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

                        property.PropertyID = Convert.ToInt32(reader["property_id"]);
                        property.OwnerID = Convert.ToInt32(reader["owner_id"]);
                        property.ManagerID = Convert.ToInt32(reader["manager_id"]);
                        property.PropertyName = Convert.ToString(reader["property_name"]);
                        property.PropertyType = Convert.ToString(reader["property_type"]);
                        property.NumberOfUnits = Convert.ToInt32(reader["number_of_units"]);
                        property.ImageSource = Convert.ToString(reader["image_source"]);


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

        public List<Property> GetAvailableProperties()
        {
            List<Property> returnedProperties = new List<Property>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAvailableProperties, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Property property = new Property();

                        property.PropertyID = Convert.ToInt32(reader["property_id"]);
                        property.OwnerID = Convert.ToInt32(reader["owner_id"]);
                        property.ManagerID = Convert.ToInt32(reader["manager_id"]);
                        property.PropertyName = Convert.ToString(reader["property_name"]);
                        property.PropertyType = Convert.ToString(reader["property_type"]);
                        property.NumberOfUnits = Convert.ToInt32(reader["number_of_units"]);

                        property.ImageSource = Convert.ToString(reader["image_source"]);

                        List<Unit> units = unitDAL.GetAllUnitsAtProperty(property.PropertyID);

                        property.UnitsAtThisProperty = units;

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
