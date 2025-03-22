using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPIProject.Interface;
using ProductsAPIProject.Models;

namespace ProductsAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonDto<PersonWithProductsDto, PersonModel> _person;
        public PersonController(IPersonDto<PersonWithProductsDto, PersonModel> person)
        {
            _person = person;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerson()
        {
            var person = await Task.Run(() => _person.GetAllPerson());
            return Ok(person);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdByPerson(int id)
        {
            var getId = await Task.Run(() => _person.GetPersonById(id));
            return Ok(getId);
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(PersonWithProductsDto person)
        {
            await Task.Run(() => _person.AddPerson(person));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonDetails(int id, [FromBody] PersonWithProductsDto request)
        {
            await Task.Run(() => _person.UpdatePerson(id,request));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await Task.Run(() => _person.DeletePerson(id));
            return Ok();
        }
    }
}
