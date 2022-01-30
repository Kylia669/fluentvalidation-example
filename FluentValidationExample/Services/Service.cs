using FluentValidationExample.Abstractions;
using FluentValidationExample.Models;

namespace FluentValidationExample.Services
{
    public class Service : IService
    {
        private readonly IValidationService _validationService;

        public Service(IValidationService validationService)
        {
            _validationService = validationService;
        }

        public async Task<Response> CreateAsync(CreateRequest request)
        {
            this._validationService.EnsureValid(request);
            // Implementation
            return new Response();
        }

    }
}
