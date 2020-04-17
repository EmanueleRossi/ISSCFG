using System.Collections.Generic;
using System.Threading.Tasks;
using ISSCFG.Models.ViewModels;

namespace ISSCFG.Models.Services.Application
{
    public interface IConfigurator
    {
        Task<BasketViewModel> ComputeConfiguration(UserInputViewModel userInput, int page);
    }
}
