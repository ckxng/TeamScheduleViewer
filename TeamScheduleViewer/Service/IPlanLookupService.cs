using TeamScheduleViewer.Models;

namespace TeamScheduleViewer.Service
{
    public interface IPlanLookupService
    {
        /// <summary>
        /// Connects to the PCO API to find all plans within the gloablly configured service type.
        /// For each plan, the a secondary API call is made to look up the schedule team members 
        /// for that date.
        /// 
        /// If a fatal error occurs which must be reported to the user, throws an Exception with
        /// the error message in e.Message
        /// </summary>
        /// <returns>an array of plans, populated with team members</returns>
        IPlan[] PlansInServiceType();
    }
}