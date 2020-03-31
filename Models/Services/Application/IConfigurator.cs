using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ISSCFG.Models.ViewModels;

namespace ISSCFG.Models.Services.Application
{
    public interface IConfigurator
    {
        Task<List<ItemViewModel>> ComputeConfiguration(UserInputViewModel userInput);
    }
}
