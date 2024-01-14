namespace BookSeller.DataAccess.Concrete.EntityFramework
{
    public class UserEntityManager : IUserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;

        public UserEntityManager(UserManager<UserEntity> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> AddAsync(UserCreateDTO entity)
        {
            var result = await _userManager.CreateAsync(_mapper.Map<UserEntity>(entity), entity.Password);
            return result;
        }

        public async Task<IdentityResult> UpdateAsync(UserUpdateDTO entity)
        {
            var user = await _userManager.FindByIdAsync(entity.Id);
            var result = await _userManager.UpdateAsync(_mapper.Map(entity, user));
            return result;
        }

        public async Task<IdentityResult> DeleteAsync(Guid userId)
        {
            var result = await _userManager.DeleteAsync(await _userManager.FindByIdAsync(userId.ToString()));
            return result;
        }

        public async Task<UserDTO> GetByIdAsync(Guid userId)
        {
            return _mapper.Map<UserDTO>(await _userManager.FindByIdAsync(userId.ToString()));
        }

        public List<UserDTO> GetAll(int pageNumber, int pageSize)
        {
            return _userManager.Users
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize)
                   .Select(user => _mapper.Map<UserDTO>(user))
                   .ToList();
        }

        public List<UserDTO> GetAll(Expression<Func<UserEntity, bool>> expression, int pageNumber, int pageSize)
        {
            return _userManager.Users.Where(expression)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(user => _mapper.Map<UserDTO>(user))
                .ToList();
        }

        public async Task<IdentityResult> AddToRoleAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result;
        }
    }
}
