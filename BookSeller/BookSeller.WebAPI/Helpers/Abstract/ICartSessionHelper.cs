namespace BookSeller.WebAPI.Helpers.Abstract
{
    public interface ICartSessionHelper
    {
        CartDTO GetCart(string key);
        void SetCart(string key, CartDTO cart);
        void Clear();
    }
}
