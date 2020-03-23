using ISSCFG.Models.Services;
using ISSCFG.Models.ViewModels;

namespace ISSCFG
{
    public class CfgService : ICfgService
    {
        private CfgViewModel viewModel;
        public CfgService() 
        {
            viewModel  = new CfgViewModel();
        }

        public CfgViewModel getCfg()
        {
            return viewModel;
        }

        public void setStep01(string step01) 
        {
            viewModel.step01 = "PIPPO";
        }
    }
}