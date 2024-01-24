namespace BookSeller.WebUI.HttpHelpers.Abstract
{
    public interface IHttpMethods
    {
        Task<T> HttpGetAll<T>();
    }
}
