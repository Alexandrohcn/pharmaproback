using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PharmaPro.Application.Ports.Inbound;
using PharmaPro.Application.Ports.Outbound;
using PharmaPro.Application.Services;
using PharmaPro.Infrastructure.Adapters.Repositories;
using PharmaPro.Infrastructure.Persistence;

namespace PharmaPro.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SupabaseConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "ConnectionStrings:SupabaseConnection no está configurada. " +
                "Opciones para configurarla:\n" +
                "  1. LOCAL: Copia .env.example como .env y define ConnectionStrings__SupabaseConnection.\n" +
                "  2. USER SECRETS: dotnet user-secrets set \"ConnectionStrings:SupabaseConnection\" \"tu-cadena\".\n" +
                "  3. VPS/PRODUCCION: Define la variable de entorno ConnectionStrings__SupabaseConnection en el servidor.");
        }

        services.AddDbContext<PharmaDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Outbound Adapters (Repositories)
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IProductoRepository, ProductoRepository>();
        services.AddScoped<IProveedorRepository, ProveedorRepository>();

        // Inbound Services (Use Cases)
        services.AddScoped<ICategoriaUseCase, CategoriaService>();
        services.AddScoped<IProductoUseCase, ProductoService>();
        services.AddScoped<IProveedorUseCase, ProveedorService>();

        return services;
    }
}
