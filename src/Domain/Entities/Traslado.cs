using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class Traslado
{
    public long Id { get; set; }

    public long SucursalOrigenId { get; set; }

    public long SucursalDestinoId { get; set; }

    public Guid? UsuarioId { get; set; }

    public string Estado { get; set; } = null!;

    public string? Observacion { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Sucursal SucursalDestino { get; set; } = null!;

    public virtual Sucursal SucursalOrigen { get; set; } = null!;

    public virtual ICollection<TrasladoDetalle> TrasladoDetalles { get; set; } = new List<TrasladoDetalle>();

    public virtual UsuarioPerfil? Usuario { get; set; }
}

