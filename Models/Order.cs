using Assignment.CustomModelValidator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Order
    {
        [BindNever]
        public int? Id { get; set; }
        [Required(ErrorMessage = "{0} cannot be blank")]
        [DataType(DataType.DateTime, ErrorMessage = "{0} must be a valid DateTime format")]
        [Range(typeof(DateTime), "2000-01-01", "9999-12-31", ErrorMessage = "Date must on or after 2000-01-01.")]
        public DateTime? OrderDate { get; set; }
        [Required(ErrorMessage = "{0} cannot be blank")]
        [OrderInvoiceValidator("Products", ErrorMessage = "{0} doesn't match with the total cost of the specified products in the order.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "{0} must be positive value")]
        public double? InvoicePrice { get; set; }
        [Required(ErrorMessage = "{0} cannot be blank")]
        [MinLength(1)]
        public List<Product>? Products { get; set; }
    }
}
