using Bank.DAL.EF;
using Bank.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bank.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _db;

        protected readonly DbSet<TEntity> _dbSet;
        public GenericRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
            _dbSet = _db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken token)
        {
            return await _dbSet.AsNoTracking().ToListAsync(token);
        }

        public virtual async Task<TEntity> Get(int id, CancellationToken token)
        {
            return await _dbSet.FindAsync(new object[] { id }, token);
        }

        public async Task<TEntity> Create(TEntity tEntity, CancellationToken token)
        {
            await _dbSet.AddAsync(tEntity, token);

            await _db.SaveChangesAsync(token);

            return tEntity;
        }

        public async Task<TEntity> Update(TEntity tEntity, CancellationToken token)
        {

            await _db.SaveChangesAsync(token);

            return tEntity;
        }

        public async Task Delete(int id, CancellationToken token)
        {
            var tEntity = await _dbSet.FindAsync(new object[] {id}, token);

            _dbSet.Remove(tEntity);

            await _db.SaveChangesAsync(token);
        }
    }
}
