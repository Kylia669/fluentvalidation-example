namespace FluentValidationExample.Abstractions
{
    public interface IValidationService
    {
        void EnsureValid<T>(T model);
    }
}
