using System.Collections.Generic;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Services;
using NUnit.Framework;

namespace DomainTests
{
    [TestFixture]
    public class CartTests
    {
        [TestCase]
        public void Adding_ZeroQuantityItems_Are_Ignored()
        {
            var freshMilk = new Milk(0);
            var twoDaysOldMilk = new Milk(2);
            
            var availableItems = new List<CartItem>
            {
                freshMilk,
                twoDaysOldMilk
            };

            var cart = CartFactory.CreateNew(availableItems);
            cart.AddItem(freshMilk.Id, 0);
            cart.AddItem(twoDaysOldMilk.Id, 0);

            var checkout = CheckoutFactory.CreteNew();
            checkout.CreateReceipt(cart);
            
            Assert.AreEqual(0f, checkout.TotalPrice);
        }
        
        [TestCase]
        public void Adding_Two_FreshMilks_Returns_Price_Of_7_40()
        {
            var freshMilk = new Milk(0);
            
            var availableItems = new List<CartItem>
            {
                freshMilk
            };

            var cart = CartFactory.CreateNew(availableItems);
            cart.AddItem(freshMilk.Id, 2);

            var checkout = CheckoutFactory.CreteNew();
            checkout.CreateReceipt(cart);
            
            Assert.AreEqual(7.40f, checkout.TotalPrice);
        }
        
        [TestCase]
        public void Adding_Two_FreshMilks_AndOneTwoDayMilk_Returns_Price_Of_8_97()
        {
            var freshMilk = new Milk(0);
            var twoDaysOldMilk = new Milk(2);
            
            var availableItems = new List<CartItem>
            {
                freshMilk,
                twoDaysOldMilk
            };

            var cart = CartFactory.CreateNew(availableItems);
            cart.AddItem(freshMilk.Id, 2);
            cart.AddItem(twoDaysOldMilk.Id, 1);

            var checkout = CheckoutFactory.CreteNew();
            checkout.CreateReceipt(cart);
            
            Assert.AreEqual(8.97f, checkout.TotalPrice);
        }

        [TestCase]
        public void Adding_OneFreshMilk_AndTwo_TwoDaysFish_Returns_Price_Of_11_8()
        {
            var freshMilk = new Milk(0);
            var twoDaysOldFish = new Fish(2);
            
            var availableItems = new List<CartItem>
            {
                freshMilk,
                twoDaysOldFish
            };

            var cart = CartFactory.CreateNew(availableItems);
            cart.AddItem(freshMilk.Id, 1);
            cart.AddItem(twoDaysOldFish.Id, 2);

            var checkout = CheckoutFactory.CreteNew();
            checkout.CreateReceipt(cart);
            
            Assert.AreEqual(11.8f, checkout.TotalPrice);
        }

        [TestCase]
        public void AddTwo_HundredDaysOldRedWines_And_One_FreshFish_Returns_Price_Of_215()
        {
            var hundredDaysOldRedWine = new RedWine(100);
            var freshFish = new Fish(0);
            
            var availableItems = new List<CartItem>
            {
                hundredDaysOldRedWine,
                freshFish
            };

            var cart = CartFactory.CreateNew(availableItems);
            cart.AddItem(freshFish.Id, 1);
            cart.AddItem(hundredDaysOldRedWine.Id, 2);

            var checkout = CheckoutFactory.CreteNew();
            checkout.CreateReceipt(cart);
            
            Assert.AreEqual(215f, checkout.TotalPrice);
        }

        [TestCase]
        public void Adding_FiveYearsOld_SparklingWine_And_Three2DayMilks_Returns_Price_Of_203_14()
        {
            var fiveYearsOldRedWine = new SparklingWine(365 * 5);
            var twoDaysOldMilk = new Milk(2);
            
            var availableItems = new List<CartItem>
            {
                fiveYearsOldRedWine,
                twoDaysOldMilk
            };

            var cart = CartFactory.CreateNew(availableItems);
            cart.AddItem(fiveYearsOldRedWine.Id, 1);
            cart.AddItem(twoDaysOldMilk.Id, 2);

            var checkout = CheckoutFactory.CreteNew();
            checkout.CreateReceipt(cart);
            
            Assert.AreEqual(203.14f, checkout.TotalPrice);
        }

        [TestCase]
        public void Adding_TenDaysOld_Milk_And_FiftyDaysOldSparklingWine_AndTwelveDaysOldFish_Returns_Price_Of_58_84()
        {
            var tenDaysOldMilk = new Milk(10);
            var fiftyDaysOldRedWine = new SparklingWine(50);
            var twelveDaysOldFish = new Fish(12);
            
            var availableItems = new List<CartItem>
            {
                tenDaysOldMilk,
                fiftyDaysOldRedWine,
                twelveDaysOldFish
            };

            var cart = CartFactory.CreateNew(availableItems);
            cart.AddItem(tenDaysOldMilk.Id, 1);
            cart.AddItem(fiftyDaysOldRedWine.Id, 1);
            cart.AddItem(twelveDaysOldFish.Id, 1);

            var checkout = CheckoutFactory.CreteNew();
            checkout.CreateReceipt(cart);
            
            Assert.AreEqual(58.84f, checkout.TotalPrice);
        }
    }
}