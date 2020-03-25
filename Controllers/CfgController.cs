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
        public IActionResult ToStep01(Guid guid)
        {
            CfgViewModel viewModel = _cfgService.getCfg(guid);            
            return View("Step01", viewModel);
        }
        public IActionResult CompleteStep01(string step01, Guid guid)
        {
            guid = _cfgService.setStep01(step01, guid);
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
            guid = _cfgService.setStep02(step02, guid);
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
            guid = _cfgService.setStep03(step03, guid);
            CfgViewModel viewModel = _cfgService.getCfg(guid);            
            _logger.LogDebug($"[CompleteStep03] Contacts: |{viewModel.ToString()}|");           
            return View("Contacts", viewModel);            
        }           
        public IActionResult CompleteContacts(string name, string company, string mail, string phone, Guid guid)
        {
            guid = _cfgService.setContacts(name, company, mail, phone, guid);
            CfgViewModel viewModel = _cfgService.getCfg(guid); 
            _logger.LogDebug($"[CompleteContacts] Contacts: |{viewModel.ToString()}|");                 
            return RedirectToAction("Index");
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
