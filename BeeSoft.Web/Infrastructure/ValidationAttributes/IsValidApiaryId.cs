namespace ConcreteProducts.Web.Infrastructure.ValidationAttributes
{
    using System.ComponentModel.DataAnnotations;

    using BeeSoft.Services.Apiaries;

    public class IsValidApiaryId : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return new ValidationResult("Value for validation is null.");
            }

            var service = validationContext.GetService(typeof(IApiariesService)) as IApiariesService;
            if (service is not null)
            {
                var apiaryExist = service.IsApiaryExistAsync((int)value).GetAwaiter().GetResult();
                if (!apiaryExist)
                {
                    return new ValidationResult("Apiary does not exist.");
                }

                return ValidationResult.Success!;
            }

            return new ValidationResult("Service not resolved or value for validation is null.");
        }
    }
}
