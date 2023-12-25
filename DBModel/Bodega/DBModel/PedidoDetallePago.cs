using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Bodega.DBModel;

[Table("pedido_detalle_pago")]
public partial class PedidoDetallePago
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_medio_pago")]
    public int? IdMedioPago { get; set; }

    [Column("id_pedido")]
    public int? IdPedido { get; set; }

    [Column("monto_pago", TypeName = "decimal(8, 2)")]
    public decimal? MontoPago { get; set; }

    [InverseProperty("IdDetallePagoNavigation")]
    public virtual ICollection<CajaMovimiento> CajaMovimientos { get; set; } = new List<CajaMovimiento>();

    [ForeignKey("IdMedioPago")]
    [InverseProperty("PedidoDetallePagos")]
    public virtual MedioPago? IdMedioPagoNavigation { get; set; }

    [ForeignKey("IdPedido")]
    [InverseProperty("PedidoDetallePagos")]
    public virtual Pedido? IdPedidoNavigation { get; set; }
}
