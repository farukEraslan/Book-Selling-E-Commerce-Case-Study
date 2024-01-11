namespace BookSeller.Entity.DTO.User
{
    public class UserUpdateDTO : IDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserName
        {
            get
            {
                return FirstName.ToLower() + "." + LastName.ToLower();
            }
        }
        public string Email { get; set; }
        public string NormalizedEmail
        {
            get
            {
                return Email.ToUpper();
            }
        }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
