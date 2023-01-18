using System;
using System.Collections.Generic;

namespace AudioShopFrontend.Models;

public partial class Type
{
    public Guid NidType { get; set; }

    public string TypeName { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public byte State { get; set; }

    public string? Description { get; set; }

    public string? Keywords { get; set; }

    public DateTime CreateDate { get; set; }

    public string? PersianCreateDate { get; set; }

    public DateTime? LastModified { get; set; }

    public string? PersianLastModified { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
