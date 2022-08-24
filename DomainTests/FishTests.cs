using System;
using Domain.Entities;
using Domain.Utils;
using NUnit.Framework;

namespace DomainTests
{
    [TestFixture]
    public class FishTests
    {
        [TestCase]
        public void AddingFish_WithNegativeDays_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Fish(-1));
        }
        
        [TestCase]
        public void Adding_Fresh_ReturnsPriceOf_5_AndNameContains_Fresh()
        {
            var fish = new Fish(0);
            var price = MathUtility.RoundToTwoDecimals(fish.Price);
            Assert.AreEqual(5, price);
            Assert.AreEqual("Fish (fresh)", fish.Name);
        }
        
        [TestCase]
        public void Adding_1DayFish_ReturnsPriceOf_4_5_AndNameContains_1_days()
        {
            var fish = new Fish(1);
            var price = MathUtility.RoundToTwoDecimals(fish.Price);
            Assert.AreEqual(4.5f, price);
            Assert.AreEqual("Fish (One day old)", fish.Name);
        }
        
        [TestCase]
        public void Adding_TwoDaysFish_ReturnsPriceOf_4_05_AndNameContains_2_days()
        {
            var fish = new Fish(2);
            var price = MathUtility.RoundToTwoDecimals(fish.Price);
            Assert.AreEqual(4.05f, price);
            Assert.AreEqual("Fish (2 days)", fish.Name);
        }
        
        [TestCase]
        public void Adding_ThreeDaysFish_ReturnsPriceOf_3_65_AndNameContains_3_days()
        {
            var fish = new Fish(3);
            var price = MathUtility.RoundToTwoDecimals(fish.Price);
            Assert.AreEqual(3.65f, price);
            Assert.AreEqual("Fish (3 days)", fish.Name);
        }
        
        [TestCase]
        public void Adding_FiveDaysFish_ReturnsPriceOf_2_95_AndNameContains_5_days()
        {
            var fish = new Fish(5);
            var price = MathUtility.RoundToTwoDecimals(fish.Price);
            Assert.AreEqual(2.95f, price);
            Assert.AreEqual("Fish (5 days)", fish.Name);
        }
    }
}