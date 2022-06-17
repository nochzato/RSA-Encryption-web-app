using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesRSA.Pages
{
    public class RSAModel : PageModel
    {
        private readonly ILogger<RSAModel> _logger;

        public RSAModel(ILogger<RSAModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
