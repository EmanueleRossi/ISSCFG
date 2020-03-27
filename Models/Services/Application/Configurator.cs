using System;
using System.Collections.Generic;
using ISSCFG.Models.Services.Infrastructure;
using ISSCFG.Models.ViewModels;
using Microsoft.Extensions.Logging;

namespace ISSCFG.Models.Services.Application
{
    public class Configurator : IConfigurator
    {
        private readonly ILogger<Configurator> _logger; 
        private readonly IProductService _productService;        

        public Configurator(ILogger<Configurator> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        
        public List<Product> ComputeConfiguration(CfgViewModel userInput) 
        {
            List<Product> basket = new List<Product>();
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
                            basket.Add(_productService.GetProduct("STUDIO"));
                            break;
                        case Step01.StandaloneMeetingRoom:
                            basket.Add(_productService.GetProduct("STUDIO-X30"));
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
                            basket.Add(_productService.GetProduct("QM55R"));
                            break;
                        case Step02.DigitalBlackBoard:
                            basket.Add(_productService.GetProduct("WM65R"));
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
                            basket.Add(_productService.GetProduct("VCEM"));
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