using System;
using System.Collections.Generic;

namespace AudioShopBackend.Models;

public partial class Setting
{
    public Guid NidSetting { get; set; }

    public string SettingAttribute { get; set; } = null!;

    public string SettingValue { get; set; } = null!;

    public byte State { get; set; }
}
