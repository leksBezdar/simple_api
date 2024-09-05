using TestAPI.models;

namespace TestAPI.services
{
    public class ProductService : IProductService
    {
        private readonly List<ProductModel> _products = [];
        public void Add(ProductModel product)
        {
            _products.Add(product);
        }

        public void Delete(int id)
        {
            var product = GetOne(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return _products;
        }

        public ProductModel? GetOne(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Update(int id, ProductModel product)
        {
            var existingProduct = GetOne(id);
            if (existingProduct != null)
            {
                existingProduct.Title = product.Title;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Currency = product.Currency;
            }
        }
    }
}
