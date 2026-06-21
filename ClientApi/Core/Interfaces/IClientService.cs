using Core.Domain;

namespace Core.Interfaces;

public interface IClientService
{
    Task<Client> BuscaClientePorCpf(string Cpf);
    void ValidaCpf(string cpf);
    void ValidaIdade(int idade);
}
