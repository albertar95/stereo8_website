using System;
using System.Collections.Generic;

namespace AudioShopFrontend.Models;

public partial class OrderDetail
{
    public Guid NidDetail { get; set; }

    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime CreateDate { get; set; }

    public string? PersianCreateDate { get; set; }

    public DateTime? LastModified { get; set; }

    public string? PersianLastModified { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
