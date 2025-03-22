using System.ComponentModel.DataAnnotations;

namespace ProductsAPIProject.Models
{
    public class PersonModel
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public  string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public  string PersonEmail { get; set; } = string.Empty;

        public  List<ProductsModel> Products { get; set; }
    }

   
}
