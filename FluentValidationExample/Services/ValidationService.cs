using FluentValidation;
using FluentValidationExample.Abstractions;
using FluentValidationExample.Models;
using FluentValidationExample.Validators;

namespace FluentValidationExample.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IDictionary<Type, Type> _validators;
        private readonly IServiceProvider _serviceProvider;

        public ValidationService(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            this._validators = new Dictionary<Type, Type>
            {
                { typeof(CreateRequest), typeof(CreateRequestValidator) },
            };
        }

        private AbstractValidator<T> GetValidator<T>()
        {
            var modelType = typeof(T);
            var hasValidator = this._validators.ContainsKey(modelType);
            if (hasValidator == false)
            {
                throw new Exception("Missing validator");
            }

            var validatorType = this._validators[modelType];
            var validator = _serviceProvider.GetService(validatorType) as AbstractValidator<T>;
            return validator;
        }

        public void EnsureValid<T>(T model)
        {
            var validator = this.GetValidator<T>();
            var result = validator.Validate(model);
            if (result.IsValid == false)
            {
                throw new Exception(result.ToString());
            }
        }
    }
}
