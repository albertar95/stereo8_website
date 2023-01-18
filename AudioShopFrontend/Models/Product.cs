using System;
using System.Collections.Generic;

namespace AudioShopFrontend.Models;

public partial class Product
{
    public Guid NidProduct { get; set; }

    public string ProductName { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public Guid BrandId { get; set; }

    public Guid TypeId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? PersianCreateDate { get; set; }

    public DateTime? LastModified { get; set; }

    public string? PersianLastModified { get; set; }

    public string? Description { get; set; }

    public string? Keywords { get; set; }

    public decimal Price { get; set; }

    public decimal PriceWithoutOff { get; set; }

    public byte State { get; set; }

    public byte Priority { get; set; }

    public byte OffPercentage { get; set; }

    public int AvailableCount { get; set; }

    public string? Specification { get; set; }

    public string? DetailDesc { get; set; }

    public Guid UserId { get; set; }

    public byte? Rating { get; set; }

    public double? Weight { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Favorite> Favorites { get; } = new List<Favorite>();

    public virtual ICollection<Link> Links { get; } = new List<Link>();

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual Type Type { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
