using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using AdvisementManagerDesktopApp.Model;

namespace AdvisementManagerDesktopApp.DAL
{
    class LoginDAL
    {

        public bool Authenticate(string username, string password)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                const string query = @"SELECT * FROM Login WHERE username=@username AND password=@password;";
                var sqlCommand = new SqlCommand(query, conn);

                sqlCommand.Parameters.AddWithValue("username", username);
                sqlCommand.Parameters.AddWithValue("password", password);

                conn.Open();
                SqlDataReader dr = sqlCommand.ExecuteReader();
                if (dr.HasRows) return true;
                conn.Close();
                return false;
            }
        }

        internal Advisor LogInUser(string username)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                const string query = @"SELECT * FROM Advisor WHERE username=@username;";
                var sqlCommand = new SqlCommand(query, conn);

                sqlCommand.Parameters.AddWithValue("username", username);
                conn.Open();
                SqlDataReader dr = sqlCommand.ExecuteReader();

                var templist = new List<Advisor>();

                while (dr.Read())
                {
                    var advisor = new Advisor
                    {
                        Id = dr.GetInt32(0),
                        FirstName = dr.GetString(1),
                        LastName = dr.GetString(2),
                        IsFacultyAdvisor = dr.GetBoolean(3),
                        Email = dr.GetString(4)
                    };

                    templist.Add(advisor);
                };
                return templist.First();                
            }
        }
    }
}
