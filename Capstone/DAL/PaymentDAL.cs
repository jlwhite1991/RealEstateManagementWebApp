using Capstone.DAL.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAL
{
    public class PaymentDAL : IPaymentDAL
    {
        private const string SQL_AddPayment = "INSERT INTO payment (unit_id, tenant_id, payment_amount, payment_date, payment_for_month) VALUES (@unitID, @tenant_id, @payment_amount, GETDATE(), @payment_for_month);";

        private string connectionString;

        public PaymentDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool SubmitPayment(Payment payment)
        {
            bool result;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AddPayment, connection);
                    cmd.Parameters.AddWithValue("@unitID", payment.UnitID);
                    cmd.Parameters.AddWithValue("@tenant_id", payment.TenantID);
                    cmd.Parameters.AddWithValue("@payment_amount", payment.PaymentAmount);
                    cmd.Parameters.AddWithValue("@payment_for_month", payment.PaymentForMonth);

                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            return result;
        }
    }
}
