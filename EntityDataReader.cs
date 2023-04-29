using ConsoleApp5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class EntityDataReader
    {
        private readonly IRepository _repository;
        public EntityDataReader(IRepository repository)
        {
            _repository = repository;
        }

        public void ListAllItems<T>() where T : Entity
        {
            var items = _repository.GetAll<T>();

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}
