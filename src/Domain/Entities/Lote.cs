using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class Lote
{
    public long Id { get; set; }

    public long ProductoId { get; set; }

    public long? ProveedorId { get; set; }

    public string NumeroLote { get; set; } = null!;

    public DateOnly? FechaFabricacion { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public decimal Cantidad { get; set; }

    public decimal CostoUnitario { get; set; }

    public bool Estado { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AjusteInventarioDetalle> AjusteInventarioDetalles { get; set; } = new List<AjusteInventarioDetalle>();

    public virtual ICollection<CompraDetalle> CompraDetalles { get; set; } = new List<CompraDetalle>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual Producto Producto { get; set; } = null!;

    public virtual Proveedor? Proveedor { get; set; }

    public virtual ICollection<TrasladoDetalle> TrasladoDetalles { get; set; } = new List<TrasladoDetalle>();

    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
}


