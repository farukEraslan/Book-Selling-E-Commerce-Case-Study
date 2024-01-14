namespace BookSeller.Entity.Validators.FluentValidator
{
    public class UserCreateDTOValidator : AbstractValidator<UserCreateDTO>
    {
        public UserCreateDTOValidator()
        {
            RuleFor(user => user.FirstName).MinimumLength(2).NotNull().NotEmpty().WithMessage("Geçerli bir isim giriniz.");
            RuleFor(user => user.LastName).MinimumLength(2).NotNull().NotEmpty().WithMessage("Geçerli bir soyisim giriniz.");
            RuleFor(user => user.BirthDate).NotNull().NotEmpty().WithMessage("Geçerli bir tarih giriniz.");
            RuleFor(user => user.Email).EmailAddress().NotNull().NotEmpty().WithMessage("Geçerli bir mail adresi giriniz.");
            RuleFor(user => user.Password).Must(PasswordCheck).NotNull().NotEmpty().WithMessage("Geçerli bir parola giriniz.");
            RuleFor(user => user.PhoneNumber).Must(PhoneNumberCheck).NotNull().NotEmpty().WithMessage("Geçerli bir telefon numarası giriniz.");
        }

        private bool PasswordCheck(string password)
        {
            string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-=_+";
            return password.All(password => validCharacters.Contains(password));
        }

        private bool PhoneNumberCheck(string phoneNumber)
        {
            string validCharacters = "0123456789";
            return phoneNumber.All(phoneNumber => validCharacters.Contains(phoneNumber));
            //return Regex.IsMatch(phoneNumber, @"^[1-9]\d{9}$");
        }
    }
}
