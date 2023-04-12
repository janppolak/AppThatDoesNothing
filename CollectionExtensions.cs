using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class CollectionExtensions
    {

        public static IEnumerable<Band> SelectBestBand(List<Band> bands)
        {
            var startsWithMDescenting = bands.Where(band => band.Name.StartsWith("M")).OrderByDescending(band => band.Rating);

            return startsWithMDescenting;
        }

        public static void DisplayItems(IEnumerable<Band> bands)
        {
            foreach (var band in bands)
            {
                Console.WriteLine($"{ band.Name.ToUpper()}, {band.Genre}, {band.Rating}");
            }
        }
    }
}
