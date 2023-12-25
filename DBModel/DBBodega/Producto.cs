using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.DBBodega;

[Table("producto")]
public partial class Producto
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_categoria")]
    public int? IdCategoria { get; set; }

    [Column("id_sub_categoria")]
    public int? IdSubCategoria { get; set; }

    [Column("id_unidad_medida")]
    public int? IdUnidadMedida { get; set; }

    [Column("codigo")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Codigo { get; set; }

    [Column("nombre")]
    [StringLength(150)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("stock", TypeName = "decimal(8, 2)")]
    public decimal? Stock { get; set; }

    [Column("stock_minimo", TypeName = "decimal(8, 2)")]
    public decimal? StockMinimo { get; set; }

    [Column("precio_compra", TypeName = "decimal(8, 2)")]
    public decimal? PrecioCompra { get; set; }

    [Column("precio_venta", TypeName = "decimal(8, 2)")]
    public decimal? PrecioVenta { get; set; }

    [Column("descripcion")]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("estado")]
    public bool? Estado { get; set; }

    [ForeignKey("IdCategoria")]
    [InverseProperty("Productos")]
    public virtual Categorium? IdCategoriaNavigation { get; set; }

    [ForeignKey("IdSubCategoria")]
    [InverseProperty("Productos")]
    public virtual SubCategorium? IdSubCategoriaNavigation { get; set; }

    [ForeignKey("IdUnidadMedida")]
    [InverseProperty("Productos")]
    public virtual UnidadMedidum? IdUnidadMedidaNavigation { get; set; }

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<IngresoSalidaProducto> IngresoSalidaProductos { get; set; } = new List<IngresoSalidaProducto>();

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<ProductoComponente> ProductoComponentes { get; set; } = new List<ProductoComponente>();

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<ProductoProveedor> ProductoProveedors { get; set; } = new List<ProductoProveedor>();
}
