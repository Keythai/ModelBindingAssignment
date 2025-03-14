using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Product
    {
        [Required(ErrorMessage = "{0} cannot be blank")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} cannot be negative value")]
        public int? ProductCode { get; set; }
        [Required(ErrorMessage = "{0} cannot be blank")]
        [Range(0.0, double.MaxValue, ErrorMessage = "{0} cannot be negative value")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "{0} cannot be blank")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} cannot be negative value")]
        public int? Quantity { get; set; }
    }
}
