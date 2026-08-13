using Microsoft.Extensions.DependencyInjection;
using PharmaPro.Application.Ports.Inbound;
using PharmaPro.Application.Ports.Outbound;
using PharmaPro.Application.Services;
using PharmaPro.Infrastructure.Adapters.Repositories;

namespace PharmaPro.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Outbound Adapters (Repositories)
        services.AddSingleton<IProductoRepository, ProductoRepository>();

        // Inbound Services (Use Cases)
        services.AddScoped<IProductoUseCase, ProductoService>();

        return services;
    }
}
