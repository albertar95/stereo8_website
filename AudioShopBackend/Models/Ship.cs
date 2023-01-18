using System;
using System.Collections.Generic;

namespace AudioShopBackend.Models;

public partial class Ship
{
    public Guid NidShip { get; set; }

    public DateTime CreateDate { get; set; }

    public string? PersianCreateDate { get; set; }

    public DateTime? DueDate { get; set; }

    public string? PersianDueDate { get; set; }

    public byte ShipVia { get; set; }

    public string Address { get; set; } = null!;

    public decimal ZipCode { get; set; }

    public byte State { get; set; }

    public decimal ShipPrice { get; set; }

    public Guid OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;
}
