

using Microsoft.EntityFrameworkCore;
using _3dmarketplace.src.Interfaces;

namespace _3dmarketplace.src.Repository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly AplicationContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _dbSet.FindAsync(id) ?? throw new KeyNotFoundException($"Entity with id {id} not found.");
            return entity;
        }

        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            Console.WriteLine("Entity created" + entity.ToString());

        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }




    }
}