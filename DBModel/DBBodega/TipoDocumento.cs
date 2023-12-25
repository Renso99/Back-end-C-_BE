using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.DBBodega;

[Table("tipo_documento")]
public partial class TipoDocumento
{
    [Key]
    [Column("id")]
    public short Id { get; set; }

    [Column("descripcion")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [InverseProperty("IdTipoDocumentoNavigation")]
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
