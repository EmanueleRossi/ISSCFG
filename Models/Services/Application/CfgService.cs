using System;
using System.Collections.Generic;
using ISSCFG.Models.Services;
using ISSCFG.Models.ViewModels;

namespace ISSCFG
{
    public class CfgService : ICfgService
    {
        private List<CfgViewModel> viewModelList;
        public CfgService() 
        {
            viewModelList = new List<CfgViewModel>();
        }

        public CfgViewModel getCfg(Guid guid)
        {
            if (viewModelList.FindIndex(vm => vm.guid == guid) == 0)
            {
                return viewModelList.FindLast(vm => vm.guid == guid);
            }
            else
            {
                CfgViewModel vm = new CfgViewModel();
                vm.guid = Guid.NewGuid();
                viewModelList.Add(vm);
                return vm;
            }
        }
        public Guid setStep01(string step01, Guid guid) 
        {
            var vm = this.getCfg(guid);
            vm.step01 = step01;
            return vm.guid;
        }
        public Guid setStep02(string step02, Guid guid) 
        {
            var vm = this.getCfg(guid);
            vm.step02 = step02;
            return vm.guid;
        }        
        public Guid setStep03(string step03, Guid guid) 
        {
            var vm = this.getCfg(guid);
            vm.step03 = step03;
            return vm.guid;            
        }  
        public Guid setContacts(string name, string company, string mail, string phone, Guid guid) 
        {
            var vm = this.getCfg(guid);
            vm.name = name;
            vm.company = company;
            vm.mail = mail;
            vm.phone = phone; 
            return vm.guid;              
        } 
    }
}