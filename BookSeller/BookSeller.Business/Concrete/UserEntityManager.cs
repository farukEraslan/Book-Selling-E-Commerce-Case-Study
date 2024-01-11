using Microsoft.AspNetCore.Http;

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
            var result = await _userManager.CreateAsync(_mapper.Map<UserEntity>(entity));
            return result;
        }

        public async Task<IdentityResult> UpdateAsync(UserUpdateDTO entity)
        {
            var result = await _userManager.UpdateAsync(_mapper.Map<UserEntity>(entity));
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

        public List<UserDTO> GetAll()
        {
            return _mapper.Map<List<UserDTO>>(_userManager.Users.ToList());
        }

        public List<UserDTO> GetAll(Expression<Func<UserEntity, bool>> expression)
        {
            return _mapper.Map<List<UserDTO>>(_userManager.Users.Where(expression).ToList());
        }
    }
}
