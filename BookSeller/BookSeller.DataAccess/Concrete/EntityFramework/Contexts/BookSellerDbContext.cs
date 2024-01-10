using BookSeller.DataAccess.Configurations;

namespace BookSeller.DataAccess.Concrete.EntityFramework.Contexts
{
    public class BookSellerDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = ISTN36002\\SQLEXPRESS; Database = BookSeller; uid = sa; pwd = 123; Trusted_Connection = True; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
