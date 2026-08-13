using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class TrasladoDetalle
{
    public long Id { get; set; }

    public long TrasladoId { get; set; }

    public long ProductoId { get; set; }

    public long? LoteId { get; set; }

    public decimal Cantidad { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Lote? Lote { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Traslado Traslado { get; set; } = null!;
}
