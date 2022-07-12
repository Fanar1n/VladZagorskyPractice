namespace Bank.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll(CancellationToken token);
        Task<TEntity> Get(int id, CancellationToken token);
        Task<TEntity> Create(TEntity item, CancellationToken token);
        Task<TEntity> Update(TEntity item, CancellationToken token);
        Task Delete(int id, CancellationToken token);
    }
}
