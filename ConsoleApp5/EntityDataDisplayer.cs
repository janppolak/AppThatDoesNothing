using ConsoleApp5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class EntityDataDisplayer
    {
        private readonly IRepository _repository;
        public EntityDataDisplayer(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> ListAllItems<T>() where T : Entity
        {
            var items = _repository.GetAll<T>();
            
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            return items;
        }
        
    }
}
