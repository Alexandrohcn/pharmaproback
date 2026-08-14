namespace PharmaPro.Application.DTOs;

public record ProveedorDto(
    long Id,
    string RazonSocial,
    string? Ruc,
    string? Contacto,
    string? Telefono,
    string? Email,
    string? Direccion,
    bool Estado
);

public record CreateProveedorDto(
    string RazonSocial,
    string? Ruc,
    string? Contacto,
    string? Telefono,
    string? Email,
    string? Direccion
);

public record UpdateProveedorDto(
    string RazonSocial,
    string? Ruc,
    string? Contacto,
    string? Telefono,
    string? Email,
    string? Direccion,
    bool Estado
);
