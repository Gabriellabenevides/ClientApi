using Core.Domain;
using Core.ViewModel;
using MediatR;

namespace Core.UseCases.UpdateClient;

public record class UpdateClientInput(Client client) : IRequest<ClientViewModel>
{
}
