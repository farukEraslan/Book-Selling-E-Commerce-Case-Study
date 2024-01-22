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

        public async Task<Result> AddAsync(UserCreateDTO entity)
        {
            var hasUser = await _userManager.FindByEmailAsync(entity.Email);
            if (hasUser != null)
                return new ErrorResult(Messages.UserExist);

            var result = await _userManager.CreateAsync(_mapper.Map<UserEntity>(entity), entity.Password);
            if (result.Succeeded)
                return new SuccessResult(Messages.AddSuccess);
            else
                return new ErrorResult(Messages.AddFail);
        }

        public async Task<Result> UpdateAsync(UserUpdateDTO entity)
        {
            var user = await _userManager.FindByIdAsync(entity.Id);
            if (user == null)
                return new ErrorResult(Messages.UserNotFound);

            var result = await _userManager.UpdateAsync(_mapper.Map(entity, user));
            if (result.Succeeded)
                return new SuccessResult(Messages.UpdateSuccess);
            else
                return new ErrorResult(Messages.UpdateFail);
        }

        public async Task<Result> DeleteAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return new ErrorResult(Messages.UserNotFound);

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return new SuccessResult(Messages.DeleteSuccess);
            else
                return new ErrorResult(Messages.DeleteFail);
        }

        public async Task<DataResult<UserDTO>> GetByIdAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return new ErrorDataResult<UserDTO>(Messages.UserNotFound);

            return new SuccessDataResult<UserDTO>(_mapper.Map<UserDTO>(user), Messages.FoundSuccess);
        }

        public async Task<UserDTO> GetByNameAsync(string userName)
        {
            return _mapper.Map<UserDTO>(await _userManager.FindByNameAsync(userName));
        }

        public DataResult<List<UserDTO>> GetAll(int pageNumber, int pageSize)
        {
            return new SuccessDataResult<List<UserDTO>>(_userManager.Users
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize)
                   .Select(user => _mapper.Map<UserDTO>(user))
                   .ToList(), Messages.ListedSuccess);
        }

        public DataResult<List<UserDTO>> GetAll(Expression<Func<UserEntity, bool>> expression, int pageNumber, int pageSize)
        {
            return new SuccessDataResult<List<UserDTO>>(_userManager.Users.Where(expression)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(user => _mapper.Map<UserDTO>(user))
                .ToList(), Messages.ListedSuccess);
        }

        public async Task<Result> AddToRoleAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
                return new SuccessResult(Messages.AddSuccess);
            else
                return new ErrorResult(Messages.AddFail);
        }
    }
}
