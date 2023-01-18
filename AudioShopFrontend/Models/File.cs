using System;
using System.Collections.Generic;

namespace AudioShopFrontend.Models;

public partial class File
{
    public Guid NidFile { get; set; }

    public string FileExtension { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public Guid RelateId { get; set; }

    public byte RelateType { get; set; }

    public DateTime CreateDate { get; set; }

    public string? PersianCreateDate { get; set; }

    public int? FileSize { get; set; }

    public string FileUrl { get; set; } = null!;

    public string? Description { get; set; }

    public byte Priority { get; set; }
}
