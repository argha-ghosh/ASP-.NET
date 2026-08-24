using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Model
{
    public class EventModel
    {
        public int EventId { get; set; }

        public string EventName { get; set; } = null!;

        public DateOnly EventDate { get; set; }

        public int OrgId { get; set; }
    }
}
