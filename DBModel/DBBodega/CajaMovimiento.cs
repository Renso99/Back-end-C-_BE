using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.DBBodega;

[Table("caja_movimiento")]
public partial class CajaMovimiento
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_caja")]
    public int? IdCaja { get; set; }

    [Column("tipo")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Tipo { get; set; }

    [Column("monto", TypeName = "decimal(8, 2)")]
    public decimal? Monto { get; set; }

    [Column("id_detalle_pago")]
    public int? IdDetallePago { get; set; }

    [ForeignKey("IdCaja")]
    [InverseProperty("CajaMovimientos")]
    public virtual Caja? IdCajaNavigation { get; set; }

    [ForeignKey("IdDetallePago")]
    [InverseProperty("CajaMovimientos")]
    public virtual PedidoDetallePago? IdDetallePagoNavigation { get; set; }
}
