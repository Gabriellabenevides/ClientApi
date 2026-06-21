using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Infra.IoC;
using ClientApi.Extensions.SwaggerConfigurations;
using Core.UseCases.AddClient;
using Core.IoC;

namespace ClientApi;
public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuração de serviços
        builder.Services
            .AddSwaggerConfig(builder.Configuration)
            .AddControllers();

        builder.Services.AddRepository(builder.Configuration);
        builder.Services.AddService(builder.Configuration);


        var connectionString = builder.Configuration.GetConnectionString("ClientAPIConnection");

        builder.Services.AddDbContext<MySqlContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddClientUseCase).Assembly));

        builder.Services.AddSwaggerConfig(builder.Configuration).AddControllers();

        var app = builder.Build();

        app.UsePathBase("/Client-API");

        app.UseRouting();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "ClientAPI V1");
            options.RoutePrefix = string.Empty; // Define a URL base para acessar o Swagger
        });

        app.MapControllers();
        await app.RunAsync();
    }
}