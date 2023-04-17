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

        public static void Connect(List<Band> bands)
        {
            string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=Bands;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            List<string> insertSql = new List<string>();

            foreach (Band band in bands)
            {
                insertSql.Add($"INSERT INTO dbo.[Bands] (Name, Rating, Genre) Values ('{band.Name}', {band.Rating}, '{band.Genre}')");
            }
            
            using (var connection = new SqlConnection(connectionString))
            {
                foreach (string sql in insertSql)
                {
                    var affectedRow = connection.Execute(sql); 
                    
                }
                
            }

        }
    }
}
