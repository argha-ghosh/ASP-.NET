using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Organization
{
    public int OrgId { get; set; }

    public string OrgName { get; set; } = null!;

    public string ContactEmail { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
