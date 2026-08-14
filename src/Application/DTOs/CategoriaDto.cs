namespace PharmaPro.Application.DTOs;

public record CategoriaDto(
    long Id,
    string Nombre,
    string? Descripcion,
    bool Estado
);

public record CreateCategoriaDto(
    string Nombre,
    string? Descripcion
);

public record UpdateCategoriaDto(
    string Nombre,
    string? Descripcion,
    bool Estado
);
