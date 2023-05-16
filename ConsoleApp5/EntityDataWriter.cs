using ConsoleApp5.Model;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class EntityDataWriter
    {
        private readonly IRepository _repository;
        public EntityDataWriter(IRepository repository)
        {
            _repository = repository;
        }

        public void InsertIntoDb<T>(IEnumerable<T> entities) where T : Entity
        {
            using (var connection = DbConnectionFactory.Create())
            {
                connection.Insert(entities);
            }
        }
    }
}
