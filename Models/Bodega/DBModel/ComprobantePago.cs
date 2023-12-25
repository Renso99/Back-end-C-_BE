using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Bodega.DBModel;

[Table("comprobante_pago")]
public partial class ComprobantePago
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("codigo_sunat")]
    [StringLength(3)]
    [Unicode(false)]
    public string? CodigoSunat { get; set; }

    [Column("descripcion")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [InverseProperty("IdComprobantePagoNavigation")]
    public virtual ICollection<IngresoSalidaProducto> IngresoSalidaProductos { get; set; } = new List<IngresoSalidaProducto>();
}
