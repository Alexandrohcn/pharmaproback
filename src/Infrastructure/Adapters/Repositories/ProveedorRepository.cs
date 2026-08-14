using Microsoft.EntityFrameworkCore;
using PharmaPro.Application.Ports.Outbound;
using PharmaPro.Domain.Entities;
using PharmaPro.Infrastructure.Persistence;

namespace PharmaPro.Infrastructure.Adapters.Repositories;

public class ProveedorRepository : IProveedorRepository
{
    private readonly PharmaDbContext _context;

    public ProveedorRepository(PharmaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Proveedores.AsNoTracking().OrderBy(proveedor => proveedor.RazonSocial).ToListAsync();
    }

    public async Task<Proveedor?> GetByIdAsync(long id)
    {
        return await _context.Proveedores.FindAsync(id);
    }

    public async Task<Proveedor> AddAsync(Proveedor proveedor)
    {
        _context.Proveedores.Add(proveedor);
        await _context.SaveChangesAsync();
        return proveedor;
    }

    public async Task<bool> UpdateAsync(Proveedor proveedor)
    {
        _context.Proveedores.Update(proveedor);
        var rows = await _context.SaveChangesAsync();
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var proveedor = await _context.Proveedores.FindAsync(id);
        if (proveedor is null) return false;

        _context.Proveedores.Remove(proveedor);
        var rows = await _context.SaveChangesAsync();
        return rows > 0;
    }
}
