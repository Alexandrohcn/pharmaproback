namespace PharmaPro.Domain.Entities;

public class Producto
{
    public long Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? PrincipioActivo { get; set; }
    public string? Descripcion { get; set; }
    public long? CategoriaId { get; set; }
    public long? LaboratorioId { get; set; }
    public decimal PrecioCompra { get; set; }
    public decimal PrecioVenta { get; set; }
    public decimal StockMinimo { get; set; }
    public decimal StockMaximo { get; set; }
    public bool RequiereReceta { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
