using Domain.Abstractions;

namespace Domain.Implementations
{
    public class CartItemDescriptor
    {
        public CartItem Item { get; }
        public int Quantity { get; }

        public CartItemDescriptor(CartItem item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
        
        public string GetItemInfo()
        {
            return $"{Quantity}x {Item.Name} | {Quantity * Item.Price}";
        }
    }
}