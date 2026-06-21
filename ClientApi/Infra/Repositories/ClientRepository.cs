using Core.Domain;
using Core.Interfaces;
using Infra.Context;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    private readonly Context.MySqlContext _context;
    public ClientRepository(MySqlContext context) : base(context)
    {
        _context = context;
    }
    public async Task<Client> AtualizarClientePorCpf(string cpf, Client clientAtualizado)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(c => c.Cpf == cpf);

        _context.Entry(client!).CurrentValues.SetValues(clientAtualizado);

        await _context.SaveChangesAsync();

        return client!;
    }

    public async Task<Client> GetByCpfAsync(string cpf)
    {
        return await _context.Clients.FirstOrDefaultAsync(c => c.Cpf == cpf);
    }
}
