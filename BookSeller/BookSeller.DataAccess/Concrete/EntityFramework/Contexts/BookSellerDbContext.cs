namespace BookSeller.DataAccess.Concrete.EntityFramework.Contexts
{
    public class BookSellerDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookSellerDbContext()
        {
            
        }

        public BookSellerDbContext(DbContextOptions<BookSellerDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

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
            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new CartLineConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
    }
}
