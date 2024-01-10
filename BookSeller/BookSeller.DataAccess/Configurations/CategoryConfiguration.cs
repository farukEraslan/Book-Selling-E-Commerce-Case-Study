namespace BookSeller.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryName).HasMaxLength(128);

            builder.HasData(new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "Roman",
            },
            new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "Kişisel Gelişim",
            },
            new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "Çocuk ve Gençlik",
            },
            new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "Tarih",
            },
            new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "Çizgi Roman",
            });
        }
    }
}
