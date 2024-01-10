namespace BookSeller.DataAccess.Concrete.EntityFramework.Contexts
{
    public class BookSellerDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = ISTN36002\\SQLEXPRESS; Database = BookSeller; uid = sa; pwd = 123; Trusted_Connection = True; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
