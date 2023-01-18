using System;
using System.Collections.Generic;

namespace AudioShopBackend.Models;

public partial class Blog
{
    public Guid NidBlog { get; set; }

    public string Title { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? PersianCreateDate { get; set; }

    public DateTime? LastModified { get; set; }

    public string? PersianLastModified { get; set; }

    public string Contents { get; set; } = null!;

    public string? Description { get; set; }

    public string? Keywords { get; set; }

    public byte State { get; set; }

    public Guid UserId { get; set; }

    public virtual ICollection<BlogComment> BlogComments { get; } = new List<BlogComment>();

    public virtual BlogCategory Category { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
