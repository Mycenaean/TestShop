using System;
using Domain.Entities;
using Domain.Utils;
using NUnit.Framework;

namespace DomainTests
{
    [TestFixture]
    public class RedWineTests
    {
        private static float _wineStartingPrice = 5;
        private static int[] DaysArray = { 2, 3, 4, 5, 6, 7 };
        private static int[] ExceedingDaysArray = { 196, 197, 205, 255, 275, 336, 356 };
        
        [TestCase]
        public void AddingFish_WithNegativeDays_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new RedWine(-1));
        }
        
        [TestCase]
        public void Adding_FreshWine_ReturnsPriceOf_5_AndNameContains_Fresh()
        {
            var wine = new RedWine(0);
            var price = MathUtility.RoundToTwoDecimals(wine.Price);
            Assert.AreEqual(_wineStartingPrice, price);
            Assert.AreEqual("Red Wine (fresh)", wine.Name);
        }

        [Test, TestCaseSource(nameof(DaysArray))]
        public void PriceOfRedWine_Is_Incremented_AccordingToDays(int day)
        {
            var wine = new RedWine(day);
            var price = MathUtility.RoundToTwoDecimals(wine.Price);
            Assert.AreEqual(_wineStartingPrice + day, price);
            Assert.AreEqual($"Red Wine ({day} days)", wine.Name);
        }

        [Test, TestCaseSource(nameof(ExceedingDaysArray))]
        public void PriceOfRedWine_Is_Set_To_200_When_NumberOfDaysExceeds_195(int day)
        {
            var wine = new RedWine(day);
            var price = MathUtility.RoundToTwoDecimals(wine.Price);
            Assert.AreEqual(200f, price);
            Assert.AreEqual($"Red Wine ({day} days)", wine.Name);
        }

        [TestCase]
        public void WhenDaysAreSetTo769_Name_Returns_2_Years_And_39_days()
        {
            var wine = new RedWine(769);
            Assert.AreEqual($"Red Wine (2 years and 39 days old)", wine.Name);
        }
    }
}