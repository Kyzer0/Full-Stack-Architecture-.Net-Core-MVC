using System.ComponentModel.DataAnnotations;

namespace ProductsAPIProject.Models
{
    public class PersonWithProductsDto
    {
        public PersonModel Person { get; set; }
        public List<ProductsModel> Products { get; set; } = new();
    }
}
