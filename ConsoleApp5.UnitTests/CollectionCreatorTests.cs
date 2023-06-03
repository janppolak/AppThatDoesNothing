using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp5.Model;
using NUnit.Framework;

namespace ConsoleApp5.UnitTests
{
    internal class CollectionCreatorTests
    {
        [Test]
        
        public void CheckIfQuantityOfItemsIsCorrect()
        {
            // Arrange

            var list = CollectionCreator.CreateBandList();

            // Act

            var result = list.Count();

            // Assert

            Assert.AreEqual(2, result);
        }
    
    }
}
