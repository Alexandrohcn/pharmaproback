using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class AjusteInventarioDetalle
{
    public long Id { get; set; }

    public long AjusteId { get; set; }

    public long ProductoId { get; set; }

    public long? LoteId { get; set; }

    public decimal CantidadAnterior { get; set; }

    public decimal CantidadNueva { get; set; }

    public decimal Diferencia { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual AjusteInventario Ajuste { get; set; } = null!;

    public virtual Lote? Lote { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}


