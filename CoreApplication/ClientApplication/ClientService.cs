using CoreBussiness.BussinessEntity.Clients;
using CoreBussiness.IUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.ClientApplication;

public class ClientService:IClientService
{
    private DbSet<Client> _clients;
    public ClientService(IUnitOfWork work)
    {
        _clients = work.Set<Client>();
    }

    public async Task AddClientAsync(Client client) => await _clients.AddAsync(client);

    public async Task<Client?> GetClientAsync(int id) =>
        await _clients.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
}