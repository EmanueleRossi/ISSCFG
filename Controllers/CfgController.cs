using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ISSCFG.Models;
using ISSCFG.Models.Services;
using ISSCFG.Models.ViewModels;
using ISSCFG.Models.Services.Application;
using System.Threading.Tasks;

namespace ISSCFG.Controllers
{
    public class CfgController : Controller
    {
        private readonly ILogger<HomeController> Logger;  
        private readonly IUserInputService UserInputService;
        private readonly IConfigurator Configurator;

        public CfgController(ILogger<HomeController> logger, IUserInputService userInputService, IConfigurator configurator)
        {
            Logger = logger;
            UserInputService = userInputService;
            Configurator = configurator;
        }
                
        public IActionResult ToStep01(int id)
        {   
            Logger.LogDebug($"Received [id]=|{id}|");                 
            if (id == 0) id = UserInputService.newUserInput();
            Logger.LogDebug($"ToStep01 [id]=|{id}|");                 
            return View("Step01", UserInputService.GetUserInput(id));
        }
        public IActionResult CompleteStep01(string step01, int id)
        {
            UserInputService.setStep01(step01, id);
            Logger.LogDebug($"[id=|{id}|] -> step01=|{step01}|");           
            return View("Step02", UserInputService.GetUserInput(id));
        }
        
        public IActionResult ToStep02(int id)
        {
            Logger.LogDebug($"ToStep02 [id]=|{id}|");                 
            return View("Step02", UserInputService.GetUserInput(id));
        }                
        public IActionResult CompleteStep02(string step02, int id)
        {
            UserInputService.setStep02(step02, id);
            Logger.LogDebug($"[id=|{id}|] -> step02=|{step02}|");           
            return View("Step03", UserInputService.GetUserInput(id));
        }        
        
        public IActionResult ToStep03(int id)
        {
            Logger.LogDebug($"ToStep03 [id]=|{id}|");                 
            return View("Step03", UserInputService.GetUserInput(id));
        }        
        public IActionResult CompleteStep03(string step03, int id)
        {
            UserInputService.setStep03(step03, id);
            Logger.LogDebug($"[id=|{id}|] -> step03=|{step03}|");           
            return View("Contacts", UserInputService.GetUserInput(id));
        }           
        
        public async Task<IActionResult> CompleteContacts(string name, string company, string mail, string phone, int id)
        {
            UserInputService.setContacts(name, company, mail, phone, id);
            UserInputViewModel viewModel = UserInputService.GetUserInput(id); 
            Logger.LogDebug($"[CompleteContacts] viewModel=|{viewModel.ToString()}|");                 
            List<ItemViewModel> configuration = await Configurator.ComputeConfiguration(viewModel);                    
            return View("Basket", new BasketViewModel(configuration));
        } 
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
