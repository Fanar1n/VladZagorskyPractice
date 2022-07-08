using Bank.DAL.EF;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bank.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationContext _db;

        public ClientRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ClientEntity>> GetAll(CancellationToken token)
        {
            return await _db.Client.AsNoTracking().ToListAsync(token);
        }

        public async Task<ClientEntity> Get(int id, CancellationToken token)
        {
            return await _db.Client.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, token);
        }

        public async Task<ClientEntity> Create(ClientEntity client, CancellationToken token)
        {
            _db.Client.AddAsync(client, token);

            _db.SaveChangesAsync(token);

            return client;
        }
        
        public async Task<ClientEntity> Update(ClientEntity client, CancellationToken token)
        {
            _db.Client.Update(client);

            _db.SaveChangesAsync(token);

            return client;
        }

        public async Task Delete(int id, CancellationToken token)
        {
            var client = _db.Client.Find(id);

            _db.Client.Remove(client);

            await _db.SaveChangesAsync(token);
        }
    }
}
