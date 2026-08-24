using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class VolunteerSkill
{
    public int Id { get; set; }

    public int VolunteerId { get; set; }

    public int SkillId { get; set; }

    public int VolunteerAge { get; set; }

    public string VolunteerEmail { get; set; } = null!;

    public virtual Volunteer Id1 { get; set; } = null!;

    public virtual Skill IdNavigation { get; set; } = null!;
}
