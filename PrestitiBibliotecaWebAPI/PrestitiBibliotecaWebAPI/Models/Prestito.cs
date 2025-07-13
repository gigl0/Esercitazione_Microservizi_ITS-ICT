using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrestitiBibliotecaWebAPI.Models;

[Table("Prestito")]
public partial class Prestito
{
    [Key]
    public int Id { get; set; }

    public int IdLibro { get; set; }

    public int Matricola { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataPrestito { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataRestituzione { get; set; }
}
