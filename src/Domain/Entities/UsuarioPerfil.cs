using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class UsuarioPerfil
{
    public Guid Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string? Apellidos { get; set; }

    public string? Telefono { get; set; }

    public string? Documento { get; set; }

    public long? RolId { get; set; }

    public long? SucursalId { get; set; }

    public bool Estado { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AjusteInventario> AjustesInventarios { get; set; } = new List<AjusteInventario>();

    public virtual ICollection<Arqueo> Arqueos { get; set; } = new List<Arqueo>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Rol? Rol { get; set; }

    public virtual Sucursal? Sucursal { get; set; }

    public virtual ICollection<Traslado> Traslados { get; set; } = new List<Traslado>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();

    public virtual ICollection<VentaHistorial> VentaHistorials { get; set; } = new List<VentaHistorial>();
}

