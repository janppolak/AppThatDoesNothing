using Dapper.Contrib.Extensions;

namespace ConsoleApp5.Model
{
    [Table("Band")]
    public class Band : Entity
    {
        public string Name { get; set; }
        public decimal Rating { get; set; }

        [Computed]
        public Genre GenreEnum { get; set; }

        public string Genre => GenreEnum.ToString();


        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            return $"{Id} - Name: {Name} | Genre {GenreEnum} | Rating {Rating}";
        }
    }
}
