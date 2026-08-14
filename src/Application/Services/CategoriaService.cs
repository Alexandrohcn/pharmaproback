using PharmaPro.Application.DTOs;
using PharmaPro.Application.Ports.Inbound;
using PharmaPro.Application.Ports.Outbound;
using PharmaPro.Domain.Entities;

namespace PharmaPro.Application.Services;

public class CategoriaService : ICategoriaUseCase
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<IEnumerable<CategoriaDto>> ObtenerTodosAsync()
    {
        var categorias = await _categoriaRepository.GetAllAsync();
        return categorias.Select(ToDto);
    }

    public async Task<CategoriaDto?> ObtenerPorIdAsync(long id)
    {
        var categoria = await _categoriaRepository.GetByIdAsync(id);
        return categoria is null ? null : ToDto(categoria);
    }

    public async Task<CategoriaDto> CrearAsync(CreateCategoriaDto dto)
    {
        var categoria = new Categoria
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion
        };

        var nuevaCategoria = await _categoriaRepository.AddAsync(categoria);
        return ToDto(nuevaCategoria);
    }

    public async Task<CategoriaDto?> ActualizarAsync(long id, UpdateCategoriaDto dto)
    {
        var categoria = await _categoriaRepository.GetByIdAsync(id);
        if (categoria is null) return null;

        categoria.Nombre = dto.Nombre;
        categoria.Descripcion = dto.Descripcion;
        categoria.Estado = dto.Estado;
        categoria.UpdatedAt = DateTime.UtcNow;

        await _categoriaRepository.UpdateAsync(categoria);
        return ToDto(categoria);
    }

    public Task<bool> EliminarAsync(long id)
    {
        return _categoriaRepository.DeleteAsync(id);
    }

    private static CategoriaDto ToDto(Categoria categoria)
    {
        return new CategoriaDto(
            categoria.Id,
            categoria.Nombre,
            categoria.Descripcion,
            categoria.Estado
        );
    }
}
