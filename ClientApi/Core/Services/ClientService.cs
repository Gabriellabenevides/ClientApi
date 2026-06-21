using Core.Domain;
using Core.Interfaces;
using Core.Shared;
using Core.UseCases.GetClient;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly ILogger<GetClientUseCase> _logger;

    public ClientService(
        IClientRepository clientRepository,
        ILogger<GetClientUseCase> logger)
    {
        _clientRepository = clientRepository;
        _logger = logger;
    }

    public async Task<Client> BuscaClientePorCpf(string cpf)
    {
        var client = await _clientRepository.GetByCpfAsync(cpf);

        if (client == null)
        {
            _logger.LogWarning("Cliente não encontrado para o CPF {Cpf}", cpf);

            throw new NotFoundException($"Cliente não encontrado para o CPF {cpf}");
        }
        return client;
    }
    public void ValidaCpf(string cpf)
    {
        if(cpf.Length != 11)
        {
            _logger.LogWarning("CPF inválido {Cpf}", cpf);
            throw new BadRequestException($"CPF inválido {cpf}");
        }
    } 
    public void ValidaIdade(int idade)
    {
        if (idade < 0 || idade > 120)
        {
            _logger.LogWarning("Idade inválida {Idade}", idade);
            throw new BadRequestException($"Idade inválida {idade}");
        }
    }
}
