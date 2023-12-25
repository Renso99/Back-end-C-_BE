using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Bodega.DBModel;

[Table("persona")]
[Index("NroDocumento", Name = "UQ__persona__761A4C4688FF9B8B", IsUnique = true)]
public partial class Persona
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_tipo_documento")]
    public short? IdTipoDocumento { get; set; }

    [Column("nro_documento")]
    [StringLength(15)]
    [Unicode(false)]
    public string? NroDocumento { get; set; }

    [Column("ap_paterno")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ApPaterno { get; set; }

    [Column("ap_materno")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ApMaterno { get; set; }

    [Column("ap_nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ApNombre { get; set; }

    [Column("fecha_nacimiento", TypeName = "date")]
    public DateTime? FechaNacimiento { get; set; }

    [Column("telefono")]
    [StringLength(13)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [Column("correo")]
    [StringLength(70)]
    [Unicode(false)]
    public string? Correo { get; set; }

    [ForeignKey("IdTipoDocumento")]
    [InverseProperty("Personas")]
    public virtual TipoDocumento? IdTipoDocumentoNavigation { get; set; }

    [InverseProperty("IdPersonaNavigation")]
    public virtual ICollection<PersonaDireccion> PersonaDireccions { get; set; } = new List<PersonaDireccion>();

    [InverseProperty("IdPersonaNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
