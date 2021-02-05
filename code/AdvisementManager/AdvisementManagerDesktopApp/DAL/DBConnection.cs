using System;
using Microsoft.Data.SqlClient;

namespace AdvisementManagerDesktopApp.DAL
{
    /// <summary>
    ///   The DBConnection class
    /// </summary>
    public class DbConnection
    {
        private const string ConnStringPart1 = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= ";

        private const string ConnStringPart3 = ";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>Gets the connection.</summary>
        /// <returns>
        ///   The SQL connection
        /// </returns>
        public static SqlConnection GetConnection()
        {

            const int firstHalfOfDirectoryPath = 0;
            var directoryPath = Environment.CurrentDirectory;

            var splitPath = directoryPath.Split("AdvisementManagerDesktopApp");
            var connDirectoryPath = splitPath[firstHalfOfDirectoryPath] + "ADVISEMENTMANAGERDESKTOPAPP\\ADVISEMENTMANAGMENTDB.MDF";
            var fullConn = ConnStringPart1 + connDirectoryPath + ConnStringPart3;

            var conn = new SqlConnection(fullConn);
            //var conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\CapStone\Group7CapstoneProject\code\AdvisementManager\AdvisementManagerDesktopApp\ADVISEMENTMANAGERDB.mdf;Integrated Security=True";

            //return new SqlConnection(conn);
            return conn;
        }
    }
}
