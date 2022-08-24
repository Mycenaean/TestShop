namespace Domain.Services
{
    public interface ICheckout
    {
        float TotalPrice { get; }
        void CreateReceipt(ICart cart);
    }
}