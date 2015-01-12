using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatternsSandbox;

namespace DesignPatterns.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_For_When_Given_A_Different_Shape()
        {
            // Arrange
            var myFactory = FactoryProducer.getFactory("Shape");
            
            
            // Act
            var shape1 = myFactory.getShape("Triangle");

            // Assert
            Assert.AreEqual(shape1, null);

        }
    }
}
