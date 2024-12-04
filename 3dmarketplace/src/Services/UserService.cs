using _3dmarketplace.src.Interfaces;
using _3dmarketplace.src.Models;

namespace _3dmarketplace.src.Services
{
    public class UserService
    {
        private readonly IGenericRepository<UserMetadata> _userRepository;

        public UserService(IGenericRepository<UserMetadata> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserMetadata>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<UserMetadata> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<UserMetadata> Create(UserMetadata category)
        {
            return await _userRepository.Create(category);
        }

        public async Task Update(UserMetadata category)
        {
            await _userRepository.Update(category);
        }

        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }
    }
}