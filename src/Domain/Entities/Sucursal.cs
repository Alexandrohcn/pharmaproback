using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class Sucursal
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public bool Estado { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AjusteInventario> AjustesInventarios { get; set; } = new List<AjusteInventario>();

    public virtual ICollection<Caja> Cajas { get; set; } = new List<Caja>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Traslado> TrasladoSucursalDestinos { get; set; } = new List<Traslado>();

    public virtual ICollection<Traslado> TrasladoSucursalOrigens { get; set; } = new List<Traslado>();

    public virtual ICollection<UsuarioPerfil> UsuariosPerfiles { get; set; } = new List<UsuarioPerfil>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}

