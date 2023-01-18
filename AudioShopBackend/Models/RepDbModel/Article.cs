using System;
using System.Collections.Generic;

namespace AudioShopBackend.Models.RepDbModel;

public partial class Article
{
    public string ACode { get; set; } = null!;

    public string? AName { get; set; }

    public double? SelPrice { get; set; }

    public double? Exist { get; set; }

    public double? ExistMandeh { get; set; }

    public double? Karton { get; set; }

    public double? Basteh { get; set; }

    public double? Weight { get; set; }

    public double? Weight2 { get; set; }
}
