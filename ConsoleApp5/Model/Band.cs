using Dapper.Contrib.Extensions;

namespace ConsoleApp5.Model
{
    [Table("Band")]
    internal class Band : Entity
    {
        [Key]
        public long BandId { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }

        [Computed]
        public Genre GenereEnum { get; set; }
        
        public string Genre => GenereEnum.ToString();

        public override string ToString()
        {
            return $"{BandId} - Name: {Name} | Genre {GenereEnum} | Rating {Rating}";
        }
    }
}
