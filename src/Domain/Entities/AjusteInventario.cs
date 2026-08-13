using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class AjusteInventario
{
    public long Id { get; set; }

    public long SucursalId { get; set; }

    public Guid? UsuarioId { get; set; }

    public string Tipo { get; set; } = null!;

    public string? Motivo { get; set; }

    public string? Observacion { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AjusteInventarioDetalle> AjusteInventarioDetalles { get; set; } = new List<AjusteInventarioDetalle>();

    public virtual Sucursal Sucursal { get; set; } = null!;

    public virtual UsuarioPerfil? Usuario { get; set; }
}


