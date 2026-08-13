using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class Proveedor
{
    public long Id { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string? Ruc { get; set; }

    public string? Contacto { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public bool Estado { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();
}

