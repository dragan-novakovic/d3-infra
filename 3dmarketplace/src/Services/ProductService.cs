using _3dmarketplace.src.Interfaces;
using _3dmarketplace.src.Models;

namespace _3dmarketplace.src.Services
{
    public class ProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<Product> Create(Product product)
        {
            return await _productRepository.Create(product);
        }

        public async Task Update(Product product)
        {
            await _productRepository.Update(product);
        }

        public async Task Delete(int id)
        {
            await _productRepository.Delete(id);
        }
    }
}