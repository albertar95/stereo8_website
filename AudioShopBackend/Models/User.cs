using System;
using System.Collections.Generic;

namespace AudioShopBackend.Models;

public partial class User
{
    public Guid NidUser { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool IsDisabled { get; set; }

    public bool IsAdmin { get; set; }

    public DateTime CreateDate { get; set; }

    public string? PersianCreateDate { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public string? PersianLastLoginDate { get; set; }

    public decimal? ZipCode { get; set; }

    public string? Address { get; set; }

    public string? Tel { get; set; }

    public virtual ICollection<BlogComment> BlogComments { get; } = new List<BlogComment>();

    public virtual ICollection<Blog> Blogs { get; } = new List<Blog>();

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Favorite> Favorites { get; } = new List<Favorite>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
