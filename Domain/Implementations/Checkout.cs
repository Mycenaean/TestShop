using System;
using Domain.Services;
using Domain.Utils;

namespace Domain.Implementations
{
    internal class Checkout : ICheckout
    {
        public float TotalPrice { get; private set; }

        public void CreateReceipt(ICart cart)
        {
            var itemDescriptors = cart.GetItems();
            
            float sum = 0;
            
            foreach (var itemDescriptor in itemDescriptors)
            {
                Console.WriteLine(itemDescriptor.GetItemInfo());
                
                sum += itemDescriptor.Quantity * itemDescriptor.Item.Price;
            }

            TotalPrice = sum;
        }
    }
}