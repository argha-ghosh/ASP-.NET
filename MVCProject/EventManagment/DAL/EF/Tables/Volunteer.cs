using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Volunteer
{
    public int VolunteerId { get; set; }

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateOnly JoinDate { get; set; }

    public virtual VolunteerSkill? VolunteerSkill { get; set; }
}
