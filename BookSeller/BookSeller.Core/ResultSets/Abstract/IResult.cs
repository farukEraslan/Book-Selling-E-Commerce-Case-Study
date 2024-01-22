namespace BookSeller.Core.ResultSets.Abstract
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
