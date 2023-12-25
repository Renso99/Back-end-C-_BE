using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.DBBodega;

[Table("caja")]
public partial class Caja
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("fecha", TypeName = "date")]
    public DateTime? Fecha { get; set; }

    [Column("id_usuario_apertura")]
    public int? IdUsuarioApertura { get; set; }

    [Column("id_usuario_cierre")]
    public int? IdUsuarioCierre { get; set; }

    [Column("estado")]
    public bool? Estado { get; set; }

    [Column("monto_apertura", TypeName = "decimal(8, 2)")]
    public decimal? MontoApertura { get; set; }

    [Column("monto_cierre", TypeName = "decimal(8, 2)")]
    public decimal? MontoCierre { get; set; }

    [InverseProperty("IdCajaNavigation")]
    public virtual ICollection<CajaMovimiento> CajaMovimientos { get; set; } = new List<CajaMovimiento>();

    [ForeignKey("IdUsuarioApertura")]
    [InverseProperty("CajaIdUsuarioAperturaNavigations")]
    public virtual Usuario? IdUsuarioAperturaNavigation { get; set; }

    [ForeignKey("IdUsuarioCierre")]
    [InverseProperty("CajaIdUsuarioCierreNavigations")]
    public virtual Usuario? IdUsuarioCierreNavigation { get; set; }
}
