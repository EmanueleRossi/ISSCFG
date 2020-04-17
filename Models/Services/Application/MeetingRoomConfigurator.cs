using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISSCFG.Models.Enums;
using ISSCFG.Models.Services.Infrastructure;
using ISSCFG.Models.ViewModels;
using Microsoft.Extensions.Configuration;

namespace ISSCFG.Models.Services.Application
{
    public class MeetingRoomConfigurator : IConfigurator
    {
        private readonly IUserInputService UserInputService;          
        private readonly IItemService ItemService;    
        private readonly int PerPageLimit;    

        public MeetingRoomConfigurator(IConfiguration configuration, IUserInputService userInputService, IItemServiceMemoryCached itemService)
        {
            UserInputService = userInputService;
            ItemService = itemService;
            PerPageLimit = configuration.GetSection("UI").GetValue<int>("PerPageLimit", 5);
        }
      
        public async Task<BasketViewModel> ComputeConfiguration(UserInputViewModel userInput, int page) 
        {
            List<ItemViewModel> basket = new List<ItemViewModel>();
            if (userInput == null || userInput.Id == 0) throw new ArgumentException($"Request for configuration with null input parameters... why?");
            
            if (Enum.TryParse(userInput.Step01, out Step01 step01userInput)) 
            {
                switch (step01userInput)
                {
                    case Step01.ComputerExtension:
                        basket.Add(await ItemService.GetItemAsync("STUDIO"));
                        break;
                    case Step01.StandaloneMeetingRoom:
                        basket.Add(await ItemService.GetItemAsync("STUDIO-X30"));
                        basket.Add(await ItemService.GetItemAsync("TC8"));
                        basket.Add(await ItemService.GetItemAsync("MS-TRL"));                        
                        break; 
                    default:
                        throw new NotImplementedException($"User Input=|{step01userInput}| in Step01 enum, but not managed in compute method!"); 
                }
            }
            else
            {
                throw new NotImplementedException($"User Input=|{userInput.Step01}| not managed in Step01 enum!"); 
            }
            if (Enum.TryParse(userInput.Step02, out Step02 step02userInput)) 
            {
                switch (step02userInput)
                {
                    case Step02.Display:
                        basket.Add(await ItemService.GetItemAsync("QM55R"));
                        break;
                    case Step02.DigitalBlackBoard:
                        basket.Add(await ItemService.GetItemAsync("WM65R"));
                        break; 
                    default:
                        throw new NotImplementedException($"User Input=|{step02userInput}| in Step02 enum, but not managed in compute method!"); 
                }
            }
            else
            {
                throw new NotImplementedException($"User Input=|{userInput.Step02}| not managed in Step02 enum!"); 
            }
            if (Enum.TryParse(userInput.Step03, out Step03 step03userInput)) 
            {
                switch (step03userInput)
                {
                    case Step03.Large:
                        basket.Add(await ItemService.GetItemAsync("VCEM"));
                        break;
                    case Step03.Medium:
                        break; 
                    default:
                        throw new NotImplementedException($"User Input=|{step03userInput}| in Step03 enum, but not managed in compute method!"); 
                }
            }
            else
            {
                throw new NotImplementedException($"User Input=|{userInput.Step03}| not managed in Step03 enum!"); 
            }               

            if (basket.Count != 0) 
            {
                basket.Add(await ItemService.GetItemAsync("ACS_PRE-CFG"));
                basket.Add(await ItemService.GetItemAsync("ACS_REMOTE-SUPPORT"));
            }

            BasketViewModel response = new BasketViewModel();
            response.UserInputId = userInput.Id;
            response.PerPageLimit = PerPageLimit;
            response.CurrentPage = page;
            response.TotalCount = basket.Count();

            page = Math.Max(1, page);
            int offset = (page - 1) * PerPageLimit;
            basket.Sort((i, j) => i.Code.CompareTo(j.Code));
            basket = basket.Skip(offset).Take(PerPageLimit).ToList();                
            
            response.setItems(basket);            

            return response;
        }
    }
}