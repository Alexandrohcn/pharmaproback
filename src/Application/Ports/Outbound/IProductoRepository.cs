using PharmaPro.Domain.Entities;

namespace PharmaPro.Application.Ports.Outbound;

public interface IProductoRepository
{
    Task<IEnumerable<Producto>> GetAllAsync();
    Task<Producto?> GetByIdAsync(long id);
    Task<Producto> AddAsync(Producto producto);
    Task<bool> UpdateAsync(Producto producto);
    Task<bool> DeleteAsync(long id);
}
