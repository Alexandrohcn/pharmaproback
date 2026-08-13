using PharmaPro.Application.DTOs;

namespace PharmaPro.Application.Ports.Inbound;

public interface IProductoUseCase
{
    Task<IEnumerable<ProductoDto>> ObtenerTodosAsync();
    Task<ProductoDto?> ObtenerPorIdAsync(long id);
    Task<ProductoDto> CrearProductoAsync(CreateProductoDto dto);
}
