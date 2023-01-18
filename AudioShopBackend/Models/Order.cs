using System;
using System.Collections.Generic;

namespace AudioShopBackend.Models;

public partial class Order
{
    public Guid NidOrder { get; set; }

    public Guid UserId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime CreateDate { get; set; }

    public string? PersianCreateDate { get; set; }

    public int State { get; set; }

    public string? Description { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? StateId { get; set; }

    public int? CityId { get; set; }

    public string? Address { get; set; }

    public decimal? ZipCode { get; set; }

    public string? Tel { get; set; }

    public string? Email { get; set; }

    public decimal? MelliCode { get; set; }

    public long? RefId { get; set; }

    public DateTime? LastModified { get; set; }

    public string? PersianLastModified { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual ICollection<Ship> Ships { get; } = new List<Ship>();

    public virtual User User { get; set; } = null!;
}
