using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class Cliente
{
    public long Id { get; set; }

    public string? TipoDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public string Nombres { get; set; } = null!;

    public string? Apellidos { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public bool Estado { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
