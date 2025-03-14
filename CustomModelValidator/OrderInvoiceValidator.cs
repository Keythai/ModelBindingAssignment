using Assignment.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Assignment.CustomModelValidator
{
    public class OrderInvoiceValidator : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }
        public OrderInvoiceValidator(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                PropertyInfo? propertyInfo = validationContext.ObjectType.GetProperty(OtherPropertyName);
                if (propertyInfo != null)
                {
                    List<Product>? products = propertyInfo.GetValue(validationContext.ObjectInstance) as List<Product>;
                    if (products != null)
                    {
                        double invoicePrice = 0;
                        foreach (Product product in products)
                        {
                            var validationResult = new List<ValidationResult>();
                            Validator.TryValidateObject(product, new ValidationContext(product), validationResult, true);
                            if (validationResult != null)
                                return new ValidationResult(string.Join("\n", validationResult));
                            invoicePrice += (double)(product.Price * product.Quantity);
                        }
                        if (invoicePrice == Convert.ToDouble(value))
                        {
                            return ValidationResult.Success;
                        }
                        return new ValidationResult(string.Format(ErrorMessage ?? "Invalid invoice price", validationContext.DisplayName));
                    }
                }
                return null;
            }
            return null;
        }
    }
}
