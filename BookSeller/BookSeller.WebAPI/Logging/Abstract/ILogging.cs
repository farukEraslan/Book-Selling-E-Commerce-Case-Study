namespace BookSeller.WebAPI.Logging.Abstract
{
    public interface ILogging
    {
        public void Log(string message, string type);
    }
}
