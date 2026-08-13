using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class VentaHistorial
{
    public long Id { get; set; }

    public long VentaId { get; set; }

    public Guid? UsuarioId { get; set; }

    public string Accion { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? EstadoAnterior { get; set; }

    public string? EstadoNuevo { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual UsuarioPerfil? Usuario { get; set; }

    public virtual Venta Venta { get; set; } = null!;
}

