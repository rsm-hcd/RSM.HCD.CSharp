namespace AndcultureCode.CSharp.Core.Interfaces.Conductors
{
    public interface ICloneableConductor<T>
    {
        IResult<T> Clone(T source);
        IResult<T> Clone(long id);
    }
}
