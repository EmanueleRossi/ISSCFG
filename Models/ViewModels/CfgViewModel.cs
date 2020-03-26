using System;
using System.Collections.Generic;

namespace ISSCFG.Models.ViewModels
{
    public enum Step01 {
        ComputerExtension,
        StandaloneMeetingRoom
    }

    public enum Step02 {
        Display,
        DigitalBlackBoard
    }

    public enum Step03 {
        Medium,
        Large
    }

    public class CfgViewModel
    {
        public Guid guid { get; set; }
        public string step01 { get; set; }
        public string step02 { get; set; }
        public string step03 { get; set; }  
        public string name { get; set; }
        public string company { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public List<Product> products { get; set; }

        public CfgViewModel() 
        {
            products = new List<Product>();
        }
        
        public override string ToString()
        {
            return $@"CfgViewModel: 
                guid=|{guid}| 
                step01=|{step01}| 
                step02=|{step02}| 
                step03=|{step03}| 
                name=|{name} 
                company=|{company} 
                mail=|{mail}| 
                phone=|{phone}|
                products.Count = |{products.Count}|";
        }
    }
}