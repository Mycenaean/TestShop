using System;
using System.Collections.Generic;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Services;
using Domain.Utils;

namespace ShopApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var freshMilk = new Milk(0);
            var twoDaysOldMilk = new Milk(2);
            var twoDaysOldFish = new Fish(2);
            var tenYearsOldRedWine = new RedWine(10 * 365);
            var hounderdAndTwelvedaysOldRedWine = new RedWine(112);
            var thirtyDaysOldSparklingWine = new SparklingWine(30);

            var availableItems = new List<CartItem>
            {
                 freshMilk,
                 twoDaysOldMilk,
                 twoDaysOldFish,
                 tenYearsOldRedWine,
                 hounderdAndTwelvedaysOldRedWine,
                 thirtyDaysOldSparklingWine
            };

            var cart = CartFactory.CreateNew(availableItems);
            
            cart.AddItem(freshMilk.Id, 1);
            cart.AddItem(twoDaysOldMilk.Id, 1);
            cart.AddItem(twoDaysOldFish.Id, 2);
            cart.AddItem(tenYearsOldRedWine.Id, 1);
            cart.AddItem(hounderdAndTwelvedaysOldRedWine.Id, 2);
            cart.AddItem(thirtyDaysOldSparklingWine.Id, 1);

            var checkout = CheckoutFactory.CreteNew();
            
            checkout.CreateReceipt(cart);
            Console.WriteLine($"Total Sum | {MathUtility.RoundToTwoDecimals(checkout.TotalPrice)}");
            Console.ReadLine();
        }
    }
}