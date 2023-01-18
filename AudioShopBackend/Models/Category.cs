using System;
using System.Collections.Generic;

namespace AudioShopBackend.Models;

public partial class Category
{
    public Guid NidCategory { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Keywords { get; set; }

    public byte State { get; set; }

    public DateTime CreateDate { get; set; }

    public string? PersianCreateDate { get; set; }

    public DateTime? LastModified { get; set; }

    public string? PersianLastModified { get; set; }

    public virtual ICollection<Brand> Brands { get; } = new List<Brand>();

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual ICollection<Type> Types { get; } = new List<Type>();
}
