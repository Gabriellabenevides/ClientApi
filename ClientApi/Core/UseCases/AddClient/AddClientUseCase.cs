using Core.Domain;
using Core.Interfaces;
using Core.Services;
using Core.ViewModel;
using MediatR;

namespace Core.UseCases.AddClient;

public class AddClientUseCase : IRequestHandler<AddClientInput, ClientViewModel>
{
    private readonly IClientRepository _clientRepository;
    private readonly IClientService _clientService;
    public AddClientUseCase(IClientRepository clientRepository, IClientService clientService)
    {
        _clientRepository = clientRepository;
        _clientService = clientService;
    }

    public async Task<ClientViewModel> Handle(AddClientInput request, CancellationToken cancellationToken)
    {
        _clientService.ValidaCpf(request.Client.Cpf);
        _clientService.ValidaIdade(request.Client.Age);
        var client = new Client(request.Client.Name, request.Client.Email, request.Client.Age, request.Client.Cpf, request.Client.PhoneNumber);
        await _clientRepository.AddAsync(client);

        var output = new ClientViewModel(client);
        return output;

    }
}
