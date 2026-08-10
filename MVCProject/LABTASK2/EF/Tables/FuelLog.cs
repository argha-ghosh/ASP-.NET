using System;
using System.Collections.Generic;

namespace LABTASK2.EF.Tables;

public partial class FuelLog
{
    public int LogId { get; set; }

    public string BusCode { get; set; } = null!;

    public string Route { get; set; } = null!;

    public string LittersFilled { get; set; } = null!;

    public decimal CostPerLiter { get; set; }

    public TimeOnly FilledAt { get; set; }
}
