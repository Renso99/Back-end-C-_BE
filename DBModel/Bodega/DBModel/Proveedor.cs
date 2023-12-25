using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Bodega.DBModel;

[Table("proveedor")]
public partial class Proveedor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("ruc")]
    [StringLength(11)]
    [Unicode(false)]
    public string? Ruc { get; set; }

    [Column("razon_social")]
    [StringLength(100)]
    [Unicode(false)]
    public string? RazonSocial { get; set; }

    [Column("telefono")]
    [StringLength(13)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [Column("contacto")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Contacto { get; set; }

    [Column("email")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }
}
