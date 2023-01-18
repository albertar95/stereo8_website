using System;
using System.Collections.Generic;

namespace AudioShopFrontend.Models;

public partial class Favorite
{
    public Guid NidFav { get; set; }

    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? PersianCreateDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
