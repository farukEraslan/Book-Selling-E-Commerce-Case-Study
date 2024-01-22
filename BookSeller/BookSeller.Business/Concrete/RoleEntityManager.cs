using BookSeller.Entity.DTO.Role;

namespace BookSeller.Business.Concrete
{
    public class RoleEntityManager : IRoleService
    {
        private readonly RoleManager<RoleEntity> _roleManager;
        private readonly IMapper _mapper;

        public RoleEntityManager(RoleManager<RoleEntity> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public Result GetRoles()
        {
            var roles = _mapper.Map<List<RoleDTO>>(_roleManager.Roles);
            return new SuccessDataResult<List<RoleDTO>>(roles, Messages.FoundSuccess);
        }

        public async Task<Result> GetById(Guid roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
            {
                return new ErrorResult(Messages.NotFound);
            }

            return new SuccessDataResult<RoleDTO>(_mapper.Map<RoleDTO>(role), Messages.FoundSuccess);
        }

        public async Task<Result> GetByName(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return new ErrorResult(Messages.NotFound);
            }

            return new SuccessDataResult<RoleDTO>(_mapper.Map<RoleDTO>(role), Messages.FoundSuccess);
        }
    }
}
