using AdvisementManagerDesktopApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerDesktopApp.DAL
{
    public class AvailabilityDAL
    {
        public void UpdateAvailability(Advisor advisor, Dictionary<string, List<string>> timeSlots)
        {
            int advisorId = advisor.Id;
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string updateQuery =
                    "INSERT INTO Availability (dayOfTheWeek, timeBegin, timeEnd, advisorID) VALUES (@dayOfTheWeek, @timeBegin, @timeEnd, @advisorID);";
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@advisorID", SqlDbType.VarChar);
                    cmd.Parameters.Add("@dayOfTheWeek", SqlDbType.Int);
                    cmd.Parameters.Add("@timeBegin", SqlDbType.VarChar);
                    cmd.Parameters.Add("@timeEnd", SqlDbType.VarChar);

                    cmd.Parameters["@advisorID"].Value = advisorId;

                    foreach (KeyValuePair<string, List<string>> entry in timeSlots)
                    {
                        var dayInt = 0;

                        if (entry.Key.Equals("Sunday"))
                        {
                            dayInt = 1;
                        }
                        else if (entry.Key.Equals("Monday"))
                        {
                            dayInt = 2;
                        }
                        else if (entry.Key.Equals("Tuesday"))
                        {
                            dayInt = 3;
                        }
                        else if (entry.Key.Equals("Wednesday"))
                        {
                            dayInt = 4;
                        }
                        else if (entry.Key.Equals("Thursday"))
                        {
                            dayInt = 5;
                        }
                        else if (entry.Key.Equals("Friday"))
                        {
                            dayInt = 6;
                        }
                        else if (entry.Key.Equals("Saturday"))
                        {
                            dayInt = 7;
                        }
                        cmd.Parameters["@dayOfTheWeek"].Value = dayInt;

                        foreach (string time in entry.Value)
                        {
                            string timeBegin = time.Split('-')[0];
                            string timeEnd = time.Split('-')[1];
                            cmd.Parameters["@timeBegin"].Value = timeBegin;
                            cmd.Parameters["@timeEnd"].Value = timeEnd;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Removes all rows in the Availability table belonging to the specified Advisor
        /// </summary>
        /// <param name="advisor">The Advisor</param>
        public void ClearAvailability(Advisor advisor)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string deleteQuery =
                    "DELETE FROM Availability WHERE advisorId = @advisorId";

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.Add("@advisorID", SqlDbType.Int);
                    cmd.Parameters["@advisorID"].Value = advisor.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        ///     Obtains a list of all availability timeslots in the Availability table belonging to the specified advisor
        /// </summary>
        /// <param name="advisor">The Adivsor</param>
        /// <returns>A list of the Advisor's availability</returns>
        public IList<Availability> ObtainAvailability(Advisor advisor)
        {
            List<Availability> availabilities;

            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string selectQuery =
                    "SELECT availabilityID, dayOfTheWeek, timeBegin, timeEnd FROM Availability WHERE advisorID = @advisorID";

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add("@advisorID", SqlDbType.Int);
                    cmd.Parameters["@advisorID"].Value = advisor.Id;

                    availabilities = this.createAvailabilities(cmd, advisor.Id);
                }
            }

            return availabilities;
        }

        private List<Availability> createAvailabilities(Microsoft.Data.SqlClient.SqlCommand cmd, int advisorId)
        {
            var availability = new List<Availability>();
            using var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                var availabilityIdOrdinal = reader.GetOrdinal("availabilityID");
                var dayOfTheWeekOrdinal = reader.GetOrdinal("dayOfTheWeek");
                var timeBeginOrdinal = reader.GetOrdinal("timeBegin");
                var timeEndOrdinal = reader.GetOrdinal("timeEnd");

                while (reader.Read())
                {
                    availability.Add(new Availability
                    {
                        Id = reader[availabilityIdOrdinal] == DBNull.Value ? 0 : reader.GetInt32(availabilityIdOrdinal),
                        DayOfTheWeek = reader[dayOfTheWeekOrdinal] == DBNull.Value ? 0 : reader.GetInt32(dayOfTheWeekOrdinal),
                        StartTime = reader[timeBeginOrdinal] == DBNull.Value ? TimeSpan.MinValue : reader.GetTimeSpan(timeBeginOrdinal),
                        EndTime = reader[timeBeginOrdinal] == DBNull.Value ? TimeSpan.MaxValue : reader.GetTimeSpan(timeEndOrdinal),
                        AdvisorId = advisorId
                    });
                }
            }

            return availability;
        }
    }
}
