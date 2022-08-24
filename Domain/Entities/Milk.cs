using Domain.Abstractions;

namespace Domain.Entities
{
    public class Milk : CartItem
    {
        protected override bool IsPriceIncreasing => false;
        protected override bool UsePercentageForPricing => true;
        protected override float StartingPrice => 3.70f;
        protected override float PriceChangeValue => 15;

        private const float FirstDaysPriceChangeValue = 50;


        public Milk(int daysOld) : base(nameof(Milk), daysOld)
        {
            CalculatePrice();
        }

        protected override void CalculatePrice(float price = 0)
        {
            if (DaysOld >= 1)
            {
                price = StartingPrice * FirstDaysPriceChangeValue / 100;

                DaysOld--;
            }

            base.CalculatePrice(price);
        }
    }
}