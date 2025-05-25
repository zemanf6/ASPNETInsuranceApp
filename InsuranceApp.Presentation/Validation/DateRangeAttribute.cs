using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.Presentation.Validation
{
    public class DateRangeAttribute : ValidationAttribute
    {
        private readonly string _startDatePropertyName;

        public DateRangeAttribute(string startDatePropertyName)
        {
            _startDatePropertyName = startDatePropertyName;
            ErrorMessage = "Datum ukončení musí být větší nebo rovno datu začátku.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var endDate = value as DateTime?;
            var property = validationContext.ObjectType.GetProperty(_startDatePropertyName);

            if (property == null)
                return new ValidationResult($"Neznámá vlastnost: {_startDatePropertyName}");

            var startDate = property.GetValue(validationContext.ObjectInstance) as DateTime?;

            if (startDate.HasValue && endDate.HasValue && endDate.Value < startDate.Value)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
