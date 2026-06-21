using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ClientApi.Extensions.SwaggerConfigurations;

internal class ApiVersionFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Remove o parâmetro api-version da documentação
        var parametersToRemove = operation.Parameters.Where(x => x.Name == "api-version").ToList();

        foreach (var parameter in parametersToRemove)
            operation.Parameters.Remove(parameter);
    }
}
