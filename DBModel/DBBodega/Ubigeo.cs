using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.DBBodega;

[Table("ubigeo")]
public partial class Ubigeo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("ubigeo")]
    [StringLength(6)]
    [Unicode(false)]
    public string? Ubigeo1 { get; set; }

    [Column("departamento")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Departamento { get; set; }

    [Column("provincia")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Provincia { get; set; }

    [Column("distrito")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Distrito { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [InverseProperty("IdUbigeoNavigation")]
    public virtual ICollection<PersonaDireccion> PersonaDireccions { get; set; } = new List<PersonaDireccion>();
}
