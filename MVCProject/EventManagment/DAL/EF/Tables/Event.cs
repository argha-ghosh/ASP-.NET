using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public DateOnly EventDate { get; set; }

    public int OrgId { get; set; }

    public virtual Organization Org { get; set; } = null!;
}
