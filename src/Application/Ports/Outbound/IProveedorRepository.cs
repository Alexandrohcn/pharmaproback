using PharmaPro.Domain.Entities;

namespace PharmaPro.Application.Ports.Outbound;

public interface IProveedorRepository
{
    Task<IEnumerable<Proveedor>> GetAllAsync();
    Task<Proveedor?> GetByIdAsync(long id);
    Task<Proveedor> AddAsync(Proveedor proveedor);
    Task<bool> UpdateAsync(Proveedor proveedor);
    Task<bool> DeleteAsync(long id);
}
