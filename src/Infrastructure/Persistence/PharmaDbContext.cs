using Microsoft.EntityFrameworkCore;
using PharmaPro.Domain.Entities;

namespace PharmaPro.Infrastructure.Persistence;

public class PharmaDbContext : DbContext
{
    public PharmaDbContext(DbContextOptions<PharmaDbContext> options) : base(options) { }

    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Laboratorio> Laboratorios => Set<Laboratorio>();
    public DbSet<FormaFarmaceutica> FormasFarmaceuticas => Set<FormaFarmaceutica>();
    public DbSet<Presentacion> Presentaciones => Set<Presentacion>();
    public DbSet<Rol> Roles => Set<Rol>();
    public DbSet<Permiso> Permisos => Set<Permiso>();
    public DbSet<Sucursal> Sucursales => Set<Sucursal>();
    public DbSet<Proveedor> Proveedores => Set<Proveedor>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Lote> Lotes => Set<Lote>();
    public DbSet<Inventario> Inventarios => Set<Inventario>();
    public DbSet<UsuarioPerfil> UsuariosPerfiles => Set<UsuarioPerfil>();
    public DbSet<Empleado> Empleados => Set<Empleado>();
    public DbSet<Caja> Cajas => Set<Caja>();
    public DbSet<Arqueo> Arqueos => Set<Arqueo>();
    public DbSet<ArqueoDetalle> ArqueoDetalles => Set<ArqueoDetalle>();
    public DbSet<Compra> Compras => Set<Compra>();
    public DbSet<CompraDetalle> CompraDetalles => Set<CompraDetalle>();
    public DbSet<Venta> Ventas => Set<Venta>();
    public DbSet<VentaDetalle> VentaDetalles => Set<VentaDetalle>();
    public DbSet<VentaHistorial> VentaHistoriales => Set<VentaHistorial>();
    public DbSet<AjusteInventario> AjustesInventario => Set<AjusteInventario>();
    public DbSet<AjusteInventarioDetalle> AjustesInventarioDetalles => Set<AjusteInventarioDetalle>();
    public DbSet<Traslado> Traslados => Set<Traslado>();
    public DbSet<TrasladoDetalle> TrasladoDetalles => Set<TrasladoDetalle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("public");

        // Map tables to Supabase Postgres names
        modelBuilder.Entity<Producto>().ToTable("productos");
        modelBuilder.Entity<Categoria>().ToTable("categorias");
        modelBuilder.Entity<Laboratorio>().ToTable("laboratorios");
        modelBuilder.Entity<FormaFarmaceutica>().ToTable("formas_farmaceuticas");
        modelBuilder.Entity<Presentacion>().ToTable("presentaciones");
        modelBuilder.Entity<Rol>().ToTable("roles");
        modelBuilder.Entity<Permiso>().ToTable("permisos");
        modelBuilder.Entity<Sucursal>().ToTable("sucursales");
        modelBuilder.Entity<Proveedor>().ToTable("proveedores");
        modelBuilder.Entity<Cliente>().ToTable("clientes");
        modelBuilder.Entity<Lote>().ToTable("lotes");
        modelBuilder.Entity<Inventario>().ToTable("inventarios");
        modelBuilder.Entity<UsuarioPerfil>().ToTable("usuarios_perfiles");
        modelBuilder.Entity<Empleado>().ToTable("empleados");
        modelBuilder.Entity<Caja>().ToTable("cajas");
        modelBuilder.Entity<Arqueo>().ToTable("arqueos");
        modelBuilder.Entity<ArqueoDetalle>().ToTable("arqueo_detalles");
        modelBuilder.Entity<Compra>().ToTable("compras");
        modelBuilder.Entity<CompraDetalle>().ToTable("compra_detalles");
        modelBuilder.Entity<Venta>().ToTable("ventas");
        modelBuilder.Entity<VentaDetalle>().ToTable("venta_detalles");
        modelBuilder.Entity<VentaHistorial>().ToTable("venta_historial");
        modelBuilder.Entity<AjusteInventario>().ToTable("ajustes_inventario");
        modelBuilder.Entity<AjusteInventarioDetalle>().ToTable("ajustes_inventario_detalles");
        modelBuilder.Entity<Traslado>().ToTable("traslados");
        modelBuilder.Entity<TrasladoDetalle>().ToTable("traslado_detalles");
    }
}
