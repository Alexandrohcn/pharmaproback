using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class Arqueo
{
    public long Id { get; set; }

    public long CajaId { get; set; }

    public Guid? UsuarioId { get; set; }

    public DateTime FechaApertura { get; set; }

    public DateTime? FechaCierre { get; set; }

    public decimal MontoInicial { get; set; }

    public decimal MontoEsperado { get; set; }

    public decimal MontoReal { get; set; }

    public decimal Diferencia { get; set; }

    public string Estado { get; set; } = null!;

    public string? Observaciones { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<ArqueoDetalle> ArqueoDetalles { get; set; } = new List<ArqueoDetalle>();

    public virtual Caja Caja { get; set; } = null!;

    public virtual UsuarioPerfil? Usuario { get; set; }
}

