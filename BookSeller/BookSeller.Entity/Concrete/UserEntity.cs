using BookSeller.Core.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace BookSeller.Entity.Concrete
{
    public class UserEntity : IdentityUser<Guid>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
