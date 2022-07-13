namespace Bank.BLL.Interfaces
{
    public interface IGenericService<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAll(CancellationToken token);
        Task<TModel> Get(int id, CancellationToken token);
        Task<TModel> Create(TModel item, CancellationToken token);
        Task<TModel> Update(TModel item, CancellationToken token);
        Task Delete(int id, CancellationToken token);
    }
}
