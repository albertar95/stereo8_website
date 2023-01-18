using System;
using System.Collections.Generic;

namespace AudioShopBackend.Models;

public partial class BlogCategory
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

    public virtual ICollection<Blog> Blogs { get; } = new List<Blog>();
}
