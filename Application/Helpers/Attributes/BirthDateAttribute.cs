using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Helpers.Attributes
{
    /**
     * Attribut vérifiant que la date entrée est comprise entre 1900-01-01 et aujourd'hui
     */
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class BirthDateAttribute : ValidationAttribute
    {
        private const string MINIMUM = "1900-01-01";
        
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var dateValue = value as DateTime?;
            var memberNames = new List<string> {context.MemberName};

            if (dateValue == null) return ValidationResult.Success;
            if (dateValue.Value.Date > DateTime.UtcNow.Date || dateValue.Value.Date < DateTime.Parse(MINIMUM))
            {
                return new ValidationResult("Date is out of Range", memberNames);
            }

            return ValidationResult.Success;
        }

    }
}