using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PharmaPro.Domain.Entities;

namespace PharmaPro.Infrastructure.Persistence;

public partial class PharmaDbContext : DbContext
{
    public PharmaDbContext(DbContextOptions<PharmaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AjusteInventario> AjustesInventarios { get; set; }

    public virtual DbSet<AjusteInventarioDetalle> AjusteInventarioDetalles { get; set; }

    public virtual DbSet<Arqueo> Arqueos { get; set; }

    public virtual DbSet<ArqueoDetalle> ArqueoDetalles { get; set; }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<CompraDetalle> CompraDetalles { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<FormaFarmaceutica> FormasFarmaceuticas { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Laboratorio> Laboratorios { get; set; }

    public virtual DbSet<Lote> Lotes { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Presentacion> Presentaciones { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedores { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }

    public virtual DbSet<Sucursal> Sucursales { get; set; }

    public virtual DbSet<Traslado> Traslados { get; set; }

    public virtual DbSet<TrasladoDetalle> TrasladoDetalles { get; set; }

    public virtual DbSet<UsuarioPerfil> UsuariosPerfiles { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    public virtual DbSet<VentaDetalle> VentaDetalles { get; set; }

    public virtual DbSet<VentaHistorial> VentaHistorials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "oauth_authorization_status", new[] { "pending", "approved", "denied", "expired" })
            .HasPostgresEnum("auth", "oauth_client_type", new[] { "public", "confidential" })
            .HasPostgresEnum("auth", "oauth_registration_type", new[] { "dynamic", "manual" })
            .HasPostgresEnum("auth", "oauth_response_type", new[] { "code" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in", "like", "ilike", "is", "match", "imatch", "isdistinct" })
            .HasPostgresEnum("storage", "buckettype", new[] { "STANDARD", "ANALYTICS", "VECTOR" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<AjusteInventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ajustes_inventario_pkey");

            entity.ToTable("ajustes_inventario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'pendiente'::text")
                .HasColumnName("estado");
            entity.Property(e => e.Motivo).HasColumnName("motivo");
            entity.Property(e => e.Observacion).HasColumnName("observacion");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.AjustesInventarios)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ajustes_inventario_sucursal_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.AjustesInventarios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ajustes_inventario_usuario_id_fkey");
        });

        modelBuilder.Entity<AjusteInventarioDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ajustes_inventario_detalles_pkey");

            entity.ToTable("ajustes_inventario_detalles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AjusteId).HasColumnName("ajuste_id");
            entity.Property(e => e.CantidadAnterior)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad_anterior");
            entity.Property(e => e.CantidadNueva)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad_nueva");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Diferencia)
                .HasPrecision(12, 2)
                .HasColumnName("diferencia");
            entity.Property(e => e.LoteId).HasColumnName("lote_id");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");

            entity.HasOne(d => d.Ajuste).WithMany(p => p.AjusteInventarioDetalles)
                .HasForeignKey(d => d.AjusteId)
                .HasConstraintName("ajustes_inventario_detalles_ajuste_id_fkey");

            entity.HasOne(d => d.Lote).WithMany(p => p.AjusteInventarioDetalles)
                .HasForeignKey(d => d.LoteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ajustes_inventario_detalles_lote_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.AjusteInventarioDetalles)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ajustes_inventario_detalles_producto_id_fkey");
        });

        modelBuilder.Entity<Arqueo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("arqueos_pkey");

            entity.ToTable("arqueos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CajaId).HasColumnName("caja_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Diferencia)
                .HasPrecision(12, 2)
                .HasColumnName("diferencia");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'abierto'::text")
                .HasColumnName("estado");
            entity.Property(e => e.FechaApertura)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha_apertura");
            entity.Property(e => e.FechaCierre).HasColumnName("fecha_cierre");
            entity.Property(e => e.MontoEsperado)
                .HasPrecision(12, 2)
                .HasColumnName("monto_esperado");
            entity.Property(e => e.MontoInicial)
                .HasPrecision(12, 2)
                .HasColumnName("monto_inicial");
            entity.Property(e => e.MontoReal)
                .HasPrecision(12, 2)
                .HasColumnName("monto_real");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Caja).WithMany(p => p.Arqueos)
                .HasForeignKey(d => d.CajaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("arqueos_caja_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Arqueos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("arqueos_usuario_id_fkey");
        });

        modelBuilder.Entity<ArqueoDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("arqueo_detalles_pkey");

            entity.ToTable("arqueo_detalles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArqueoId).HasColumnName("arqueo_id");
            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Monto)
                .HasPrecision(12, 2)
                .HasColumnName("monto");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Arqueo).WithMany(p => p.ArqueoDetalles)
                .HasForeignKey(d => d.ArqueoId)
                .HasConstraintName("arqueo_detalles_arqueo_id_fkey");
        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cajas_pkey");

            entity.ToTable("cajas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.MontoInicial)
                .HasPrecision(12, 2)
                .HasColumnName("monto_inicial");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Cajas)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("cajas_sucursal_id_fkey");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorias_pkey");

            entity.ToTable("categorias");

            entity.HasIndex(e => e.Nombre, "categorias_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clientes_pkey");

            entity.ToTable("clientes");

            entity.HasIndex(e => new { e.TipoDocumento, e.NumeroDocumento }, "clientes_tipo_documento_numero_documento_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos).HasColumnName("apellidos");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Nombres).HasColumnName("nombres");
            entity.Property(e => e.NumeroDocumento).HasColumnName("numero_documento");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.TipoDocumento).HasColumnName("tipo_documento");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("compras_pkey");

            entity.ToTable("compras");

            entity.HasIndex(e => e.Fecha, "idx_compras_fecha");

            entity.HasIndex(e => e.ProveedorId, "idx_compras_proveedor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Descuento)
                .HasPrecision(12, 2)
                .HasColumnName("descuento");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'registrada'::text")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("fecha");
            entity.Property(e => e.Impuesto)
                .HasPrecision(12, 2)
                .HasColumnName("impuesto");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.Serie).HasColumnName("serie");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.TipoComprobante).HasColumnName("tipo_comprobante");
            entity.Property(e => e.Total)
                .HasPrecision(12, 2)
                .HasColumnName("total");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("compras_proveedor_id_fkey");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Compras)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("compras_sucursal_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Compras)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("compras_usuario_id_fkey");
        });

