using System;
using System.Collections.Generic;

namespace ISSCFG.Models.ViewModels
{
    public class UserInputViewModel
    {
        public Guid guid { get; set; }
        public string step01 { get; set; }
        public string step02 { get; set; }
        public string step03 { get; set; }  
        public string name { get; set; }
        public string company { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        
        public override string ToString()
        {
            return $"guid=|{guid}|, step01=|{step01}|, step02=|{step02}|, step03=|{step03}|, name=|{name}, company=|{company}, mail=|{mail}|, phone=|{phone}|";
        }
    }
}