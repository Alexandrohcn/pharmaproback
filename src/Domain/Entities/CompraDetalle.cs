using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class CompraDetalle
{
    public long Id { get; set; }

    public long CompraId { get; set; }

    public long ProductoId { get; set; }

    public long? LoteId { get; set; }

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Descuento { get; set; }

    public decimal Subtotal { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Compra Compra { get; set; } = null!;

    public virtual Lote? Lote { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
