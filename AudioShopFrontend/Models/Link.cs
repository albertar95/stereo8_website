using System;
using System.Collections.Generic;

namespace AudioShopFrontend.Models;

public partial class Link
{
    public Guid NidLink { get; set; }

    public Guid RelateId { get; set; }

    public string LinkUrl { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Product Relate { get; set; } = null!;
}
