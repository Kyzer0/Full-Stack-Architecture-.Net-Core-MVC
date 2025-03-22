using Microsoft.AspNetCore.Mvc;
using ProductsAPIProject.Models;

namespace ProductsFrontProject.Controllers
{
    public class PersonFrontController : Controller
    {
        private readonly HttpClient _httpClient;

        public PersonFrontController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7299/");
        }
        
        public async Task<IActionResult> GetAllPerson()
        {
            var getAllPerson = await _httpClient.GetFromJsonAsync<List<PersonModel>>("api/Person") ?? new List<PersonModel>();
            return View(getAllPerson);
        }
        public async Task<IActionResult> GetPersonId(int id)
        {
            var getId = await _httpClient.GetFromJsonAsync <PersonModel> ($"api/Person/{id}");
            return View(getId);
        }
    }
}
