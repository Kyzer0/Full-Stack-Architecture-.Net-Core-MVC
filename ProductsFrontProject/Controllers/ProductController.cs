using Microsoft.AspNetCore.Mvc;
using ProductsAPIProject.Models;

namespace ProductsFrontProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7299/");
        }
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _httpClient.GetFromJsonAsync<List<ProductsModel>>("api/Products") ?? new List<ProductsModel>();
            return View(products);
        }
        public async Task<IActionResult> GetProductId(int id)
        {
            var productId = await _httpClient.GetFromJsonAsync<ProductsModel>($"api/Products/{id}");
            if (productId == null) return NotFound();

            return View(productId);
        }
        public async Task<IActionResult> AddProducts(ProductsModel products)
        {
            if (!ModelState.IsValid) return View(products);

            var response = await _httpClient.PostAsJsonAsync("api/Products", products);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("GetAllProducts");
            return View(products);
        }

        public async Task<IActionResult> UpdateProducts(int id, ProductsModel products)
        {
            if (id <= 0) return NotFound();
            if (!ModelState.IsValid) return View(products);

            var response = await _httpClient.PutAsJsonAsync($"api/Products/{id}", products);

            if (!response.IsSuccessStatusCode) return BadRequest("Error updating product.");

            return RedirectToAction("GetAllProducts");
        }

        public async Task<IActionResult> DeleteProducts(int id)
        {
            if (id <= 0) return NotFound();
            var response = await _httpClient.DeleteAsync($"api/Products/{id}");
            return RedirectToAction("GetAllProducts");
        }
    }
}
