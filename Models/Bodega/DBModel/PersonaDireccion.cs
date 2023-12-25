using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Bodega.DBModel;

[Table("persona_direccion")]
public partial class PersonaDireccion
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_persona")]
    public int? IdPersona { get; set; }

    [Column("id_ubigeo")]
    public int? IdUbigeo { get; set; }

    [Column("calle")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Calle { get; set; }

    [Column("nro")]
    [StringLength(5)]
    [Unicode(false)]
    public string? Nro { get; set; }

    [Column("referencia")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Referencia { get; set; }

    [Column("latitud")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Latitud { get; set; }

    [Column("longitud")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Longitud { get; set; }

    [ForeignKey("IdPersona")]
    [InverseProperty("PersonaDireccions")]
    public virtual Persona? IdPersonaNavigation { get; set; }

    [ForeignKey("IdUbigeo")]
    [InverseProperty("PersonaDireccions")]
    public virtual Ubigeo? IdUbigeoNavigation { get; set; }
}
