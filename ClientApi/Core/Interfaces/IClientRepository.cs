using Core.Domain;

namespace Core.Interfaces
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<Client> GetByCpfAsync(string cpf);
        Task<Client> AtualizarClientePorCpf(string cpf, Client client);
    }
}
