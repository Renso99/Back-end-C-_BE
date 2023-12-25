using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.DBBodega;

[Table("pedido")]
public partial class Pedido
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_persona")]
    public int? IdPersona { get; set; }

    [Column("id_estado_pedido")]
    public int? IdEstadoPedido { get; set; }

    [Column("fecha", TypeName = "date")]
    public DateTime? Fecha { get; set; }

    [Column("estado_pagago")]
    public bool? EstadoPagago { get; set; }

    [Column("fiado")]
    public bool? Fiado { get; set; }

    [Column("delivery")]
    public bool? Delivery { get; set; }

    [Column("id_persona_direccion")]
    public int? IdPersonaDireccion { get; set; }

    [Column("monto_total", TypeName = "decimal(8, 2)")]
    public decimal? MontoTotal { get; set; }

    [Column("monto_pagado", TypeName = "decimal(8, 2)")]
    public decimal? MontoPagado { get; set; }

    [Column("monto_por_pagar", TypeName = "decimal(8, 2)")]
    public decimal? MontoPorPagar { get; set; }

    [Column("igv", TypeName = "decimal(8, 2)")]
    public decimal? Igv { get; set; }

    [Column("nro_serie")]
    [StringLength(5)]
    [Unicode(false)]
    public string? NroSerie { get; set; }

    [Column("correlativo")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Correlativo { get; set; }

    [Column("id_usuario")]
    public int? IdUsuario { get; set; }

    [ForeignKey("IdEstadoPedido")]
    [InverseProperty("Pedidos")]
    public virtual EstadoPedido? IdEstadoPedidoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Pedidos")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }

    [InverseProperty("IdPedidoNavigation")]
    public virtual ICollection<PedidoDetallePago> PedidoDetallePagos { get; set; } = new List<PedidoDetallePago>();

    [InverseProperty("IdPedidoNavigation")]
    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
