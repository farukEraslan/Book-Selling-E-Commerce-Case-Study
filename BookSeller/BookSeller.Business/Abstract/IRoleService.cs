namespace BookSeller.Business.Abstract
{
    public interface IRoleService
    {
        Result GetRoles();
        Task<Result> GetById(Guid roleId);
        Task<Result> GetByName(string roleName);
    }
}
