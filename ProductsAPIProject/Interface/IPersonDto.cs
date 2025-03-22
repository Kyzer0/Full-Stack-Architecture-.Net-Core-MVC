namespace ProductsAPIProject.Interface
{
    public interface IPersonDto<T,R>
    {
        void AddPerson(T person);
        List<T> GetAllPerson();
        T GetPersonById(int personId);
        void UpdatePerson(int id, T productsModel);
        void DeletePerson(int id);
    }
}
