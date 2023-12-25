using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Bodega.DBModel;

[Table("unidad_medida")]
public partial class UnidadMedidum
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("descripcion")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [InverseProperty("IdProveedorNavigation")]
    public virtual ICollection<IngresoSalidaProducto> IngresoSalidaProductoIdProveedorNavigations { get; set; } = new List<IngresoSalidaProducto>();

    [InverseProperty("IdUnidadMedidaNavigation")]
    public virtual ICollection<IngresoSalidaProducto> IngresoSalidaProductoIdUnidadMedidaNavigations { get; set; } = new List<IngresoSalidaProducto>();

    [InverseProperty("IdProveedorNavigation")]
    public virtual ICollection<ProductoProveedor> ProductoProveedors { get; set; } = new List<ProductoProveedor>();

    [InverseProperty("IdUnidadMedidaNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
