namespace BookSeller.DataAccess.Abstract
{
    public interface IUserService
    {
        Task<Result> AddAsync(UserCreateDTO entity);
        Task<Result> UpdateAsync(UserUpdateDTO entity);
        Task<Result> DeleteAsync(Guid userId);
        Task<DataResult<UserDTO>> GetByIdAsync(Guid userId);
        Task<UserDTO> GetByNameAsync(string userName);
        Result GetAll(int pageNumber, int pageSize);
        Result GetAll(Expression<Func<UserEntity, bool>> expression, int pageNumber, int pageSize);
        Task<Result> AddToRoleAsync(Guid userId, string roleName);

    }
}
