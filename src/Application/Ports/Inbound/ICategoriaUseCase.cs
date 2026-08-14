using PharmaPro.Application.DTOs;

namespace PharmaPro.Application.Ports.Inbound;

public interface ICategoriaUseCase
{
    Task<IEnumerable<CategoriaDto>> ObtenerTodosAsync();
    Task<CategoriaDto?> ObtenerPorIdAsync(long id);
    Task<CategoriaDto> CrearAsync(CreateCategoriaDto dto);
    Task<CategoriaDto?> ActualizarAsync(long id, UpdateCategoriaDto dto);
    Task<bool> EliminarAsync(long id);
}
