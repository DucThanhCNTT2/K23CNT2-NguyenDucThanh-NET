using System;
using System.Collections.Generic;

namespace NguyenDucThanh_2310900098.Models;

public partial class NdtEmployee
{
    public int NdtEmpId { get; set; }

    public string? NdtEmpName { get; set; }

    public string? NdtEmpLevel { get; set; }

    public DateOnly? NdtEmpStartDate { get; set; }

    public bool? NdtEmpStatus { get; set; }
}
