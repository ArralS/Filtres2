using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filtres.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet = true)]
        public int testVriable { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public override async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, 
        PageHandlerExecutionDelegate next) 
        {
            ViewData["FilterMessage"] = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(); 
            var resultContext = await next();
        }

    }
}
