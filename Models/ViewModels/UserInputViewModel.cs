using System;
using System.ComponentModel.DataAnnotations;
using ISSCFG.Models.Entities;

namespace ISSCFG.Models.ViewModels
{
    public class MeetingRoomUserInputViewModel
    {
        public int Id { get; set; }
        public string Step01 { get; set; }
        public string Step02 { get; set; }
        public string Step03 { get; set; }  
        public string Name { get; set; }
        public string Company { get; set; }
        [Required]
        public string Mail { get; set; }
        public string Phone { get; set; }

        public static MeetingRoomUserInputViewModel FromEntity(UserInput input) => new MeetingRoomUserInputViewModel
        {
            Id = input.Id,
            Step01 = input.Step01,
            Step02 = input.Step02,
            Step03 = input.Step03,
            Name = input.Name,
            Company = input.Company,
            Mail = input.Mail,
            Phone = input.Phone
        };        
        
        public override string ToString()
        {
            return $"Id=|{Id}|, Step01=|{Step01}|, Step02=|{Step02}|, step03=|{Step03}|, Name=|{Name}|, Company=|{Company}|, Mail=|{Mail}|, Phone=|{Phone}|";
        }
    }
}