using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class Empleado
{
    public long Id { get; set; }

    public Guid? UsuarioId { get; set; }

    public long? SucursalId { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Documento { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Cargo { get; set; }

    public bool Estado { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Sucursal? Sucursal { get; set; }

    public virtual UsuarioPerfil? Usuario { get; set; }
}

