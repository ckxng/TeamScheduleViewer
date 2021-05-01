using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamScheduleViewer.Models
{
    public class Plan : IPlan
    {
        public DateTime Date { get; private set; }

        public List<ITeamMember> TeamMembers { get; private set; } = new List<ITeamMember>();

        public Plan(DateTime Date)
        {
            this.Date = Date;
        }
    }
}
