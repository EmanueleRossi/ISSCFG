using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ISSCFG.Models;
using System.Net;
using ISSCFG.Models.Services;
using ISSCFG.Models.ViewModels;

namespace ISSCFG.Controllers
{
    public class CfgController : Controller
    {
        private readonly ILogger<HomeController> _logger;  
        private readonly ICfgService _cfgService;

        public CfgController(ILogger<HomeController> logger, ICfgService cfgService)
        {
            _logger = logger;
            _cfgService = cfgService;
        }

        public IActionResult Index()
        {
            return View("Step01");
        }

        public IActionResult Step01(string step01, Guid guid)
        {
            guid = _cfgService.setStep01(step01, guid);
            CfgViewModel viewModel = _cfgService.getCfg(guid);            
            return View("Step02", viewModel);
        }        
        public IActionResult Step02(string step02, Guid guid)
        {
            guid = _cfgService.setStep02(step02, guid);
            CfgViewModel viewModel = _cfgService.getCfg(guid);            
            return View("Step03", viewModel);
        }           

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
