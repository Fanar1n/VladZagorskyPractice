using AutoMapper;
using Bank.BLL.Interfaces;
using Bank.DAL.Interfaces;

namespace Bank.BLL.Services
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel> where TModel : class where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> _genericRepository;
        protected readonly IMapper _mapper;

        public GenericService(
            IGenericRepository<TEntity> genericRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<TModel>> GetAll(CancellationToken token)
        {
            var result = await _genericRepository.GetAll(token);

            return _mapper.Map<IEnumerable<TModel>>(result);
        }

        public async Task<TModel> Get(int id, CancellationToken token)
        {
            var result = await _genericRepository.Get(id, token);

            return _mapper.Map<TModel>(result);
        }

        public virtual async Task<TModel> Create(TModel item, CancellationToken token)
        {
            var tEntity = _mapper.Map<TEntity>(item);
            var result = await _genericRepository.Create(tEntity, token);

            return _mapper.Map<TModel>(result);
        }

        public virtual async Task<TModel> Update(TModel item, CancellationToken token)
        {
            var tEntity = _mapper.Map<TEntity>(item);
            var result = await _genericRepository.Update(tEntity, token);

            return _mapper.Map<TModel>(result);
        }

        public async Task Delete(int id, CancellationToken token)
        {
            var tModel = await _genericRepository.Get(id, token);

            if (tModel == null)
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            await _genericRepository.Delete(id, token);
        }
    }
}