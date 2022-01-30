using FluentValidationExample.Models;

namespace FluentValidationExample.Abstractions
{
    public interface IService
    {
        Task<Response> CreateAsync(CreateRequest request);
    }
}
