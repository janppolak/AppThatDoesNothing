using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;


namespace ConsoleApp5
{
    internal class DbConnection
    {

        public static void Connect()
        {
            string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Bands;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string insertSql = "INSERT INTO dbo.[Bands] (Name, Rating, Genre) Values ('Metallica', 5.5, 'Metal');";

            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRow = connection.Execute(insertSql);
                Console.WriteLine("Affected Row: " + affectedRow);
            }
        }
    }
}
