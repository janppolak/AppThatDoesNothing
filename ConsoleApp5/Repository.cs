using System.Collections.Generic;
using ConsoleApp5.Model;
using Dapper.Contrib.Extensions;


namespace ConsoleApp5
{
    public interface IRepository
    {
        //    void InsertIntoDb<T>(IEnumerable<T> entities) where T : Entity;
        IEnumerable<T> GetAll<T>() where T : Entity;
    }

    public class Repository : IRepository
    {
        //public void InsertIntoDb<T>(IEnumerable<T> entities) where T : Entity
        //{
        //    using (var connection = DbConnectionFactory.Create())
        //    {
        //        connection.Insert(entities);
        //    }
        //}

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            using (var connection = DbConnectionFactory.Create())
            {
                return connection.GetAll<T>();
            }
        }
    }

    public class FakeRepository : IRepository
    {
        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public void InsertIntoDb<T>(IEnumerable<T> entities) where T : Entity
        {
            throw new System.NotImplementedException();
        }
    }
}
