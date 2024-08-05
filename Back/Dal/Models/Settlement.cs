using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Settlement
{
    public int SettlementId { get; set; }

    public string SettlementName { get; set; } = null!;
}
