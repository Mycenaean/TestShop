using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Abstractions;
using Domain.Services;

namespace Domain.Implementations
{
    internal class Cart : ICart
    {
        private readonly List<CartItemDescriptor> _addedItems;
        private readonly List<CartItem> _availableItems;

        public Cart(List<CartItem> availableItems)
        {
            _addedItems = new List<CartItemDescriptor>();

            _availableItems = availableItems;
        }

        public IReadOnlyList<CartItemDescriptor> GetItems()
        {
            return _addedItems.AsReadOnly();
        }

        public void AddItem(Guid itemId, int quantity)
        {
            if (itemId == Guid.Empty || quantity == 0)
            {
                return;
            }

            var item = _availableItems.FirstOrDefault(x => x.Id == itemId);

            if (item == null)
            {
                return;
            }
            
            _addedItems.Add(new CartItemDescriptor(item, quantity));
            
        }
    }
}