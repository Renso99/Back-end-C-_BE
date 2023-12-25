using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.DBBodega;

[Table("producto_proveedor")]
public partial class ProductoProveedor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_proveedor")]
    public int? IdProveedor { get; set; }

    [Column("id_producto")]
    public int? IdProducto { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("ProductoProveedors")]
    public virtual Producto? IdProductoNavigation { get; set; }

    [ForeignKey("IdProveedor")]
    [InverseProperty("ProductoProveedors")]
    public virtual UnidadMedidum? IdProveedorNavigation { get; set; }
}
