using System;
using System.Collections.Generic;
using ISSCFG.Models.Services;
using ISSCFG.Models.ViewModels;

namespace ISSCFG
{
    public class CfgService : ICfgService
    {
        private List<UserInputViewModel> viewModelList;
        public CfgService() 
        {
            viewModelList = new List<UserInputViewModel>();
        }
        public UserInputViewModel getCfg(Guid guid)
        {
            if (viewModelList.FindIndex(vm => vm.guid == guid) == 0)
            {
                return viewModelList.FindLast(vm => vm.guid == guid);
            }
            else
            {
                UserInputViewModel vm = new UserInputViewModel();
                vm.guid = Guid.NewGuid();
                viewModelList.Add(vm);
                return vm;
            }
        }
        public Guid setStep01(string step01, Guid guid) 
        {                    
            this.getCfg(guid).step01 = step01;
            return guid;
        }
        public Guid setStep02(string step02, Guid guid) 
        {
            this.getCfg(guid).step02 = step02;
            return guid;
        }        
        public Guid setStep03(string step03, Guid guid) 
        {
            this.getCfg(guid).step03 = step03;
            return guid;            
        }  
        public Guid setContacts(string name, string company, string mail, string phone, Guid guid) 
        {
            this.getCfg(guid).name = name;
            this.getCfg(guid).company = company;
            this.getCfg(guid).mail = mail;
            this.getCfg(guid).phone = phone;
            return guid;              
        } 
    }
}