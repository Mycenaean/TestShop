using System;
using Domain.Entities;
using Domain.Utils;
using NUnit.Framework;

namespace DomainTests
{
    [TestFixture]
    public class SparklingWineTests
    {
        private static float _wineStartingPrice = 7;
        private static int[] DaysArray = { 2, 3, 4, 5, 6, 7 };
        private static int[] ExceedingDaysArray = { 196, 197, 205, 255, 275, 336, 356 };
        
        [TestCase]
        public void AddingFish_WithNegativeDays_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new SparklingWine(-1));
        }
        
        [TestCase]
        public void Adding_FreshWine_ReturnsPriceOf_7_AndNameContains_Fresh()
        {
            var wine = new SparklingWine(0);
            var price = MathUtility.RoundToTwoDecimals(wine.Price);
            Assert.AreEqual(_wineStartingPrice, price);
            Assert.AreEqual("Sparkling Wine (fresh)", wine.Name);
        }

        [Test, TestCaseSource(nameof(DaysArray))]
        public void PriceOfSparklingWine_Is_Incremented_AccordingToDays(int day)
        {
            var wine = new SparklingWine(day);
            var price = MathUtility.RoundToTwoDecimals(wine.Price);
            Assert.AreEqual(_wineStartingPrice + day, price);
            Assert.AreEqual($"Sparkling Wine ({day} days)", wine.Name);
        }
        
        [Test, TestCaseSource(nameof(ExceedingDaysArray))]
        public void PriceOfSparklingWine_Is_Set_To_200_When_NumberOfDaysExceeds_195(int day)
        {
            var wine = new SparklingWine(day);
            var price = MathUtility.RoundToTwoDecimals(wine.Price);
            Assert.AreEqual(200f, price);
            Assert.AreEqual($"Sparkling Wine ({day} days)", wine.Name);
        }

        [TestCase]
        public void WhenDaysAreSetTo450_Name_Returns_1_Years()
        {
            var wine = new SparklingWine(450);
            Assert.AreEqual($"Sparkling Wine (One year and 85 days old)", wine.Name);
        }
    }
}