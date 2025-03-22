using ProductsAPIProject.Interface;
using ProductsAPIProject.Models;
using ProductsAPIProject.Helpers.BussineLogic;
namespace ProductsAPIProject.BussinessLogic
{
    public class ProductsLogic : IProductsInterface<ProductsModel>
    {
        private readonly List<ProductsModel> _productsModel = new();
        public void AddProducts(ProductsModel product)
        {
            BussinessLogicValidation.CheckNullObjects(product);
            var maxID = _productsModel.Any() ? _productsModel.Max(x => x.ProductId) : 0;
            product.ProductId = maxID + 1;
            _productsModel.Add(product);

        }
        public List<ProductsModel> GetAllProducts() => _productsModel;

        public ProductsModel GetProductById(int id)
        {
            BussinessLogicValidation.CheckID(id);
            var product = _productsModel.FirstOrDefault(x => x.ProductId == id);

            BussinessLogicValidation.CheckNullObjects(product);

            return product;
        }

        public void UpdaterProduct(int id, ProductsModel product)
        {
            BussinessLogicValidation.CheckID(id);
            var productUpdate = _productsModel.FirstOrDefault(x => x.ProductId == id);
            BussinessLogicValidation.CheckNullObjects(productUpdate);

            //checking
            productUpdate.ProductName = product.ProductName;
            productUpdate.ProductDescription = product.ProductDescription;
            productUpdate.ProductPrice = product.ProductPrice;

        }

        public void DeletableProduct(int id)
        {
            BussinessLogicValidation.CheckID(id);
            var product = _productsModel.FirstOrDefault(x => x.ProductId == id);
            BussinessLogicValidation.CheckNullObjects(product);

            _productsModel.Remove(product);
        }

    }
}
