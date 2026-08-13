namespace PharmaPro.Domain.Entities;

public class Categoria
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Laboratorio
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class FormaFarmaceutica
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Presentacion
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Rol
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Permiso
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string? Modulo { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Sucursal
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Proveedor
{
    public long Id { get; set; }
    public string RazonSocial { get; set; } = string.Empty;
    public string? Ruc { get; set; }
    public string? Contacto { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Direccion { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Cliente
{
    public long Id { get; set; }
    public string? TipoDocumento { get; set; }
    public string? NumeroDocumento { get; set; }
    public string Nombres { get; set; } = string.Empty;
    public string? Apellidos { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Direccion { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Lote
{
    public long Id { get; set; }
    public long? ProductoId { get; set; }
    public long? ProveedorId { get; set; }
    public string NumeroLote { get; set; } = string.Empty;
    public DateOnly? FechaFabricacion { get; set; }
    public DateOnly? FechaVencimiento { get; set; }
    public decimal Cantidad { get; set; }
    public decimal CostoUnitario { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Inventario
{
    public long Id { get; set; }
    public long ProductoId { get; set; }
    public long? LoteId { get; set; }
    public long SucursalId { get; set; }
    public decimal Stock { get; set; }
    public decimal StockReservado { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class UsuarioPerfil
{
    public Guid Id { get; set; }
    public string Nombres { get; set; } = string.Empty;
    public string? Apellidos { get; set; }
    public string? Telefono { get; set; }
    public string? Documento { get; set; }
    public long? RolId { get; set; }
    public long? SucursalId { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Empleado
{
    public long Id { get; set; }
    public Guid? UsuarioId { get; set; }
    public long? SucursalId { get; set; }
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string? Documento { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public string? Cargo { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Caja
{
    public long Id { get; set; }
    public long SucursalId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Numero { get; set; }
    public decimal MontoInicial { get; set; }
    public bool Estado { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Arqueo
{
    public long Id { get; set; }
    public long CajaId { get; set; }
    public Guid? UsuarioId { get; set; }
    public DateTime FechaApertura { get; set; } = DateTime.UtcNow;
    public DateTime? FechaCierre { get; set; }
    public decimal MontoInicial { get; set; }
    public decimal MontoEsperado { get; set; }
    public decimal MontoReal { get; set; }
    public decimal Diferencia { get; set; }
    public string Estado { get; set; } = "abierto";
    public string? Observaciones { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class ArqueoDetalle
{
    public long Id { get; set; }
    public long ArqueoId { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal Cantidad { get; set; }
    public decimal Monto { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Compra
{
    public long Id { get; set; }
    public long ProveedorId { get; set; }
    public long SucursalId { get; set; }
    public Guid? UsuarioId { get; set; }
    public string? TipoComprobante { get; set; }
    public string? Serie { get; set; }
    public string? Numero { get; set; }
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public decimal Subtotal { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Descuento { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; } = "registrada";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class CompraDetalle
{
    public long Id { get; set; }
    public long CompraId { get; set; }
    public long ProductoId { get; set; }
    public long? LoteId { get; set; }
    public decimal Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Descuento { get; set; }
    public decimal Subtotal { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Venta
{
    public long Id { get; set; }
    public long? ClienteId { get; set; }
    public Guid? UsuarioId { get; set; }
    public long SucursalId { get; set; }
    public long? CajaId { get; set; }
    public string? TipoComprobante { get; set; }
    public string? Serie { get; set; }
    public string? Numero { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal Subtotal { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Descuento { get; set; }
    public decimal Total { get; set; }
    public string? MetodoPago { get; set; }
    public decimal MontoPagado { get; set; }
    public decimal Vuelto { get; set; }
    public string Estado { get; set; } = "completada";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class VentaDetalle
{
    public long Id { get; set; }
    public long VentaId { get; set; }
    public long ProductoId { get; set; }
    public long? LoteId { get; set; }
    public decimal Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Descuento { get; set; }
    public decimal Subtotal { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class VentaHistorial
{
    public long Id { get; set; }
    public long VentaId { get; set; }
    public Guid? UsuarioId { get; set; }
    public string Accion { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string? EstadoAnterior { get; set; }
    public string? EstadoNuevo { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class AjusteInventario
{
    public long Id { get; set; }
    public long SucursalId { get; set; }
    public Guid? UsuarioId { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string? Motivo { get; set; }
    public string? Observacion { get; set; }
    public string Estado { get; set; } = "pendiente";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class AjusteInventarioDetalle
{
    public long Id { get; set; }
    public long AjusteId { get; set; }
    public long ProductoId { get; set; }
    public long? LoteId { get; set; }
    public decimal CantidadAnterior { get; set; }
    public decimal CantidadNueva { get; set; }
    public decimal Diferencia { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class Traslado
{
    public long Id { get; set; }
    public long SucursalOrigenId { get; set; }
    public long SucursalDestinoId { get; set; }
    public Guid? UsuarioId { get; set; }
    public string Estado { get; set; } = "pendiente";
    public string? Observacion { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class TrasladoDetalle
{
    public long Id { get; set; }
    public long TrasladoId { get; set; }
    public long ProductoId { get; set; }
    public long? LoteId { get; set; }
    public decimal Cantidad { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
