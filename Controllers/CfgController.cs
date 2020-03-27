using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ISSCFG.Models;
using ISSCFG.Models.Services;
using ISSCFG.Models.ViewModels;
using ISSCFG.Models.Services.Application;

namespace ISSCFG.Controllers
{
    public class CfgController : Controller
    {
        private readonly ILogger<HomeController> _logger;  
        private readonly ICfgService _cfgService;
        private readonly IConfigurator _configurator;

        public CfgController(ILogger<HomeController> logger, ICfgService cfgService, IConfigurator configurator)
        {
            _logger = logger;
            _cfgService = cfgService;
            _configurator = configurator;
        }
                
        public IActionResult ToStep01(Guid guid)
        {
            CfgViewModel viewModel = _cfgService.getCfg(guid);            
            return View("Step01", viewModel);
        }
        public IActionResult CompleteStep01(string step01, Guid guid)
        {
            _cfgService.setStep01(step01, guid);
            CfgViewModel viewModel = _cfgService.getCfg(guid);            
            _logger.LogDebug($"[CompleteStep01] Contacts: |{viewModel.ToString()}|");           
            return View("Step02", viewModel);
        }
        
        public IActionResult ToStep02(Guid guid)
        {
            CfgViewModel viewModel = _cfgService.getCfg(guid);      
            _logger.LogDebug($"[Step02] Contacts: |{viewModel.ToString()}|");                 
            return View("Step02", viewModel);
        }                
        public IActionResult CompleteStep02(string step02, Guid guid)
        {
            _cfgService.setStep02(step02, guid);
            CfgViewModel viewModel = _cfgService.getCfg(guid);            
            _logger.LogDebug($"[CompleteStep02] Contacts: |{viewModel.ToString()}|");           
            return View("Step03", viewModel);
        }        
        
        public IActionResult ToStep03(Guid guid)
        {
            CfgViewModel viewModel = _cfgService.getCfg(guid);
            _logger.LogDebug($"[ToStep03] Contacts: |{viewModel.ToString()}|");           
            return View("Step03", viewModel);
        }        
        public IActionResult CompleteStep03(string step03, Guid guid)
        {
            _cfgService.setStep03(step03, guid);
            CfgViewModel viewModel = _cfgService.getCfg(guid);            
            _logger.LogDebug($"[CompleteStep03] Contacts: |{viewModel.ToString()}|");           
            return View("Contacts", viewModel);            
        }           
        
        public IActionResult CompleteContacts(string name, string company, string mail, string phone, Guid guid)
        {
            guid = _cfgService.setContacts(name, company, mail, phone, guid);
            CfgViewModel viewModel = _cfgService.getCfg(guid); 
            _logger.LogDebug($"[CompleteContacts] Contacts: |{viewModel.ToString()}|");                 
            List<Product> configuration = _configurator.ComputeConfiguration(viewModel);                    
            _logger.LogDebug($"[Configuration]: |{string.Join("\n", configuration.Select(p => p.ToString()))}|");          
            return View("Step01", viewModel);
        } 
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
