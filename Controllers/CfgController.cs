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
using ISSCFG.Models.Services.Infrastructure;

namespace ISSCFG.Controllers
{
    public class CfgController : Controller
    {
        private readonly ILogger<HomeController> _logger;  
        private readonly ICfgService _cfgService;
        private readonly IProductService _productService;
        public CfgController(ILogger<HomeController> logger, ICfgService cfgService, IProductService productService)
        {
            _logger = logger;
            _cfgService = cfgService;
            _productService = productService;
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
            _logger.LogDebug($"[Configuration]: |{this.ComputeConfiguration(guid)}|");                 
            return RedirectToAction("Index");
        } 
        public string ComputeConfiguration(Guid guid) 
        {
            string response = "";

            var cfg = _cfgService.getCfg(guid);
            if (cfg.step01.Equals(Step01.ComputerExtension.ToString()))
            {   
                response += "[BASE] - ";
            } 
            else if (cfg.step01.Equals(Step01.StandaloneMeetingRoom.ToString()))
            {
                response += "[PLUS] - ";
            } 
            else 
            {
                response += "Not Implemented!";                
            }

            if (cfg.step02.Equals(Step02.Display.ToString()))
            {
                response += $"VIDEO: |{_productService.GetProduct("QM55R").description} | -";
            } 
            else if (cfg.step02.Equals(Step02.DigitalBlackBoard.ToString()))
            {
                response += $"VIDEO: FLIP2! - ";
            }
            else
            {
                response += "Not Implemented! - ";
            }
            
            if (cfg.step03.Equals(Step03.Large.ToString()))
            {
                response += $"WITH OPTION! - ";
            }
            else
            {
                response += $"WITHOUT OPTION! - ";
            }            

            return response;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
