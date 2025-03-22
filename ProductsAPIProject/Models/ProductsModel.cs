using ModelProject.JsonConverter;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductsAPIProject.Models
{
    public class ProductsModel
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(70)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [StringLength(120)]
        public string ProductDescription { get; set; } = string.Empty;

        [Required]
        [JsonConverter(typeof(DecimalConversion))]
        [Range(0.01, double.MaxValue, ErrorMessage = "Prince must be Greater than Zero")]
        public decimal ProductPrice { get; set; }

    }
}
