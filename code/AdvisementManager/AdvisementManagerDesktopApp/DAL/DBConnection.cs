using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AdvisementManagerDesktopApp.DAL
{
    class DBConnection
    {

        private static readonly string connStringPart1 = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= ";

        private static readonly string connStringPart3 =
            ";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        ///     Gets the connection.
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {

            const int firstHalfOfDirectoryPath = 0;
            
            var directoryPath = Environment.CurrentDirectory;

            var splitPath = directoryPath.Split("AdvisementManagerDesktopApp");

            var connDirectoryPath = splitPath[firstHalfOfDirectoryPath] + "ADVISEMENTMANAGERDESKTOPAPP\\ADVISEMENTMANAGMENTDB.MDF";

            var fullConn = connStringPart1 + connDirectoryPath + connStringPart3;

            var conn = new SqlConnection(fullConn);

            return conn;
        }
    }
}
