﻿namespace BeeSoft.Web.Infrastructure.ValidationAttributes.Apiaries
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
                var apiaryExists = service.IsApiaryExistsAsync((int)value).GetAwaiter().GetResult();
                if (!apiaryExists)
                {
                    return new ValidationResult(string.Empty);
                }

                return ValidationResult.Success!;
            }

            return new ValidationResult("Service not resolved or value for validation is null.");
        }
    }
}
