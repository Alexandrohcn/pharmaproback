using PharmaPro.Domain.Entities;

namespace PharmaPro.Application.Ports.Outbound;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> GetAllAsync();
    Task<Categoria?> GetByIdAsync(long id);
    Task<Categoria> AddAsync(Categoria categoria);
    Task<bool> UpdateAsync(Categoria categoria);
    Task<bool> DeleteAsync(long id);
}
