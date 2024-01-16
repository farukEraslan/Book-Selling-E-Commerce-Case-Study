namespace BookSeller.WebAPI.Helpers.Abstract
{
    public interface ICartSessionHelper
    {
        Task<CartDomainModel> GetCart(string key);
        void SetCart(string key, CartDomainModel cart);
        void Clear();
    }
}
