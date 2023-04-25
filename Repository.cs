using System.Collections.Generic;
using ConsoleApp5.Model;
using Dapper.Contrib.Extensions;


namespace ConsoleApp5
{
    public static class Repository
    {
        public static void InsertIntoDb<T>(IEnumerable<T> entities) where T : Entity
        {            
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Insert(entities);
            }
        }

        public static IEnumerable<T> GetAll<T>() where T : Entity
        {
            using (var connection = DbConnectionFactory.Create())
            {
                return connection.GetAll<T>();
            }
        }
    }
}
