using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.DBBodega;

[Table("usuario")]
public partial class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Username { get; set; }

    [Column("password")]
    [StringLength(300)]
    [Unicode(false)]
    public string? Password { get; set; }

    [Column("id_persona")]
    public int? IdPersona { get; set; }

    [Column("estado")]
    public bool? Estado { get; set; }

    [InverseProperty("IdUsuarioAperturaNavigation")]
    public virtual ICollection<Caja> CajaIdUsuarioAperturaNavigations { get; set; } = new List<Caja>();

    [InverseProperty("IdUsuarioCierreNavigation")]
    public virtual ICollection<Caja> CajaIdUsuarioCierreNavigations { get; set; } = new List<Caja>();

    [ForeignKey("IdPersona")]
    [InverseProperty("Usuarios")]
    public virtual Persona? IdPersonaNavigation { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
