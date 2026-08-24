using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Model
{
    public class VolunteerModel
    {
        public int VolunteerId { get; set; }

        public string FullName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateOnly JoinDate { get; set; }
    }
}
