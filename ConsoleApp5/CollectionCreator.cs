using ConsoleApp5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal static class CollectionCreator
    {
        public static IEnumerable<Band> CreateBandList()
        {
            yield return new Band { Name = "Dream Theater", Rating = 99.99M, GenereEnum = Genre.Blues };
            yield return new Band { Name = "Symphony X", Rating = 3.33M, GenereEnum = Genre.Blues };

        }
        public static IEnumerable<Band> SelectBestBands(this IEnumerable<Band> bands)
        {
            var startsWithMDescenting = bands.Where(band => band.Name.StartsWith("M")).OrderByDescending(band => band.Rating);

            return startsWithMDescenting;
        }

        public static void DisplayItems(IEnumerable<Band> bands)
        {
            foreach (var band in bands)
            {
                Console.WriteLine($"{ band.Name.ToUpper()}, {band.GenereEnum}, {band.Rating}");
            }
        }
    }
}
