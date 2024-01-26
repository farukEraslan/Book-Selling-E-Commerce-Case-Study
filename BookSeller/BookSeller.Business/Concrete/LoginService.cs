namespace BookSeller.Business.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IConfiguration _configuration;

        public LoginService(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<DataResult<Token>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
            if (!result.Succeeded)
            {
                return new ErrorDataResult<Token>(Messages.ListedFail);
            }

            //var token = TokenHandler.CreateToken(_configuration);

            return new SuccessDataResult<Token>(Messages.ListedSuccess);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
