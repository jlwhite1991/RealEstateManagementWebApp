using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAL.Interfaces;
using System.Data.SqlClient;

namespace Capstone.DAL
{
    public class UserDAL : IUserDAL
    {
        private readonly string connectionString;

        public UserDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public User GetUser(string emailAddress)
        {
            User user = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM site_user WHERE email_address = @emailAddress;", conn);
                    cmd.Parameters.AddWithValue("@emailAddress", emailAddress);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = MapRowToUser(reader);
                    }
                }


            }
            catch (SqlException ex)
            {
                user = null;
            }

            return user;
        }

        public bool CreateUser(User user)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO users VALUES (@first_name, @last_name, @phone_number, @email_address, @role, @password, @salt);", conn);
                    cmd.Parameters.AddWithValue("@first_name", user.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", user.LastName);
                    cmd.Parameters.AddWithValue("@phone_number", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@email_address", user.EmailAddress);
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@password", user.Password );
                    cmd.Parameters.AddWithValue("@salt", user.Salt);

                    result = (cmd.ExecuteNonQuery() > 0) ? true : false;

                }
            }
            catch (SqlException ex)
            {
                result = false;
            }
            return result;
        }

        public bool UpdateUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE site_user SET password = @password, salt = @salt, role = @role WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@id", user.UserID);

                    return cmd.ExecuteNonQuery() >= 1 ? true : false;

                    
                }
            }
            catch (SqlException e)
            {

                throw e;
            }
        }

        public bool DeleteUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM site_user WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", user.UserID);

                    return cmd.ExecuteNonQuery() >= 1 ? true : false;

                    
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }


        }

        private User MapRowToUser(SqlDataReader reader)
        {
            return new User()
            {
                UserID = Convert.ToInt32(reader["id"]),
                EmailAddress = Convert.ToString(reader["email_address"]),
                Password = Convert.ToString(reader["password"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["role"]),
                FirstName = Convert.ToString(reader["first_name"]),
                LastName = Convert.ToString(reader["last_name"]),
                PhoneNumber = Convert.ToString(reader["phone_number"])
            };
        }
    }
}
