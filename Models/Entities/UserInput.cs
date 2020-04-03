using System;

namespace ISSCFG.Models.Entities
{
    public class UserInput
    {
        public int Id { get; set; }
        public string Step01 { get; set; }
        public string Step02 { get; set; }
        public string Step03 { get; set; }  
        public string Name { get; set; }
        public string Company { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Coordinates { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Organization { get; set; }

        public string RemoteIpAddress { get; set; }
        public DateTime InsertDate { get; set; }
        
        public override string ToString()
        {
            return $"Id=|{Id}|, Step01=|{Step01}|, Step02=|{Step02}|, step03=|{Step03}|, Name=|{Name}|, Company=|{Company}|, Mail=|{Mail}|, Phone=|{Phone}|";
        }
    }
}


