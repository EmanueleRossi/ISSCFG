using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ISSCFG.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace ISSCFG.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 600, Location = ResponseCacheLocation.Any)]
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
