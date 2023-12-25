using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Bodega.DBModel;

[Table("medio_pago")]
public partial class MedioPago
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("titular")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Titular { get; set; }

    [InverseProperty("IdMedioPagoNavigation")]
    public virtual ICollection<PedidoDetallePago> PedidoDetallePagos { get; set; } = new List<PedidoDetallePago>();
}
