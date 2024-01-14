namespace BookSeller.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.BookName).HasMaxLength(256);
            builder.Property(x => x.UnitPrice);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Author).HasMaxLength(128);
            builder.Property(x => x.Publisher).HasMaxLength(128);
            builder.Property(x => x.ISBN).HasMaxLength(128);

            // Category Navigation
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
