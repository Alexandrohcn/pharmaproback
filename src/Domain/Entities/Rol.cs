using System;
using System.Collections.Generic;

namespace PharmaPro.Domain.Entities;

public partial class Rol
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<UsuarioPerfil> UsuariosPerfiles { get; set; } = new List<UsuarioPerfil>();
}

