using Dapper.Contrib.Extensions;

namespace ConsoleApp5.Model
{
    public abstract class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}
