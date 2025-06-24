using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NdtLesoon10FE.Models;

public partial class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CateId { get; set; }

    public string? CateName { get; set; }

    public bool? CateStatus { get; set; }
}
