using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.DBBodega;

[Table("sub_categoria")]
public partial class SubCategorium
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_categoria")]
    public int? IdCategoria { get; set; }

    [Column("descripcion")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [ForeignKey("IdCategoria")]
    [InverseProperty("SubCategoria")]
    public virtual Categorium? IdCategoriaNavigation { get; set; }

    [InverseProperty("IdSubCategoriaNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
