using ProjectAPI.Interfaces;
using ProjectAPI.Models;

namespace ProjectAPI.Services;

class ProductService(IRepository<Product> productRepository)
{
    private readonly IRepository<Product> _productRepository = productRepository;

    public void AddProduct(Product product)
    {
        _productRepository.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        _productRepository.Update(product);
    }

    public void DeleteProduct(Product product)
    {
        _productRepository.Delete(product);
    }

    public Product GetProductById(int id)
    {
        return _productRepository.GetById(id);
    }

    
}