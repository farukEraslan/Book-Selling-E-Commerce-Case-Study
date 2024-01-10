
namespace BookSeller.DataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasData( new RoleEntity {
                Id = Guid.NewGuid(),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }, 
            new RoleEntity {
                Id = Guid.NewGuid(),
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }
    }
}
