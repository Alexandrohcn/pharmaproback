namespace PharmaPro.Application.DTOs;

public record ProductoDto(
    long Id,
    string Codigo,
    string Nombre,
    string? PrincipioActivo,
    decimal PrecioVenta,
    bool RequiereReceta,
    bool Estado
);

public record CreateProductoDto(
    string Codigo,
    string Nombre,
    string? PrincipioActivo,
    string? Descripcion,
    long? CategoriaId,
    long? LaboratorioId,
    decimal PrecioCompra,
    decimal PrecioVenta,
    decimal StockMinimo,
    decimal StockMaximo,
    bool RequiereReceta
);
