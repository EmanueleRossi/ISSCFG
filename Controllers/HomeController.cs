using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ISSCFG.Models;
using Microsoft.AspNetCore.Diagnostics;
using System;

namespace ISSCFG.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ErrorViewModel evm = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };

            IExceptionHandlerPathFeature feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (feature.Error != null)
            {
                evm.StackTrace = feature.Error.StackTrace;
            }

            return View(evm);
        }
    }
}
