using PharmaPro.Application.DTOs;

namespace PharmaPro.Application.Ports.Inbound;

public interface IProveedorUseCase
{
    Task<IEnumerable<ProveedorDto>> ObtenerTodosAsync();
    Task<ProveedorDto?> ObtenerPorIdAsync(long id);
    Task<ProveedorDto> CrearAsync(CreateProveedorDto dto);
    Task<ProveedorDto?> ActualizarAsync(long id, UpdateProveedorDto dto);
    Task<bool> EliminarAsync(long id);
}
