namespace BookSeller.Business.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;

        public LoginService(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<SignInResult> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
