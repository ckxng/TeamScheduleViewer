using System;

namespace TeamScheduleViewer.Models
{
    public interface ITeamMember
    {
        /// <summary>
        /// The Position held by this Team Member
        /// </summary>
        String Position { get; }

        /// <summary>
        /// The Name of this Team Member
        /// </summary>
        String Name { get; }
    }
}