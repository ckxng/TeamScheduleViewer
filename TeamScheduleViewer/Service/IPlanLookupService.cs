using TeamScheduleViewer.Models;

namespace TeamScheduleViewer.Service
{
    public interface IPlanLookupService
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IPlan[] PlansInServiceType();
    }
}