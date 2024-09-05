using TestAPI.models;

namespace TestAPI.services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAll();
        ProductModel? GetOne(int id);
        void Add(ProductModel product);
        void Update(int id, ProductModel product);
        void Delete(int id);
    }
}
