namespace BookSeller.Core.ResultSets.Abstract
{
    public interface IDataResult<T> : IResult
    {
        T? Data { get; }
    }
}
