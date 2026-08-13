using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class Venta
{
    public long Id { get; set; }

    public long? ClienteId { get; set; }

    public Guid? UsuarioId { get; set; }

    public long SucursalId { get; set; }

    public long? CajaId { get; set; }

    public string? TipoComprobante { get; set; }

    public string? Serie { get; set; }

    public string? Numero { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Impuesto { get; set; }

    public decimal Descuento { get; set; }

    public decimal Total { get; set; }

    public string? MetodoPago { get; set; }

    public decimal MontoPagado { get; set; }

    public decimal Vuelto { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Caja? Caja { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Sucursal Sucursal { get; set; } = null!;

    public virtual UsuarioPerfil? Usuario { get; set; }

    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();

    public virtual ICollection<VentaHistorial> VentaHistorials { get; set; } = new List<VentaHistorial>();
}

