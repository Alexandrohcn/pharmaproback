using PharmaPro.Application.DTOs;
using PharmaPro.Application.Ports.Inbound;
using PharmaPro.Application.Ports.Outbound;
using PharmaPro.Domain.Entities;

namespace PharmaPro.Application.Services;

public class ProveedorService : IProveedorUseCase
{
    private readonly IProveedorRepository _proveedorRepository;

    public ProveedorService(IProveedorRepository proveedorRepository)
    {
        _proveedorRepository = proveedorRepository;
    }

    public async Task<IEnumerable<ProveedorDto>> ObtenerTodosAsync()
    {
        var proveedores = await _proveedorRepository.GetAllAsync();
        return proveedores.Select(ToDto);
    }

    public async Task<ProveedorDto?> ObtenerPorIdAsync(long id)
    {
        var proveedor = await _proveedorRepository.GetByIdAsync(id);
        return proveedor is null ? null : ToDto(proveedor);
    }

    public async Task<ProveedorDto> CrearAsync(CreateProveedorDto dto)
    {
        var proveedor = new Proveedor
        {
            RazonSocial = dto.RazonSocial,
            Ruc = dto.Ruc,
            Contacto = dto.Contacto,
            Telefono = dto.Telefono,
            Email = dto.Email,
            Direccion = dto.Direccion
        };

        var nuevoProveedor = await _proveedorRepository.AddAsync(proveedor);
        return ToDto(nuevoProveedor);
    }

    public async Task<ProveedorDto?> ActualizarAsync(long id, UpdateProveedorDto dto)
    {
        var proveedor = await _proveedorRepository.GetByIdAsync(id);
        if (proveedor is null) return null;

        proveedor.RazonSocial = dto.RazonSocial;
        proveedor.Ruc = dto.Ruc;
        proveedor.Contacto = dto.Contacto;
        proveedor.Telefono = dto.Telefono;
        proveedor.Email = dto.Email;
        proveedor.Direccion = dto.Direccion;
        proveedor.Estado = dto.Estado;
        proveedor.UpdatedAt = DateTime.UtcNow;

        await _proveedorRepository.UpdateAsync(proveedor);
        return ToDto(proveedor);
    }

    public Task<bool> EliminarAsync(long id)
    {
        return _proveedorRepository.DeleteAsync(id);
    }

    private static ProveedorDto ToDto(Proveedor proveedor)
    {
        return new ProveedorDto(
            proveedor.Id,
            proveedor.RazonSocial,
            proveedor.Ruc,
            proveedor.Contacto,
            proveedor.Telefono,
            proveedor.Email,
            proveedor.Direccion,
            proveedor.Estado
        );
    }
}
