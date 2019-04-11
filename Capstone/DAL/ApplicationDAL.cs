using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAL
{
    public class ApplicationDAL : IApplicationDAL
    {
        private const string SQL_AddProperty = "INSERT INTO tenant_application (unit_id, first_name, last_name, social_security_number, phone_number, email_address, last_residence_owner, last_residence_contact_phone_number, last_residence_tenancy_start_date, last_residence_tenancy_end_date, employment_status, employer_name, employer_contact_phone_number, annual_income, number_of_residents, number_of_cats, number_of_dogs) VALUES (@unitID, @firstName, @lastName, @socialSecurityNumber, @phoneNumber, @emailAddress, @lastResidenceOwner, @lastResidencePhoneNumber, @lastResidenceTenancyStartDate, @lastResidenceTenancyEndDate, @employmentStatus, @employerName, @employerContactPhoneNumber, @annualIncome, @numOfResidents, @numOfCats, @numOfDogs);";
        private const string SQL_GetAllApplications = "SELECT * FROM tenant_application WHERE application_approval_status IS NULL;";

        private string connectionString;

        public ApplicationDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool AddApplication(Application application)
        {
            bool result;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AddProperty, connection);

                    cmd.Parameters.AddWithValue("@unitID", application.UnitID);
                    cmd.Parameters.AddWithValue("@firstName", application.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", application.LastName);
                    cmd.Parameters.AddWithValue("@socialSecurityNumber", application.SocialSecurityNumber);
                    cmd.Parameters.AddWithValue("@phoneNumber", application.PhoneNumber);
                    cmd.Parameters.AddWithValue("@emailAddress", application.EmailAddress);
                    cmd.Parameters.AddWithValue("@lastResidenceOwner", application.LastResidenceOwner);
                    cmd.Parameters.AddWithValue("@lastResidencePhoneNumber", application.LastResidencePhoneNumber);
                    cmd.Parameters.AddWithValue("@lastResidenceTenancyStartDate", application.LastResidenceTenancyStartDate);
                    cmd.Parameters.AddWithValue("@lastResidenceTenancyEndDate", application.LastResidenceTenancyEndDate);
                    cmd.Parameters.AddWithValue("@employmentStatus", application.EmploymentStatus);
                    cmd.Parameters.AddWithValue("@employerName", application.EmployerName);
                    cmd.Parameters.AddWithValue("@employerContactPhoneNumber", application.EmployerContactPhoneNumber);
                    cmd.Parameters.AddWithValue("@annualIncome", application.AnnualIncome);
                    cmd.Parameters.AddWithValue("@numOfResidents", application.NumOfResidents);
                    cmd.Parameters.AddWithValue("@numOfCats", application.NumOfCats);
                    cmd.Parameters.AddWithValue("@numOfDogs", application.NumOfDogs);

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

        //Get All application was added to allow for proper testing.
        public List<Application> GetAllApplications()
        {
            List<Application> output = new List<Application>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllApplications, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Application application = new Application();

                        application.ApplicationID = Convert.ToInt32(reader["application_id"]);
                        application.UnitID = Convert.ToInt32(reader["unit_id"]);
                        application.FirstName = Convert.ToString(reader["first_name"]);
                        application.LastName = Convert.ToString(reader["last_name"]);
                        application.SocialSecurityNumber = Convert.ToInt32(reader["social_security_number"]);
                        application.PhoneNumber = Convert.ToString(reader["phone_number"]);
                        application.EmailAddress = Convert.ToString(reader["email_address"]);
                        application.LastResidenceOwner = Convert.ToString(reader["last_residence_owner"]);
                        application.LastResidencePhoneNumber = Convert.ToString(reader["last_residence_contact_phone_number"]);
                        application.LastResidenceTenancyStartDate = Convert.ToString(reader["last_residence_tenancy_start_date"]);
                        application.LastResidenceTenancyEndDate = Convert.ToString(reader["last_residence_tenancy_end_date"]);
                        application.EmploymentStatus = Convert.ToBoolean(reader["employment_status"]);
                        application.EmployerName = Convert.ToString(reader["employer_name"]);
                        application.EmployerContactPhoneNumber = Convert.ToString(reader["employer_contact_phone_number"]);
                        application.AnnualIncome = Convert.ToString(reader["annual_income"]);
                        application.NumOfResidents = Convert.ToInt32(reader["number_of_residents"]);
                        application.NumOfCats = Convert.ToInt32(reader["number_of_cats"]);
                        application.NumOfDogs = Convert.ToInt32(reader["number_of_dogs"]);
                        //application.ApplicationApprovalStatus = Convert.ToBoolean(reader["application_approval_status"]);

                        output.Add(application);
                    }
                }
            }
            catch (SqlException ex)
            {
                output = new List<Application>();
                throw ex;
            }

            return output;
        }
    }
}
