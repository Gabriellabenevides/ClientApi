using Core.Domain;
using Core.ViewModel;
using MediatR;

namespace Core.UseCases.AddClient;

public record class AddClientInput(Client Client) : IRequest<ClientViewModel>
{
}
