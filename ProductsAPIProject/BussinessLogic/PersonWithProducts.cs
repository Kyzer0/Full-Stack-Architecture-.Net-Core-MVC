using ProductsAPIProject.Helpers.BussineLogic;
using ProductsAPIProject.Interface;
using ProductsAPIProject.Models;

namespace ProductsAPIProject.BussinessLogic
{
    public class PersonWithProducts : IPersonDto<PersonWithProductsDto, PersonModel>
    {
        private readonly List<PersonWithProductsDto> _personDto = new();

        public void AddPerson(PersonWithProductsDto person)
        {
            BussinessLogicValidation.CheckNullObjects(person.Person);
            BussinessLogicValidation.CheckNullObjects(person.Products);

            person.Person.PersonId = _personDto.Any() ? _personDto.Max(x => x.Person.PersonId) + 1 : 1;
            _personDto.Add(person);
        }

        public List<PersonWithProductsDto> GetAllPerson() => _personDto;

        public PersonWithProductsDto GetPersonById(int personId)
        {
            var checkId = _personDto.FirstOrDefault(p => p.Person.PersonId == personId);
            BussinessLogicValidation.CheckNullObjects(checkId);
            return checkId;
        }

        public void UpdatePerson(int id, PersonWithProductsDto productsModel)
        {
            BussinessLogicValidation.CheckID(id);
            var person = _personDto.FirstOrDefault(x => x.Person.PersonId == id);
            BussinessLogicValidation.CheckNullObjects(person);

            person.Person.FirstName = productsModel.Person.FirstName;
            person.Person.LastName = productsModel.Person.LastName;
            person.Person.PersonEmail = productsModel.Person.PersonEmail;
            person.Products = productsModel.Products;

        }
        public void DeletePerson(int id)
        {
            BussinessLogicValidation.CheckID(id);
            var person = _personDto.FirstOrDefault(x => x.Person.PersonId == id);
            BussinessLogicValidation.CheckNullObjects(person);
            _personDto.Remove(person);
        }
    }
}
