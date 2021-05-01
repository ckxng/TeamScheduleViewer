using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
