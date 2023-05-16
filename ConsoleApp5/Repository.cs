using System;
using System.Collections.Generic;
using ConsoleApp5.Model;
using Dapper.Contrib.Extensions;


namespace ConsoleApp5
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>() where T : Entity;
        T Get<T>(long id) where T : Entity;
        void InsertMany<T>(IEnumerable<T> entities) where T : Entity;
        void Insert<T>(T entity) where T : Entity;
        void Update<T>(Func<T> updateFunc) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
    }

    public class Repository : IRepository
    {
        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

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
                return connection.GetAll<T>();
            }
        }

        public void Insert<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void InsertMany<T>(IEnumerable<T> entities) where T : Entity
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Insert(entities);
            }
        }

        public void Update<T>(Func<T> updateFunc) where T : Entity
        {
            throw new NotImplementedException();
        }
    }

    public class FakeRepository : IRepository
    {
        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public T Get<T>(long id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public void Insert<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void InsertMany<T>(IEnumerable<T> entities) where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public void Update<T>(Func<T> updateFunc) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
