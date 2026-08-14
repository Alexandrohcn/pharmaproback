using PharmaPro.Application.DTOs;
using PharmaPro.Application.Ports.Inbound;
using PharmaPro.Application.Ports.Outbound;
using PharmaPro.Domain.Entities;

namespace PharmaPro.Application.Services;

public class ProductoService : IProductoUseCase
{
    private readonly IProductoRepository _productoRepository;

    public ProductoService(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public async Task<IEnumerable<ProductoDto>> ObtenerTodosAsync()
    {
        var productos = await _productoRepository.GetAllAsync();
        return productos.Select(p => new ProductoDto(
            p.Id, p.Codigo, p.Nombre, p.PrincipioActivo, p.PrecioVenta, p.RequiereReceta, p.Estado
        ));
    }

    public async Task<ProductoDto?> ObtenerPorIdAsync(long id)
    {
        var producto = await _productoRepository.GetByIdAsync(id);
        if (producto == null) return null;

        return new ProductoDto(
            producto.Id, producto.Codigo, producto.Nombre, producto.PrincipioActivo, producto.PrecioVenta, producto.RequiereReceta, producto.Estado
        );
    }

    public async Task<ProductoDto> CrearProductoAsync(CreateProductoDto dto)
    {
        var producto = new Producto
        {
            Codigo = dto.Codigo,
            Nombre = dto.Nombre,
            PrincipioActivo = dto.PrincipioActivo,
            Descripcion = dto.Descripcion,
            CategoriaId = dto.CategoriaId,
            LaboratorioId = dto.LaboratorioId,
            PrecioCompra = dto.PrecioCompra,
            PrecioVenta = dto.PrecioVenta,
            StockMinimo = dto.StockMinimo,
            StockMaximo = dto.StockMaximo,
            RequiereReceta = dto.RequiereReceta
        };

        var nuevoProducto = await _productoRepository.AddAsync(producto);

        return new ProductoDto(
            nuevoProducto.Id, nuevoProducto.Codigo, nuevoProducto.Nombre, nuevoProducto.PrincipioActivo, nuevoProducto.PrecioVenta, nuevoProducto.RequiereReceta, nuevoProducto.Estado
        );
    }

    public async Task<ProductoDto?> ActualizarAsync(long id, UpdateProductoDto dto)
    {
        var producto = await _productoRepository.GetByIdAsync(id);
        if (producto == null) return null;

        producto.Codigo = dto.Codigo;
        producto.Nombre = dto.Nombre;
        producto.PrincipioActivo = dto.PrincipioActivo;
        producto.Descripcion = dto.Descripcion;
        producto.CategoriaId = dto.CategoriaId;
        producto.LaboratorioId = dto.LaboratorioId;
        producto.PrecioCompra = dto.PrecioCompra;
        producto.PrecioVenta = dto.PrecioVenta;
        producto.StockMinimo = dto.StockMinimo;
        producto.StockMaximo = dto.StockMaximo;
        producto.RequiereReceta = dto.RequiereReceta;
        producto.Estado = dto.Estado;
        producto.UpdatedAt = DateTime.UtcNow;

        await _productoRepository.UpdateAsync(producto);

        return new ProductoDto(
            producto.Id, producto.Codigo, producto.Nombre, producto.PrincipioActivo, producto.PrecioVenta, producto.RequiereReceta, producto.Estado
        );
    }

    public Task<bool> EliminarAsync(long id)
    {
        return _productoRepository.DeleteAsync(id);
    }
}
