using Core.Domain;
using Core.Interfaces;
using Core.ViewModel;
using MediatR;

namespace Core.UseCases.UpdateClient;

public class UpdateClientUseCase : IRequestHandler<UpdateClientInput, ClientViewModel>
{
    private readonly IClientRepository _clientRepository;
    private readonly IClientService _clientService;
    public UpdateClientUseCase(IClientRepository clientRepository, IClientService clientService)
    {
        _clientRepository = clientRepository;
        _clientService = clientService;
    }

    public async Task<ClientViewModel> Handle(UpdateClientInput request, CancellationToken cancellationToken)
    {
        _clientService.ValidaCpf(request.client.Cpf);
        _clientService.ValidaIdade(request.client.Age);

        var existingClient = await _clientService.BuscaClientePorCpf(request.client.Cpf);

        existingClient.Name = request.client.Name;
        existingClient.Email = request.client.Email;
        existingClient.Age = request.client.Age;
        existingClient.PhoneNumber = request.client.PhoneNumber; 

        await _clientRepository.UpdateAsync(existingClient);

        var output = new ClientViewModel(existingClient);
        return output;
    }
}
