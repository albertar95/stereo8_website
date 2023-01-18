using System;
using System.Collections.Generic;

namespace AudioShopFrontend.Models;

public partial class BlogComment
{
    public Guid NidComment { get; set; }

    public Guid UserId { get; set; }

    public Guid BlogId { get; set; }

    public string? CommentText { get; set; }

    public byte State { get; set; }

    public DateTime CreateDate { get; set; }

    public string? PersianCreateDate { get; set; }

    public virtual Blog Blog { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
