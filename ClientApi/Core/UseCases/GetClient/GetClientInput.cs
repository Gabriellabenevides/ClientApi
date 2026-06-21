using Core.Domain;
using Core.ViewModel;
using MediatR;

namespace Core.UseCases.GetClient;

public record class GetClientInput(string cpf) : IRequest<ClientViewModel>
{
}
