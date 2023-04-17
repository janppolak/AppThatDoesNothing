using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class CollectionCreator
    {
        public static List<Band> CreateBandList()
        {
            var bands = new List<Band>();
            bands.Add(new Band { Name = "Metallica", Rating = 5, Genre = Genre.Metal });
            bands.Add(new Band { Name = "Eminem", Rating = 3, Genre = Genre.Rap });
            bands.Add(new Band { Name = "Mozart", Rating = 1, Genre = Genre.Classical });

            return bands;
        }
    }
}
