using Microsoft.EntityFrameworkCore;
using PharmaPro.Application.Ports.Outbound;
using PharmaPro.Domain.Entities;
using PharmaPro.Infrastructure.Persistence;

namespace PharmaPro.Infrastructure.Adapters.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly PharmaDbContext _context;

    public ProductoRepository(PharmaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos.AsNoTracking().ToListAsync();
    }

    public async Task<Producto?> GetByIdAsync(long id)
    {
        return await _context.Productos.FindAsync(id);
    }

    public async Task<Producto> AddAsync(Producto producto)
    {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task<bool> UpdateAsync(Producto producto)
    {
        _context.Productos.Update(producto);
        var rows = await _context.SaveChangesAsync();
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return false;

        _context.Productos.Remove(producto);
        var rows = await _context.SaveChangesAsync();
        return rows > 0;
    }
}
