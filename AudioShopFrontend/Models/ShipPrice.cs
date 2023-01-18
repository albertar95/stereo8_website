using System;
using System.Collections.Generic;

namespace AudioShopFrontend.Models;

public partial class ShipPrice
{
    public int Id { get; set; }

    public int FromWeight { get; set; }

    public int ToWeight { get; set; }

    public decimal InnerState { get; set; }

    public decimal NeighborState { get; set; }

    public decimal OtherState { get; set; }
}
