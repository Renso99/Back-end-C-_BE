using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Bodega.DBModel;

[Table("pedido_detalle")]
public partial class PedidoDetalle
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_pedido")]
    public int? IdPedido { get; set; }

    [Column("id_producto")]
    public int? IdProducto { get; set; }

    [Column("cantidad", TypeName = "decimal(8, 2)")]
    public decimal? Cantidad { get; set; }

    [Column("precio_unitario", TypeName = "decimal(8, 2)")]
    public decimal? PrecioUnitario { get; set; }

    [Column("sub_total", TypeName = "decimal(8, 2)")]
    public decimal? SubTotal { get; set; }

    [Column("estado")]
    public bool? Estado { get; set; }

    [ForeignKey("IdPedido")]
    [InverseProperty("PedidoDetalles")]
    public virtual Pedido? IdPedidoNavigation { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("PedidoDetalles")]
    public virtual Producto? IdProductoNavigation { get; set; }
}
