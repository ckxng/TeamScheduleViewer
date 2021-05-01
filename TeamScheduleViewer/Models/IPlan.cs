using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamScheduleViewer.Models
{
    public interface IPlan
    {
        /// <summary>
        /// The date of the Plan
        /// </summary>
        DateTime Date { get; }

        /// <summary>
        /// An array of Team Members
        /// </summary>
        List<ITeamMember> TeamMembers { get; }
    }
}
