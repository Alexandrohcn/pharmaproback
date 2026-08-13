using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class Inventario
{
    public long Id { get; set; }

    public long ProductoId { get; set; }

    public long? LoteId { get; set; }

    public long SucursalId { get; set; }

    public decimal Stock { get; set; }

    public decimal StockReservado { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Lote? Lote { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Sucursal Sucursal { get; set; } = null!;
}

