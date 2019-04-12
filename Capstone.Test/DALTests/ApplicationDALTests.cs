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
    public class ApplicationDALTests
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

                cmd = new SqlCommand("INSERT INTO tenant_application (unit_id, first_name, last_name, social_security_number, phone_number, email_address, last_residence_owner, last_residence_contact_phone_number, last_residence_tenancy_start_date, last_residence_tenancy_end_date, employment_status, employer_name, employer_contact_phone_number, annual_income, number_of_residents, number_of_cats, number_of_dogs) VALUES (1, 'Nick', 'Paraskos', 555555555, '6144038287', 'nick@website.com', 'Jim OwnerGuy', '614-888-8888', '05/18/18', '04/30/19', 1, 'Tech Elevator', '614-403-8287', '600,000', 3, 0, 1)", conn);

                cmd.ExecuteNonQuery();
            }
        }


        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod()]
        public void AddApplicationTest()
        {

            ApplicationDAL applicationDAL = new ApplicationDAL(connectionString);
            List<Application> priorResults = applicationDAL.GetAllApplications();

            bool addSuccessful = applicationDAL.AddApplication(new Application() { UnitID = 1, FirstName = "Nick", LastName = "Paraskos", SocialSecurityNumber = 555555555, PhoneNumber = "6144038287", EmailAddress = "nick@website.com", LastResidenceOwner = "Jim OwnerGuy", LastResidencePhoneNumber = "614-888-8888",LastResidenceTenancyStartDate = "05/18/18", LastResidenceTenancyEndDate = "04/30/19", EmploymentStatus = true, EmployerName = "Tech Elevator", EmployerContactPhoneNumber = "614-403-8287", AnnualIncome = "600,000", NumOfResidents = 3, NumOfCats = 0, NumOfDogs = 1 });

            List<Application> newResults = applicationDAL.GetAllApplications();

            Assert.AreEqual(true, addSuccessful);
            Assert.AreEqual(priorResults.Count + 1, newResults.Count);
        }
    }
}
