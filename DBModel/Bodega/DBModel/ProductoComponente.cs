using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Bodega.DBModel;

[Table("producto_componente")]
public partial class ProductoComponente
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_producto")]
    public int? IdProducto { get; set; }

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("cantidad")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Cantidad { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("ProductoComponentes")]
    public virtual Producto? IdProductoNavigation { get; set; }
}
