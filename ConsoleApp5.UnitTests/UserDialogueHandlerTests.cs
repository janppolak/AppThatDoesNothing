using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.UnitTests
{
    internal class UserDialogueHandlerTests
    {
        [Test]

        public void WhenAskedShouldReturnLong()
        {
            // not finished yet, don't look here

            // Arrange
            UserDialogueHandler.ReadInt("test", long.MinValue, long.MaxValue);

            // Act
            var input = "abc";

            // Assert
            Assert.IsTrue(true);
        }


    }
}
