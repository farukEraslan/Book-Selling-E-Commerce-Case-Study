namespace BookSeller.DataAccess.Configurations
{
    public class CartLineConfiguration : IEntityTypeConfiguration<CartLine>
    {
        public void Configure(EntityTypeBuilder<CartLine> builder)
        {
            builder.HasKey(x => x.CartLineId);
            builder.Property(x => x.Quantity).HasMaxLength(10);
            builder.Property(x => x.CartLinePrice);

            builder.HasOne(x=>x.Product).WithMany(x=>x.Cartlines).HasForeignKey(x=>x.ProductId);
            builder.HasOne(x=>x.Cart).WithMany(x=>x.CartLines).HasForeignKey(x=>x.CartId);
        }
    }
}