        modelBuilder.Entity<CompraDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("compra_detalles_pkey");

            entity.ToTable("compra_detalles");

            entity.HasIndex(e => e.CompraId, "idx_compra_detalles_compra");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad");
            entity.Property(e => e.CompraId).HasColumnName("compra_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Descuento)
                .HasPrecision(12, 2)
                .HasColumnName("descuento");
            entity.Property(e => e.LoteId).HasColumnName("lote_id");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(12, 2)
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Compra).WithMany(p => p.CompraDetalles)
                .HasForeignKey(d => d.CompraId)
                .HasConstraintName("compra_detalles_compra_id_fkey");

            entity.HasOne(d => d.Lote).WithMany(p => p.CompraDetalles)
                .HasForeignKey(d => d.LoteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("compra_detalles_lote_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.CompraDetalles)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("compra_detalles_producto_id_fkey");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("empleados_pkey");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.Documento, "empleados_documento_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos).HasColumnName("apellidos");
            entity.Property(e => e.Cargo).HasColumnName("cargo");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Documento).HasColumnName("documento");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Nombres).HasColumnName("nombres");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("empleados_sucursal_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("empleados_usuario_id_fkey");
        });

        modelBuilder.Entity<FormaFarmaceutica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("formas_farmaceuticas_pkey");

            entity.ToTable("formas_farmaceuticas");

            entity.HasIndex(e => e.Nombre, "formas_farmaceuticas_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inventarios_pkey");

            entity.ToTable("inventarios");

            entity.HasIndex(e => e.ProductoId, "idx_inventarios_producto");

            entity.HasIndex(e => e.SucursalId, "idx_inventarios_sucursal");

            entity.HasIndex(e => new { e.ProductoId, e.LoteId, e.SucursalId }, "inventarios_producto_id_lote_id_sucursal_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.LoteId).HasColumnName("lote_id");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Stock)
                .HasPrecision(12, 2)
                .HasColumnName("stock");
            entity.Property(e => e.StockReservado)
                .HasPrecision(12, 2)
                .HasColumnName("stock_reservado");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Lote).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.LoteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("inventarios_lote_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("inventarios_producto_id_fkey");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("inventarios_sucursal_id_fkey");
        });

        modelBuilder.Entity<Laboratorio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("laboratorios_pkey");

            entity.ToTable("laboratorios");

            entity.HasIndex(e => e.Nombre, "laboratorios_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Lote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lotes_pkey");

            entity.ToTable("lotes");

            entity.HasIndex(e => e.FechaVencimiento, "idx_lotes_fecha_vencimiento");

            entity.HasIndex(e => e.ProductoId, "idx_lotes_producto");

            entity.HasIndex(e => e.FechaVencimiento, "idx_lotes_vencimiento");

            entity.HasIndex(e => new { e.ProductoId, e.NumeroLote }, "lotes_producto_id_numero_lote_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad");
            entity.Property(e => e.CostoUnitario)
                .HasPrecision(12, 2)
                .HasColumnName("costo_unitario");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaFabricacion).HasColumnName("fecha_fabricacion");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.NumeroLote).HasColumnName("numero_lote");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Producto).WithMany(p => p.Lotes)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("lotes_producto_id_fkey");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Lotes)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("lotes_proveedor_id_fkey");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permisos_pkey");

            entity.ToTable("permisos");

            entity.HasIndex(e => e.Nombre, "permisos_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Modulo).HasColumnName("modulo");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Presentacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("presentaciones_pkey");

            entity.ToTable("presentaciones");

            entity.HasIndex(e => e.Nombre, "presentaciones_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("productos_pkey");

            entity.ToTable("productos");

            entity.HasIndex(e => e.CategoriaId, "idx_productos_categoria");

            entity.HasIndex(e => e.LaboratorioId, "idx_productos_laboratorio");

            entity.HasIndex(e => e.Nombre, "idx_productos_nombre");

            entity.HasIndex(e => e.Codigo, "productos_codigo_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FormaFarmaceuticaId).HasColumnName("forma_farmaceutica_id");
            entity.Property(e => e.LaboratorioId).HasColumnName("laboratorio_id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.PrecioCompra)
                .HasPrecision(12, 2)
                .HasColumnName("precio_compra");
            entity.Property(e => e.PrecioVenta)
                .HasPrecision(12, 2)
                .HasColumnName("precio_venta");
            entity.Property(e => e.PresentacionId).HasColumnName("presentacion_id");
            entity.Property(e => e.PrincipioActivo).HasColumnName("principio_activo");
            entity.Property(e => e.RequiereReceta)
                .HasDefaultValue(false)
                .HasColumnName("requiere_receta");
            entity.Property(e => e.StockMaximo)
                .HasPrecision(12, 2)
                .HasColumnName("stock_maximo");
            entity.Property(e => e.StockMinimo)
                .HasPrecision(12, 2)
                .HasColumnName("stock_minimo");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("productos_categoria_id_fkey");

            entity.HasOne(d => d.FormaFarmaceutica).WithMany(p => p.Productos)
                .HasForeignKey(d => d.FormaFarmaceuticaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("productos_forma_farmaceutica_id_fkey");

            entity.HasOne(d => d.Laboratorio).WithMany(p => p.Productos)
                .HasForeignKey(d => d.LaboratorioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("productos_laboratorio_id_fkey");

            entity.HasOne(d => d.Presentacion).WithMany(p => p.Productos)
                .HasForeignKey(d => d.PresentacionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("productos_presentacion_id_fkey");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("proveedores_pkey");

            entity.ToTable("proveedores");

            entity.HasIndex(e => e.Ruc, "proveedores_ruc_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contacto).HasColumnName("contacto");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.RazonSocial).HasColumnName("razon_social");
            entity.Property(e => e.Ruc).HasColumnName("ruc");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Nombre, "roles_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sucursales_pkey");

            entity.ToTable("sucursales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Traslado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("traslados_pkey");

            entity.ToTable("traslados");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'pendiente'::text")
                .HasColumnName("estado");
            entity.Property(e => e.Observacion).HasColumnName("observacion");
            entity.Property(e => e.SucursalDestinoId).HasColumnName("sucursal_destino_id");
            entity.Property(e => e.SucursalOrigenId).HasColumnName("sucursal_origen_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.SucursalDestino).WithMany(p => p.TrasladoSucursalDestinos)
                .HasForeignKey(d => d.SucursalDestinoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("traslados_sucursal_destino_id_fkey");

            entity.HasOne(d => d.SucursalOrigen).WithMany(p => p.TrasladoSucursalOrigens)
                .HasForeignKey(d => d.SucursalOrigenId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("traslados_sucursal_origen_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Traslados)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("traslados_usuario_id_fkey");
        });

        modelBuilder.Entity<TrasladoDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("traslado_detalles_pkey");

            entity.ToTable("traslado_detalles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.LoteId).HasColumnName("lote_id");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.TrasladoId).HasColumnName("traslado_id");

            entity.HasOne(d => d.Lote).WithMany(p => p.TrasladoDetalles)
                .HasForeignKey(d => d.LoteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("traslado_detalles_lote_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.TrasladoDetalles)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("traslado_detalles_producto_id_fkey");

            entity.HasOne(d => d.Traslado).WithMany(p => p.TrasladoDetalles)
                .HasForeignKey(d => d.TrasladoId)
                .HasConstraintName("traslado_detalles_traslado_id_fkey");
        });

        modelBuilder.Entity<UsuarioPerfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_perfiles_pkey");

            entity.ToTable("usuarios_perfiles");

            entity.HasIndex(e => e.Documento, "usuarios_perfiles_documento_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Apellidos).HasColumnName("apellidos");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Documento).HasColumnName("documento");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Nombres).HasColumnName("nombres");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuariosPerfiles)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("usuarios_perfiles_rol_id_fkey");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.UsuariosPerfiles)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("usuarios_perfiles_sucursal_id_fkey");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ventas_pkey");

            entity.ToTable("ventas");

            entity.HasIndex(e => e.ClienteId, "idx_ventas_cliente");

            entity.HasIndex(e => e.Fecha, "idx_ventas_fecha");

            entity.HasIndex(e => e.SucursalId, "idx_ventas_sucursal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CajaId).HasColumnName("caja_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Descuento)
                .HasPrecision(12, 2)
                .HasColumnName("descuento");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'completada'::text")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("now()")
                .HasColumnName("fecha");
            entity.Property(e => e.Impuesto)
                .HasPrecision(12, 2)
                .HasColumnName("impuesto");
            entity.Property(e => e.MetodoPago).HasColumnName("metodo_pago");
            entity.Property(e => e.MontoPagado)
                .HasPrecision(12, 2)
                .HasColumnName("monto_pagado");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Serie).HasColumnName("serie");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.TipoComprobante).HasColumnName("tipo_comprobante");
            entity.Property(e => e.Total)
                .HasPrecision(12, 2)
                .HasColumnName("total");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.Vuelto)
                .HasPrecision(12, 2)
                .HasColumnName("vuelto");

            entity.HasOne(d => d.Caja).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CajaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ventas_caja_id_fkey");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ventas_cliente_id_fkey");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Venta)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ventas_sucursal_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Venta)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ventas_usuario_id_fkey");
        });

        modelBuilder.Entity<VentaDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venta_detalles_pkey");

            entity.ToTable("venta_detalles");

            entity.HasIndex(e => e.VentaId, "idx_venta_detalles_venta");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Descuento)
                .HasPrecision(12, 2)
                .HasColumnName("descuento");
            entity.Property(e => e.LoteId).HasColumnName("lote_id");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(12, 2)
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.VentaId).HasColumnName("venta_id");

            entity.HasOne(d => d.Lote).WithMany(p => p.VentaDetalles)
                .HasForeignKey(d => d.LoteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("venta_detalles_lote_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.VentaDetalles)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("venta_detalles_producto_id_fkey");

            entity.HasOne(d => d.Venta).WithMany(p => p.VentaDetalles)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("venta_detalles_venta_id_fkey");
        });

        modelBuilder.Entity<VentaHistorial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venta_historial_pkey");

            entity.ToTable("venta_historial");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accion).HasColumnName("accion");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.EstadoAnterior).HasColumnName("estado_anterior");
            entity.Property(e => e.EstadoNuevo).HasColumnName("estado_nuevo");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.VentaId).HasColumnName("venta_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.VentaHistorials)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("venta_historial_usuario_id_fkey");

            entity.HasOne(d => d.Venta).WithMany(p => p.VentaHistorials)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("venta_historial_venta_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}


