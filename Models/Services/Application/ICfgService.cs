using ISSCFG.Models.ViewModels;

namespace ISSCFG.Models.Services
{
    public interface ICfgService
    {   
        void setStep01(string step01);
        CfgViewModel getCfg();
    }
}
