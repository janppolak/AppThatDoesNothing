using Dapper.Contrib.Extensions;

namespace ConsoleApp5.Model
{
    [Table("Band")]
    public class Band : Entity
    {
        public string Name { get; set; }
        public decimal Rating { get; set; }

        [Computed]
        public Genre GenereEnum { get; set; }
        
        public string Genre => GenereEnum.ToString();

        public override string ToString()
        {
            return $"{Id} - Name: {Name} | Genre {GenereEnum} | Rating {Rating}";
        }
    }
}
