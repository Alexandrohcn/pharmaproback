using PharmaPro.Application.Ports.Outbound;
using PharmaPro.Domain.Entities;

namespace PharmaPro.Infrastructure.Adapters.Repositories;

public class ProductoRepository : IProductoRepository
{
    // Simulación en memoria o adaptador Supabase
    private static readonly List<Producto> _productos = new();
    private static long _nextId = 1;

    public Task<IEnumerable<Producto>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Producto>>(_productos);
    }

    public Task<Producto?> GetByIdAsync(long id)
    {
        var prod = _productos.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(prod);
    }

    public Task<Producto> AddAsync(Producto producto)
    {
        producto.Id = _nextId++;
        _productos.Add(producto);
        return Task.FromResult(producto);
    }

    public Task<bool> UpdateAsync(Producto producto)
    {
        var index = _productos.FindIndex(p => p.Id == producto.Id);
        if (index == -1) return Task.FromResult(false);
        _productos[index] = producto;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(long id)
    {
        var count = _productos.RemoveAll(p => p.Id == id);
        return Task.FromResult(count > 0);
    }
}
