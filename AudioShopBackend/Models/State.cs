using System;
using System.Collections.Generic;

namespace AudioShopBackend.Models;

public partial class State
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<City> Cities { get; } = new List<City>();
}
