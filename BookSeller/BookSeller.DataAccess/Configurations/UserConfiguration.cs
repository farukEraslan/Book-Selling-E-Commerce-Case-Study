
namespace BookSeller.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(75);
            builder.Property(x => x.BirthDate);

            builder.HasData( new UserEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "Faruk",
                LastName = "Eraslan",
                BirthDate = new DateTime(1997, 06, 07, 07, 00, 00),
                UserName = "faruk.eraslan",
                NormalizedUserName = "FARUK.ERASLAN",
                Email = "frk.eraslan@hotmail.com",
                NormalizedEmail = "FRK.ERASLAN@HOTMAIL.COM",
                PhoneNumber = "5063347409"
            });
        }
    }
}
