namespace ProductsAPIProject.Interface
{
    public interface IProductsInterface<T> where T : class
    {
        void AddProducts(T product);
        List<T> GetAllProducts();
        T GetProductById(int id);
        void UpdaterProduct(int id,T product);
        void DeletableProduct(int id);

    }
}
