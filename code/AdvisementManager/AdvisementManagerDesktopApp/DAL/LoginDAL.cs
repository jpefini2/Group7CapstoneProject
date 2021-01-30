using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

        internal void LogInUser(string username)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                const string query = @"SELECT * FROM Advisor WHERE username=@username;";
                var sqlCommand = new SqlCommand(query, conn);

                sqlCommand.Parameters.AddWithValue("username", username);
                conn.Open();
                SqlDataReader dr = sqlCommand.ExecuteReader();

                var templist = new List<string>();

                while (dr.Read())
                {
                    var advisorID = dr.GetInt32(0);
                    var firstName = dr.GetString(1);
                    var lastName = dr.GetString(2);
                    var isFacultyAdvisor = dr.GetBoolean(3);
                    var email = dr.GetString(4);

                    var s = advisorID + ", " + firstName + ", " + lastName + ", " + isFacultyAdvisor + ", " + email;
                    templist.Add(s);
                }

                foreach(string str in templist)
                {
                    Trace.WriteLine(str);
                }
            }
        }
    }
}
