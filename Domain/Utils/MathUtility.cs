using System;

namespace Domain.Utils
{
    public static class MathUtility
    {
        public static float RoundToTwoDecimals(float number)
        {
            return (float)Math.Round(number * 100f) / 100f;
        }
    }
}