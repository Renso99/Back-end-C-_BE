using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models.DBBodega;

public partial class _DbContextbodega : DbContext
{
    public _DbContextbodega()
    {
    }

    public _DbContextbodega(DbContextOptions<_DbContextbodega> options)
        : base(options)
    {
    }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<CajaMovimiento> CajaMovimientos { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<ComprobantePago> ComprobantePagos { get; set; }

    public virtual DbSet<EstadoPedido> EstadoPedidos { get; set; }

    public virtual DbSet<IngresoSalidaProducto> IngresoSalidaProductos { get; set; }

    public virtual DbSet<MedioPago> MedioPagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalles { get; set; }

    public virtual DbSet<PedidoDetallePago> PedidoDetallePagos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<PersonaDireccion> PersonaDireccions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoComponente> ProductoComponentes { get; set; }

    public virtual DbSet<ProductoProveedor> ProductoProveedors { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<SubCategorium> SubCategoria { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<Ubigeo> Ubigeos { get; set; }

    public virtual DbSet<UnidadMedidum> UnidadMedida { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ASUSTUFGAMING;Initial Catalog=bodega;Integrated Security=True;Trusted_Connection=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__caja__3213E83F237418CE");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdUsuarioAperturaNavigation).WithMany(p => p.CajaIdUsuarioAperturaNavigations).HasConstraintName("FK_caja_usuario_apertura");

            entity.HasOne(d => d.IdUsuarioCierreNavigation).WithMany(p => p.CajaIdUsuarioCierreNavigations).HasConstraintName("FK_caja_usuario_cierre");
        });

        modelBuilder.Entity<CajaMovimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__caja_mov__3213E83F3E83CBAC");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdCajaNavigation).WithMany(p => p.CajaMovimientos).HasConstraintName("FK_caja_movimiento_caja");

            entity.HasOne(d => d.IdDetallePagoNavigation).WithMany(p => p.CajaMovimientos).HasConstraintName("FK_caja_movimiento_pedido_detalle_pago");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83F90487633");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<ComprobantePago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__comproba__3213E83F39DE7C26");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<EstadoPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__estado_p__3213E83F0B1DB51C");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<IngresoSalidaProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ingreso___3213E83F31F6BFF2");

            entity.HasOne(d => d.IdComprobantePagoNavigation).WithMany(p => p.IngresoSalidaProductos).HasConstraintName("FK_ingreso_salida_producto_comprobante_pago");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.IngresoSalidaProductos).HasConstraintName("FK_ingreso_salida_producto_producto");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.IngresoSalidaProductoIdProveedorNavigations).HasConstraintName("FK_ingreso_salida_producto_proveedor");

            entity.HasOne(d => d.IdUnidadMedidaNavigation).WithMany(p => p.IngresoSalidaProductoIdUnidadMedidaNavigations).HasConstraintName("FK_ingreso_salida_producto_unidad_medida");
        });

        modelBuilder.Entity<MedioPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__medio_pa__3213E83FDD116BEC");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pedido__3213E83FC47BF819");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdEstadoPedidoNavigation).WithMany(p => p.Pedidos).HasConstraintName("FK_pedido_estado_pedido");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pedidos).HasConstraintName("FK_pedido_usuario");
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pedido_d__3213E83F782579EA");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoDetalles).HasConstraintName("FK_pedido_detalle_pedido");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.PedidoDetalles).HasConstraintName("FK_pedido_detalle_producto");
        });

        modelBuilder.Entity<PedidoDetallePago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pedido_d__3213E83F4010B208");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdMedioPagoNavigation).WithMany(p => p.PedidoDetallePagos).HasConstraintName("FK_pedido_detalle_pago_medio_pago");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoDetallePagos).HasConstraintName("FK_pedido_detalle_pago_pedido");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__persona__3213E83FD2C71D3A");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Personas).HasConstraintName("FK_tipo_documento");
        });

        modelBuilder.Entity<PersonaDireccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__persona___3213E83F54421927");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.PersonaDireccions).HasConstraintName("FK_persona");

            entity.HasOne(d => d.IdUbigeoNavigation).WithMany(p => p.PersonaDireccions).HasConstraintName("FK_ubigeo");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producto__3213E83FC46EE0B4");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos).HasConstraintName("FK_CategoriaProducto");

            entity.HasOne(d => d.IdSubCategoriaNavigation).WithMany(p => p.Productos).HasConstraintName("FK_Sub_Categoria");

            entity.HasOne(d => d.IdUnidadMedidaNavigation).WithMany(p => p.Productos).HasConstraintName("FK_Unidad_Medida");
        });

        modelBuilder.Entity<ProductoComponente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producto__3213E83FFC7FBCE8");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoComponentes).HasConstraintName("FK_producto_componente_producto");
        });

        modelBuilder.Entity<ProductoProveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producto__3213E83F782D1D6F");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoProveedors).HasConstraintName("FK_producto_proveedor_producto");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.ProductoProveedors).HasConstraintName("FK_producto_proveedor_proveedor");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__proveedo__3213E83F65DDA251");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rol__3213E83FE7DFD5E2");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<SubCategorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sub_cate__3213E83FDC538B81");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.SubCategoria).HasConstraintName("FK_Categoria");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipo_doc__3213E83F2E1B8B5B");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Ubigeo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ubigeo__3213E83F9AECA6F1");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnidadMedidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__unidad_m__3213E83F44441F0D");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuario__3213E83F19625849");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios).HasConstraintName("FK_usuario_persona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
