using System.Net;
using ISSCFG.Models.ViewModels;

namespace ISSCFG.Models.Services
{
    public interface IUserInputService
    {   
        int newUserInput();
        void setRemoteIpAddress(IPAddress remoteIpAddress, int id);
        void setAcceptedLanguages(string acceptedLanguages, int id);
        void setStep01(string step01, int id);
        void setStep02(string step02, int id);    
        void setStep03(string step03, int id);  
        void setContacts(string name, string company, string mail, string phone, int id);              
        MeetingRoomUserInputViewModel GetUserInput(int id);
    }
}
