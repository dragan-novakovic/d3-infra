using _3dmarketplace.src.Interfaces;
using _3dmarketplace.src.Models.Category;

namespace _3dmarketplace.src.Services
{
    public class CategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<Category> Create(Category category)
        {
            return await _categoryRepository.Create(category);
        }

        public async Task Update(Category category)
        {
            await _categoryRepository.Update(category);
        }

        public async Task Delete(int id)
        {
            await _categoryRepository.Delete(id);
        }
    }
}