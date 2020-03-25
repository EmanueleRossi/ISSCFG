using System;
using ISSCFG.Models.ViewModels;

namespace ISSCFG.Models.Services
{
    public interface ICfgService
    {   
        Guid setStep01(string step01, Guid guid);
        Guid setStep02(string step02, Guid guid);    
        Guid setStep03(string step03, Guid guid);        
        CfgViewModel getCfg(Guid guid);
        Guid setContacts(string name, string company, string mail, string phone, Guid guid);
    }
}
