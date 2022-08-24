using Domain.Abstractions;

namespace Domain.Entities
{
    public class Fish : CartItem
    {
        protected override bool IsPriceIncreasing => false;
        protected override bool UsePercentageForPricing => true;
        protected override float StartingPrice => 5;
        protected override float PriceChangeValue => 10;

        public Fish(int daysOld) : base(nameof(Fish), daysOld)
        {
            CalculatePrice();
        }
    }
}