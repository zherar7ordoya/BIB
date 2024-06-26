namespace Recommendations
{
    /// <summary>
    /// Defines a standard service for recommending a purchasable
    /// item to a customer.
    /// </summary>
    public interface IAdvisor 
    {
        Firework Recommend(Customer c);
    }
}
