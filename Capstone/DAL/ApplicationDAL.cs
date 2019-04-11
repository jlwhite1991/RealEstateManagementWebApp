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
    }
}
