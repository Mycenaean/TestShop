using System;
using System.Collections.Generic;
using Domain.Implementations;

namespace Domain.Services
{
    public interface ICart
    {
        IReadOnlyList<CartItemDescriptor> GetItems();
        void AddItem(Guid itemId, int quantity);
    }
    
}