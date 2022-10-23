namespace CoreBussiness.BussinessEntity.Clients;

public interface IClientService
{
   Task AddClientAsync(Client client);
   Task<Client?> GetClientAsync(int id);
}