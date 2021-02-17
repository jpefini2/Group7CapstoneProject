using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using AdvisementManagerDesktopApp.Model;

namespace AdvisementManagerDesktopApp.DAL
{
    class LoginDAL
    {
        /// <summary>
        /// Authenticates the user. Checks to see if the username matches in the Advisor and Login table.
        /// Checks if the matched username also matches the input password.
        /// </summary>
        /// <param name="username">The input username.</param>
        /// <param name="password">The input password.</param>
        /// <returns>True if credentials matched, false otherwise.</returns>
        public bool Authenticate(string username, string password)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                const string advisorQuery = @"SELECT * FROM Login, Advisor WHERE Login.username = Advisor.username AND Advisor.username = @username;";

                var advisorCommand = new SqlCommand(advisorQuery, conn);
                advisorCommand.Parameters.AddWithValue("username", username);

                conn.Open();
                SqlDataReader dr = advisorCommand.ExecuteReader();
                bool hasRows = dr.HasRows;

                string hash = null;
                bool matched = false;

                while(dr.Read())
                {
                    hash = dr.GetString(1);
                }

                if(hash != null)
                {
                    matched = BCrypt.Net.BCrypt.Verify(password, hash);
                }
                

                conn.Close();
                return matched;
            }
        }

        /// <summary>
        /// Obtains the Advisor object that matches the specified username.
        /// </summary>
        /// <param name="username">the input username.</param>
        /// <returns>The advisor that holds the foreign key that matches this username.</returns>
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
