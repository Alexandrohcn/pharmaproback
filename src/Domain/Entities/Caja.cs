using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class Caja
{
    public long Id { get; set; }

    public long SucursalId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Numero { get; set; }

    public decimal MontoInicial { get; set; }

    public bool Estado { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Arqueo> Arqueos { get; set; } = new List<Arqueo>();

    public virtual Sucursal Sucursal { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}

