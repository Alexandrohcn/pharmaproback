using Microsoft.EntityFrameworkCore;
using PharmaPro.Application.Ports.Outbound;
using PharmaPro.Domain.Entities;
using PharmaPro.Infrastructure.Persistence;

namespace PharmaPro.Infrastructure.Adapters.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly PharmaDbContext _context;

    public CategoriaRepository(PharmaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        return await _context.Categorias.AsNoTracking().OrderBy(categoria => categoria.Nombre).ToListAsync();
    }

    public async Task<Categoria?> GetByIdAsync(long id)
    {
        return await _context.Categorias.FindAsync(id);
    }

    public async Task<Categoria> AddAsync(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<bool> UpdateAsync(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        var rows = await _context.SaveChangesAsync();
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria is null) return false;

        _context.Categorias.Remove(categoria);
        var rows = await _context.SaveChangesAsync();
        return rows > 0;
    }
}
