using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class FormaFarmaceutica
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}

