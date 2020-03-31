using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ISSCFG.Models.Enums;
using ISSCFG.Models.Services.Infrastructure;
using ISSCFG.Models.ViewModels;
using Microsoft.Extensions.Logging;

namespace ISSCFG.Models.Services.Application
{
    public class Configurator : IConfigurator
    {
        private readonly ILogger<Configurator> _logger; 
        private readonly IItemService _ItemService;        

        public Configurator(ILogger<Configurator> logger, IItemService ItemService)
        {
            _logger = logger;
            _ItemService = ItemService;
        }
        
        public async Task<List<ItemViewModel>> ComputeConfiguration(UserInputViewModel userInput) 
        {
            List<ItemViewModel> basket = new List<ItemViewModel>();
            if (userInput == null || userInput.guid == null)
            {
                _logger.LogTrace($"Request for configuration with null input parameters... why?");
            }
            else
            {       
                if (Enum.TryParse(userInput.step01, out Step01 step01userInput)) 
                {
                    switch (step01userInput)
                    {
                        case Step01.ComputerExtension:
                            basket.Add(await _ItemService.GetItemAsync("STUDIO"));
                            break;
                        case Step01.StandaloneMeetingRoom:
                            basket.Add(await _ItemService.GetItemAsync("STUDIO-X30"));
                            break; 
                        default:
                            throw new NotImplementedException($"User Input in Step01 enum, but not managed in compute method!"); 
                    }
                }
                else
                {
                    throw new NotImplementedException($"User Input not managed in Step01 enum!"); 
                }
                if (Enum.TryParse(userInput.step02, out Step02 step02userInput)) 
                {
                    switch (step02userInput)
                    {
                        case Step02.Display:
                            basket.Add(await _ItemService.GetItemAsync("QM55R"));
                            break;
                        case Step02.DigitalBlackBoard:
                            basket.Add(await _ItemService.GetItemAsync("WM65R"));
                            break; 
                        default:
                            throw new NotImplementedException($"User Input in Step02 enum, but not managed in compute method!"); 
                    }
                }
                else
                {
                    throw new NotImplementedException($"User Input not managed in Step02 enum!"); 
                }
                if (Enum.TryParse(userInput.step03, out Step03 step03userInput)) 
                {
                    switch (step03userInput)
                    {
                        case Step03.Large:
                            basket.Add(await _ItemService.GetItemAsync("VCEM"));
                            break;
                        case Step03.Medium:
                            break; 
                        default:
                            throw new NotImplementedException($"User Input in Step03 enum, but not managed in compute method!"); 
                    }
                }
                else
                {
                    throw new NotImplementedException($"User Input not managed in Step03 enum!"); 
                }                
            }
            return basket;
        }
    }
}