using BookSeller.Business.Concrete;

namespace BookSeller.DataAccess.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.CartId);
            builder.Property(x => x.Address);
            builder.Property(x => x.CartTotalPrice);

            builder.HasOne(x=>x.User).WithMany(x=>x.Carts).HasForeignKey(x=>x.UserId);
        }
    }
}
