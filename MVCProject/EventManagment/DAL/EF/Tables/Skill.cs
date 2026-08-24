using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Skill
{
    public int SkillId { get; set; }

    public string SkillName { get; set; } = null!;

    public virtual VolunteerSkill? VolunteerSkill { get; set; }
}
