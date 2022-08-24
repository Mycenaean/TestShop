using Domain.Implementations;

namespace Domain.Services
{
    public static class CheckoutFactory
    {
        public static ICheckout CreteNew()
        {
            return new Checkout();
        }
    }
}