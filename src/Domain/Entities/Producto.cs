using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class Producto
{
    public long Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? PrincipioActivo { get; set; }

    public string? Descripcion { get; set; }

    public long? CategoriaId { get; set; }

    public long? LaboratorioId { get; set; }

    public long? FormaFarmaceuticaId { get; set; }

    public long? PresentacionId { get; set; }

    public decimal PrecioCompra { get; set; }

    public decimal PrecioVenta { get; set; }

    public decimal StockMinimo { get; set; }

    public decimal StockMaximo { get; set; }

    public bool RequiereReceta { get; set; }

    public bool Estado { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AjusteInventarioDetalle> AjusteInventarioDetalles { get; set; } = new List<AjusteInventarioDetalle>();

    public virtual Categoria? Categoria { get; set; }

    public virtual ICollection<CompraDetalle> CompraDetalles { get; set; } = new List<CompraDetalle>();

    public virtual FormaFarmaceutica? FormaFarmaceutica { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual Laboratorio? Laboratorio { get; set; }

    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();

    public virtual Presentacion? Presentacion { get; set; }

    public virtual ICollection<TrasladoDetalle> TrasladoDetalles { get; set; } = new List<TrasladoDetalle>();

    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
}


