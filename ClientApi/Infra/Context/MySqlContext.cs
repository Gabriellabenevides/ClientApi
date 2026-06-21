using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context;

public class MySqlContext : DbContext
{
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
    {
    }
    public DbSet<Client> Clients { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
