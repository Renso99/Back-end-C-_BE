using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.DBBodega;

[Table("ingreso_salida_producto")]
public partial class IngresoSalidaProducto
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_producto")]
    public int? IdProducto { get; set; }

    [Column("id_unidad_medida")]
    public int? IdUnidadMedida { get; set; }

    [Column("id_comprobante_pago")]
    public int? IdComprobantePago { get; set; }

    [Column("id_proveedor")]
    public int? IdProveedor { get; set; }

    [Column("tipo")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Tipo { get; set; }

    [Column("nro_lote")]
    [StringLength(30)]
    [Unicode(false)]
    public string? NroLote { get; set; }

    [Column("fecha_vencimiento", TypeName = "date")]
    public DateTime? FechaVencimiento { get; set; }

    [Column("cantidad_ingreso", TypeName = "decimal(8, 2)")]
    public decimal? CantidadIngreso { get; set; }

    [Column("cantidad_salida", TypeName = "decimal(8, 2)")]
    public decimal? CantidadSalida { get; set; }

    [Column("fecha_registro", TypeName = "date")]
    public DateTime? FechaRegistro { get; set; }

    [Column("fecha_boleta", TypeName = "date")]
    public DateTime? FechaBoleta { get; set; }

    [Column("nro_serie")]
    [StringLength(5)]
    [Unicode(false)]
    public string? NroSerie { get; set; }

    [Column("correlativo")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Correlativo { get; set; }

    [Column("precio_unitario", TypeName = "decimal(8, 2)")]
    public decimal? PrecioUnitario { get; set; }

    [Column("precio_total", TypeName = "decimal(8, 2)")]
    public decimal? PrecioTotal { get; set; }

    [Column("motivo")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Motivo { get; set; }

    [ForeignKey("IdComprobantePago")]
    [InverseProperty("IngresoSalidaProductos")]
    public virtual ComprobantePago? IdComprobantePagoNavigation { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("IngresoSalidaProductos")]
    public virtual Producto? IdProductoNavigation { get; set; }

    [ForeignKey("IdProveedor")]
    [InverseProperty("IngresoSalidaProductoIdProveedorNavigations")]
    public virtual UnidadMedidum? IdProveedorNavigation { get; set; }

    [ForeignKey("IdUnidadMedida")]
    [InverseProperty("IngresoSalidaProductoIdUnidadMedidaNavigations")]
    public virtual UnidadMedidum? IdUnidadMedidaNavigation { get; set; }
}
