using System;
using Domain.Entities;
using Domain.Utils;
using NUnit.Framework;

namespace DomainTests
{
    [TestFixture]
    public class MilkTests
    {
        [TestCase]
        public void AddingMilk_WithNegativeDays_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Milk(-1));
        }
        
        [TestCase]
        public void Adding_OneFreshMilk_ReturnsPriceOf_3_70_AndNameContains_Fresh()
        {
            var milk = new Milk(0);
            var price = MathUtility.RoundToTwoDecimals(milk.Price);
            Assert.AreEqual(3.70f, price);
            Assert.AreEqual("Milk (fresh)", milk.Name);
        }
        
        [TestCase]
        public void Adding_1DayMilk_ReturnsPriceOf_1_85_AndNameContains_1_days()
        {
            var milk = new Milk(1);
            var price = MathUtility.RoundToTwoDecimals(milk.Price);
            Assert.AreEqual(1.85f, price);
            Assert.AreEqual("Milk (One day old)", milk.Name);
        }
        
        [TestCase]
        public void Adding_TwoDaysMilk_ReturnsPriceOf_1_57_AndNameContains_2_days()
        {
            var milk = new Milk(2);
            var price = MathUtility.RoundToTwoDecimals(milk.Price);
            Assert.AreEqual(1.57f, price);
            Assert.AreEqual("Milk (2 days)", milk.Name);
        }
        
        [TestCase]
        public void Adding_ThreeDaysMilk_ReturnsPriceOf_1_34_AndNameContains_3_days()
        {
            var milk = new Milk(3);
            var price = MathUtility.RoundToTwoDecimals(milk.Price);
            Assert.AreEqual(1.34f, price);
            Assert.AreEqual("Milk (3 days)", milk.Name);
        }
        
        [TestCase]
        public void Adding_FiveDaysMilk_ReturnsPriceOf_0_97_AndNameContains_5_days()
        {
            var milk = new Milk(5);
            var price = MathUtility.RoundToTwoDecimals(milk.Price);
            Assert.AreEqual(0.97f, price);
            Assert.AreEqual("Milk (5 days)", milk.Name);
        }
        
    }
}