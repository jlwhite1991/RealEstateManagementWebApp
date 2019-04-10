using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Test.DALTests
{
    [TestClass]
    public class PropertyDALTests
    {
        private TransactionScope tran;

        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=RealEstateManagement;Integrated Security=True";

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;

                conn.Open();

                //cmd = new SqlCommand("INSERT INTO property(owner_id, manager_id, property_name, property_type, number_of_units) VALUES(2, 1, 'Test Meadows', 'Single Family', 1);", conn);
                //cmd.ExecuteNonQuery();

                //cmd = new SqlCommand("SELECT COUNT(property_id) FROM property;", conn);
                //int count = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("INSERT INTO unit(property_id, monthly_rent, square_feet, number_of_beds, number_of_baths, description, tagline, application_fee, security_deposit, pet_deposit, address_line_1, city, us_state, zip_code, washer_dryer, allow_cats, allow_dogs, parking_spots, gym, pool) VALUES(1, 999, 999, 1, 1, 'Testing is good!', 'Love to test.', 99, 999, 99, '99 Test Street', 'Testville', 'Ohio', 99999, 0, 0, 0, 'No Parking', 0, 0);", conn);
                //cmd.Parameters.AddWithValue("@count", count);
                cmd.ExecuteNonQuery();
            }
        }


        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod()]
        public void AddPropertyTest()
        {
            PropertyDAL propertyDAL = new PropertyDAL(connectionString);
            Property property = new Property()
            {
                PropertyID = 5,
                OwnerID = 2,
                ManagerID = 1,
                PropertyName = "Test Paradise",
                PropertyType = "Triplex",
                NumberOfUnits = 3
            };

            bool result = propertyDAL.AddProperty(property);

            Assert.IsTrue(result);
        }

        //[TestMethod()]
        //public void GetAvailablePropertiesTest()
        //{
        //    PropertyDAL propertyDAL = new PropertyDAL(connectionString);
        //    List<Property> properties = propertyDAL.GetAvailableProperties();

        //    Assert.IsNotNull(properties);
        //    Assert.AreEqual("Love to test.", properties[0].UnitsAtThisProperty[0].Tagline);
        //}
    }
}
