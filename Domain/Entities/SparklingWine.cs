namespace Domain.Entities
{
    public class SparklingWine : Wine
    {
        private const float _startingPrice = 7;
        private static string _name = "Sparkling Wine";
        public SparklingWine(int daysOld) : base(_name, _startingPrice, daysOld)
        {
        }
    }
}