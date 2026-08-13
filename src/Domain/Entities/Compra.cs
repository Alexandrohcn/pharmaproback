using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class Compra
{
    public long Id { get; set; }

    public long ProveedorId { get; set; }

    public long SucursalId { get; set; }

    public Guid? UsuarioId { get; set; }

    public string? TipoComprobante { get; set; }

    public string? Serie { get; set; }

    public string? Numero { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Impuesto { get; set; }

    public decimal Descuento { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<CompraDetalle> CompraDetalles { get; set; } = new List<CompraDetalle>();

    public virtual Proveedor Proveedor { get; set; } = null!;

    public virtual Sucursal Sucursal { get; set; } = null!;

    public virtual UsuarioPerfil? Usuario { get; set; }
}

