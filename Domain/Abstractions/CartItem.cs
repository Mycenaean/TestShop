using System;
using Domain.Utils;

namespace Domain.Abstractions
{
    public abstract class CartItem
    {
        public Guid Id { get; }
        public string Name { get; }
        public float Price { get; protected set; }
        protected int DaysOld { get; set; }
        protected abstract bool IsPriceIncreasing { get; }
        protected abstract bool UsePercentageForPricing { get; }
        protected abstract float StartingPrice { get; }
        protected abstract float PriceChangeValue { get; }

        protected CartItem(string name, int daysOld)
        {
            if (daysOld < 0)
            {
                throw new ArgumentException(nameof(daysOld));
            }
            
            Id = Guid.NewGuid();
            DaysOld = daysOld;
            Name = $"{name} ({GetNameAccordingToDays()})";
        }
        
        private string GetNameAccordingToDays()
        {
            string nameDescriptorAccordingToName;
            switch (DaysOld)
            {
                case 0:
                    nameDescriptorAccordingToName = "fresh";
                    break;
                case > 365:
                {
                    var years = DaysOld / 365;
                    var days = DaysOld % 365;
                
                    nameDescriptorAccordingToName = years == 1
                        ? "One year"
                        : $"{years} years";

                    if (days > 0)
                    {
                        nameDescriptorAccordingToName = days > 1 
                            ? $"{nameDescriptorAccordingToName} and {days} days old"
                            : $"{nameDescriptorAccordingToName} and one day old";
                    }

                    break;
                }
                default:
                    nameDescriptorAccordingToName = DaysOld == 1 
                        ? "One day old"
                        : $"{DaysOld} days";
                    break;
            }

            return nameDescriptorAccordingToName;
        }

        protected virtual void CalculatePrice(float price = 0)
        {
            price = price == 0 ? StartingPrice : price;

            for (var i = 0; i < DaysOld; i++)
            {
                if (IsPriceIncreasing)
                {
                    price = UsePercentageForPricing
                        ? price + price * (PriceChangeValue / 100)
                        : price + PriceChangeValue;
                }
                else
                {
                    price = UsePercentageForPricing
                        ? price - price * (PriceChangeValue / 100 )
                        : price - PriceChangeValue;
                }
            }
            

            Price = MathUtility.RoundToTwoDecimals(price);
        }
    }
}