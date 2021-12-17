using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Helpers
{
    /**
     * Attribut vérifiant que la date entrée est comprise dans l'année scolaire en cours
     */
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DateAttribute : ValidationAttribute
    {
        private DateTime _maximum;

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var dateValue = value as DateTime?;
            var memberNames = new List<string> {context.MemberName};

            _maximum = DateTime.UtcNow.Date.Month > 6 ? new DateTime(DateTime.UtcNow.Year + 1, 06, 30) : new DateTime(DateTime.UtcNow.Year, 06, 30);
            
            // Envoie une erreur si la date est plus petite qu'aujourd'hui ou plus grande que le 30 juin de l'année scolaire
            if (dateValue == null) return ValidationResult.Success;
            if (dateValue.Value.Date < DateTime.UtcNow.Date || dateValue.Value.Date > _maximum)
            {
                return new ValidationResult("Date is out of Range", memberNames);
            }

            return ValidationResult.Success;
        }
    }
}