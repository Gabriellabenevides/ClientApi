using Core.Interfaces;
using Core.ViewModel;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.UseCases.GetClient;

public class GetClientUseCase : IRequestHandler<GetClientInput, ClientViewModel>
{
    private readonly IClientRepository _clientRepository;
    private readonly ILogger<GetClientUseCase> _logger;
    private readonly IClientService _clientService;

    public GetClientUseCase(
        IClientRepository clientRepository, 
        ILogger<GetClientUseCase> logger,
        IClientService clientService)
    {
        _clientRepository = clientRepository;
        _logger = logger;
        _clientService = clientService;
    }
    public async Task<ClientViewModel> Handle(GetClientInput request, CancellationToken cancellationToken)
    {
        var client = await _clientService.BuscaClientePorCpf(request.cpf);
        var output = new ClientViewModel(client);
        return output;
    }
}
