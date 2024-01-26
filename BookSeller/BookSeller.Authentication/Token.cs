namespace BookSeller.Authentication
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
