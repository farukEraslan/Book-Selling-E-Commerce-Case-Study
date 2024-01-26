namespace BookSeller.Business.Abstract
{
    public interface ILoginService
    {
        Task<DataResult<Token>> Login(LoginDTO loginDTO);
        Task Logout();
    }
}
