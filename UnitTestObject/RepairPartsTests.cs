using Data_BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestObject
{
    public class RepairPartsTests
    {
        [Fact]
        public void RepairParts_Should_Trigger_PropertyChanged_When_Price_Changes()
        {
            // Arrange
            var part = new RepairParts();
            bool propertyChangedTriggered = false;
            part.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(RepairParts.Price))
                    propertyChangedTriggered = true;
            };

            // Act
            part.Price = 100;

            // Assert
            Assert.True(propertyChangedTriggered);
        }

        [Fact]
        public void RepairParts_Should_Set_Properties_Correctly()
        {
            // Arrange
            var part = new RepairParts
            {
                Name = "Screen",
                Price = 150
            };

            // Act & Assert
            Assert.Equal("Screen", part.Name);
            Assert.Equal(150, part.Price);
        }
    }
}
