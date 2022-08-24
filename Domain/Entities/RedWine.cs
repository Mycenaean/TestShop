namespace Domain.Entities
{
    public class RedWine : Wine
    {
        private const float _startingPrice = 5;
        private static string _name = "Red Wine";
        
        public RedWine(int days) : base(_name, _startingPrice, days)
        {
        }
    }
}