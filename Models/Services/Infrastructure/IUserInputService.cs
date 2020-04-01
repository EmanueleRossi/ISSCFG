using ISSCFG.Models.ViewModels;

namespace ISSCFG.Models.Services
{
    public interface IUserInputService
    {   
        int newUserInput();
        void setStep01(string step01, int id);
        void setStep02(string step02, int id);    
        void setStep03(string step03, int id);  
        void setContacts(string name, string company, string mail, string phone, int id);              
        UserInputViewModel GetUserInput(int id);
    }
}