using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace TeamScheduleViewer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public readonly Models.IPlan[] Plans;

        public string Error = null;

        public IndexModel(ILogger<IndexModel> logger, Service.IPlanLookupService lookup)
        {
            _logger = logger;
            try
            {
                Plans = lookup.PlansInServiceType();
            }
            catch (Exception e)
            {
                Error = e.Message;
            }
        }

        public void OnGet()
        {
        }
    }
}