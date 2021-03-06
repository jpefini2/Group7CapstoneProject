﻿using System;
using Microsoft.Data.SqlClient;

namespace AdvisementManagerDesktopApp.DAL
{
    /// <summary>
    ///   The DBConnection class for accessing the database.
    /// </summary>
    public class DbConnection
    {
        private const string ConnStringPart1 = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=";

        private const string ConnStringPart3 = ";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        ///     Gets the connection that is used to access the database via the connection string. If the database is built
        ///     in the correct location the process is automatic otherwise the string must be manually edited in the method.
        /// </summary>
        /// <returns>
        ///   The SQL connection
        /// </returns>
        public static SqlConnection GetConnection()
        {

            const int firstHalfOfDirectoryPath = 0;
            var directoryPath = Environment.CurrentDirectory;

            string[] stringSeparators = new string[] { "AdvisementManagerDesktopApp" };
            var splitPath1 = directoryPath.Split(stringSeparators, StringSplitOptions.None);
            var connDirectoryPath = splitPath1[firstHalfOfDirectoryPath] + "ADVISEMENTMANAGERDESKTOPAPP\\ADVISEMENTMANAGMENTDB.MDF";
            var fullConn = ConnStringPart1 + connDirectoryPath + ConnStringPart3;

            return new SqlConnection(fullConn);
            //return new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\CapStone\Group7CapstoneProject\code\AdvisementManager\AdvisementManagerDesktopApp\ADVISEMENTMANAGERDB.mdf;Integrated Security=True");
        }
    }
}
