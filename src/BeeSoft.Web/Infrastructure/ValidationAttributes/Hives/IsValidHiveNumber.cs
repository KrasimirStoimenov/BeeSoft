namespace BeeSoft.Web.Infrastructure.ValidationAttributes.Hives
{
    using System.ComponentModel.DataAnnotations;

    using BeeSoft.Services.Hives;

    public class IsValidHiveNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return new ValidationResult("Value for validation is null.");
            }

            var service = validationContext.GetService(typeof(IHivesService)) as IHivesService;
            if (service is not null)
            {
                var hiveNumberExists = service.IsHiveWithNumberAlreadyExists((int)value).GetAwaiter().GetResult();
                if (hiveNumberExists)
                {
                    return new ValidationResult(string.Empty);
                }

                return ValidationResult.Success!;
            }

            return new ValidationResult("Service not resolved or value for validation is null.");
        }
    }
}
