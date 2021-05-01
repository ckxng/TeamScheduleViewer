using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TeamScheduleViewer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public readonly Models.IPlan[] Plans;

        public IndexModel(ILogger<IndexModel> logger, Service.IPlanLookupService lookup)
        {
            _logger = logger;
            Plans = lookup.PlansInServiceType();
        }

        public void OnGet()
        {
        }
    }
}