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
        var connectionString = configuration.GetConnectionString("SupabaseConnection") 
                               ?? "Host=db.fkaerrcwxkrjthazgpza.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=YOUR_POSTGRES_PASSWORD";

        services.AddDbContext<PharmaDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Outbound Adapters (Repositories)
        services.AddScoped<IProductoRepository, ProductoRepository>();

        // Inbound Services (Use Cases)
        services.AddScoped<IProductoUseCase, ProductoService>();

        return services;
    }
}
