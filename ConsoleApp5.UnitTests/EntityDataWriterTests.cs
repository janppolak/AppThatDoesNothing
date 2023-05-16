using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp5.Model;
using NUnit.Framework;

namespace ConsoleApp5.UnitTests
{
    [TestFixture]
    internal class EntityDataReaderTests
    {
        [Test]
        public void SelectBendBand()
        {
            // Arrange
            var bands = new List<Band>()
            {
                new Band()
                {
                    Name = "Dream Theater",
                    GenereEnum = Genre.Metal,
                    Rating = 4
                },
                new Band()
                {
                    Name = "Metallica",
                    GenereEnum = Genre.Metal,
                    Rating = 5
                },
            };

            // Act

            var bestBand = bands.SelectBestBands();

            // Assert

            Assert.That(bestBand.Count, Is.EqualTo(1));
            Assert.That(bestBand.First().Name, Is.EqualTo("Metallica"));
        }
    }
}
