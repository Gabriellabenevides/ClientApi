using Core.Domain;

namespace Core.ViewModel;

public class ClientViewModel
{
    public Client Client { get; set; }
    public ClientViewModel(Client client) 
    {
        this.Client = client;
    }
}
