namespace BookSeller.WebAPI.Controllers.User
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDTO userCreateDTO)
        {
            var result = await _userService.AddAsync(userCreateDTO);

            if (result.Succeeded) 
                return Ok();
            else 
                return BadRequest(result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDTO userUpdateDTO)
        {
            var result = await _userService.UpdateAsync(userUpdateDTO);

            if (result.Succeeded)
                return Ok();
            else
                return BadRequest(result.Errors);
        }

        [HttpDelete]
        [Authorize("Admin")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var result = await _userService.DeleteAsync(userId);

            if (result.Succeeded)
                return Ok();
            else
                return BadRequest(result.Errors);
        }

        [HttpGet]
        [Authorize("Admin")]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            var users = _userService.GetAll(pageNumber, pageSize);

            if (users is not null)
                return Ok(users);
            else
                return BadRequest();
        }

        [HttpGet]
        [Authorize("Admin")]
        public async Task<IActionResult> GetById(Guid userId)
        {
            var user = await _userService.GetByIdAsync(userId);

            if (user is not null)
                return Ok(user);
            else
                return BadRequest();
        }

        [HttpPost]
        //[Authorize("Admin")]
        public async Task<IActionResult> AddToRoleAsync(Guid userId, string roleName)
        {
            var result = await _userService.AddToRoleAsync(userId, roleName);

            if (result.Succeeded)
                return Ok();
            else
                return BadRequest(result.Errors);
        }
    }
}
