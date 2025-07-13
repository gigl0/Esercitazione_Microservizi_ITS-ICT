using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrestitiBibliotecaWebAPI.Models;

[Table("Libro")]
public partial class Libro
{
    [Key]
    public int Codice { get; set; }

    [StringLength(50)]
    public string Autore { get; set; } = null!;

    [StringLength(50)]
    public string Titolo { get; set; } = null!;

    [StringLength(50)]
    public string Editore { get; set; } = null!;

    public int? Anno { get; set; }

    [StringLength(50)]
    public string? Luogo { get; set; }

    [StringLength(50)]
    public string Pagine { get; set; } = null!;

    [StringLength(50)]
    public string Classificazione { get; set; } = null!;

    [StringLength(50)]
    public string Collocazione { get; set; } = null!;

    public int? Copie { get; set; }
}
