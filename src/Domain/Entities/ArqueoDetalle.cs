using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class ArqueoDetalle
{
    public long Id { get; set; }

    public long ArqueoId { get; set; }

    public string Tipo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Cantidad { get; set; }

    public decimal Monto { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Arqueo Arqueo { get; set; } = null!;
}
