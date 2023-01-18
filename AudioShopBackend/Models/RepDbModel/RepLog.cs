using System;
using System.Collections.Generic;

namespace AudioShopBackend.Models.RepDbModel;

public partial class RepLog
{
    public Guid Id { get; set; }

    public DateTime ReplicationDate { get; set; }

    public string ResultStatus { get; set; } = null!;

    public int? Duration { get; set; }

    public string? Description { get; set; }
}
