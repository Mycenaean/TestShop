using System.Collections.Generic;
using Domain.Abstractions;
using Domain.Implementations;

namespace Domain.Services
{
    public static class CartFactory
    {
        public static ICart CreateNew(List<CartItem> availableItems)
        {
            return new Cart(availableItems);
        }
    }
}