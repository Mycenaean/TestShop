using Domain.Abstractions;

namespace Domain.Entities
{
    public class Wine : CartItem
    {
        protected override bool IsPriceIncreasing => true;
        protected override bool UsePercentageForPricing => false;
        protected override float StartingPrice { get; }
        protected override float PriceChangeValue => 1;
        private const float MaxPrice = 200;

        protected Wine(string name, float startingPrice, int daysOld) : base(name ,daysOld)
        {
            StartingPrice = startingPrice;
            CalculatePrice();
        }

        protected override void CalculatePrice(float price = 0)
        {
            base.CalculatePrice();
            Price = Price > MaxPrice ? MaxPrice : Price;
        }
        
    }
}