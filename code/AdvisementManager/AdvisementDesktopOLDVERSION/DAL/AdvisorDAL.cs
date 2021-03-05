using AdvisementManagerDesktopApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerDesktopApp.DAL
{
    public class AdvisorDAL
    {

        /// <summary>Obtains the advisor for the specified ID.</summary>
        /// <param name="advisorID">The advisor identifier.</param>
        /// <returns>an adivosr with their first and last name and the boolean of if they are a faculty advisor or not.</returns>
        public Advisor ObtainAdvisor(int advisorID)
        {
            Advisor advisor;
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string selectQuery = "SELECT firstName, lastName, isFacultyAdvisor FROM Advisor WHERE advisorID = @advisorID";

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add("@advisorID ", SqlDbType.Int);
                    cmd.Parameters["@advisorID "].Value = advisorID;

                    advisor = this.createAdvisor(cmd, advisorID);
                }
            }

            return advisor;
        }

        private Advisor createAdvisor(Microsoft.Data.SqlClient.SqlCommand cmd, int advisorID)
        {
            Advisor advisor = new Advisor();
            using var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                var firstNameOrdinal = reader.GetOrdinal("firstName");
                var lastNameOrdinal = reader.GetOrdinal("lastName");
                var isFacultyAdvisorOrdinal = reader.GetOrdinal("isFacultyAdvisor");

                while (reader.Read())
                {
                    advisor = new Advisor {
                        Id = advisorID,
                        FirstName = reader[firstNameOrdinal] == DBNull.Value ? null : reader.GetString(firstNameOrdinal),
                        LastName = reader[lastNameOrdinal] == DBNull.Value ? null : reader.GetString(lastNameOrdinal),
                        IsFacultyAdvisor = reader[isFacultyAdvisorOrdinal] != DBNull.Value && reader.GetBoolean(isFacultyAdvisorOrdinal),
                    };
                }
            }

            return advisor;
        }
    }
}
