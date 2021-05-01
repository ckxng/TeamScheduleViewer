using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamScheduleViewer.Models
{
    public class TeamMember : ITeamMember
    {
        public String Position { get; private set; }

        public String Name { get; private set; }

        public TeamMember(String Name, String Position)
        {
            this.Name = Name;
            this.Position = Position;
        }
    }
}
