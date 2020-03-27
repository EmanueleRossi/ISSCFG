using System;
using System.Collections.Generic;
using ISSCFG.Models.ViewModels;

namespace ISSCFG.Models.Services.Application
{
    public interface IConfigurator
    {
        List<Product> ComputeConfiguration(CfgViewModel userInput);
    }
}
