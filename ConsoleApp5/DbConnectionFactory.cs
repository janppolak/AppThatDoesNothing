using Microsoft.Data.SqlClient;

namespace ConsoleApp5
{
    public static class DbConnectionFactory
    {
        private const string ConnectionString = @"Data Source=.\SQLExpress;Initial Catalog=Bands;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection Create()
        {
            return new SqlConnection(ConnectionString);
        }
    }

}
