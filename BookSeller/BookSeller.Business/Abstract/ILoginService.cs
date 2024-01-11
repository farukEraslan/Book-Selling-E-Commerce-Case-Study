namespace BookSeller.Business.Abstract
{
    public interface ILoginService
    {
        Task<SignInResult> Login(LoginDTO loginDTO);
        Task Logout();
    }
}
