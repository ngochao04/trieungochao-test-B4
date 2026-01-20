using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Baitapbuoi4
{
    public class OrganizationRepository
    {
        private readonly string _connectionString;

        public OrganizationRepository()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["DBConnection"].ConnectionString;
        }

        // 1. Kiểm tra trùng OrgName
        public bool IsOrgNameExists(string orgName)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM ORGANIZATION WHERE OrgName = @OrgName";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@OrgName", orgName);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // 2. Thêm Organization
        public void Insert(Organization org)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"
                    INSERT INTO ORGANIZATION
                    (OrgName, Address, Phone, Email, CreatedDate)
                    VALUES
                    (@OrgName, @Address, @Phone, @Email, @CreatedDate)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@OrgName", org.OrgName);
                cmd.Parameters.AddWithValue("@Address", org.Address);
                cmd.Parameters.AddWithValue("@Phone", org.Phone);
                cmd.Parameters.AddWithValue("@Email", org.Email);
                cmd.Parameters.AddWithValue("@CreatedDate", org.CreatedDate);

                cmd.ExecuteNonQuery();
            }
        }
    }
}