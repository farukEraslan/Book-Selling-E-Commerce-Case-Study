namespace BookSeller.DataAccess.Abstract
{
    public interface IUserService
    {
        Task<IdentityResult> AddAsync(UserCreateDTO entity);
        Task<IdentityResult> UpdateAsync(UserUpdateDTO entity);
        Task<IdentityResult> DeleteAsync(Guid userId);
        Task<UserDTO> GetByIdAsync(Guid userId);
        Task<UserDTO> GetByNameAsync(string userName);
        List<UserDTO> GetAll(int pageNumber, int pageSize);
        List<UserDTO> GetAll(Expression<Func<UserEntity, bool>> expression, int pageNumber, int pageSize);
        Task<IdentityResult> AddToRoleAsync(Guid userId, string roleName);

    }
}
