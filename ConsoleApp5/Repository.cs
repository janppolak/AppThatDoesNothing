using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp5.Model;
using Dapper;
using Dapper.Contrib.Extensions;


namespace ConsoleApp5
{
    public interface IRepository
    {
        T Get<T>(long id) where T : Entity;
        IEnumerable<T> GetAll<T>() where T : Entity;
        void InsertMany<T>(IEnumerable<T> entities) where T : Entity;
        void Insert<T>(T entity) where T : Entity;
        void Update<T>(T entityToBeUpdated, Action<T> updateFunc) where T : Entity;
        void Delete<T>(T entityToBeDeleted, Action<T> updateFunc) where T : Entity;
    }

    public class Repository : IRepository
    {
        public T Get<T>(long id) where T : Entity
        {
            using (var connection = DbConnectionFactory.Create())
            {
                return connection.Get<T>(id);
            }
        }
        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            using (var connection = DbConnectionFactory.Create())
            {
                string sql = "SELECT * FROM Band WHERE IsDeleted = 0";
                return (IEnumerable<T>)connection.Query<T>(sql);
            }
        }
        public void Insert<T>(T entity) where T : Entity
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Insert<T>(entity);
            }
        }
        public void InsertMany<T>(IEnumerable<T> entities) where T : Entity
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Insert(entities);
            }
        }
        public void Update<T>(T entityToBeUpdated, Action<T> updateFunc) where T : Entity
        {
            updateFunc(entityToBeUpdated);
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Update<T>(entityToBeUpdated);
            }
        }
        public void Delete<T>(T entityToBeDeleted, Action<T> updateFunc) where T : Entity
        {
            updateFunc(entityToBeDeleted);
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Update<T>(entityToBeDeleted);
            }
        }

        //public class FakeRepository : IRepository
        //{
        //    public void Delete<T>(T entity) where T : Entity
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public T Get<T>(long id) where T : Entity
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public IEnumerable<T> GetAll<T>() where T : Entity
        //    {
        //        throw new System.NotImplementedException();
        //    }

        //    public void Insert<T>(T entity) where T : Entity
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void InsertMany<T>(IEnumerable<T> entities) where T : Entity
        //    {
        //        throw new System.NotImplementedException();
        //    }

        //    public void Update<T>(T entityToBeUpdated, Action<T> updateFunc) where T : Entity
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
