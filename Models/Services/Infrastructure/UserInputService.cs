using System.Linq;
using ISSCFG.Models.Services;
using ISSCFG.Models.Services.Infrastructure;
using ISSCFG.Models.ViewModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ISSCFG.Models.Entities;
using System.Net;
using System;

namespace ISSCFG
{
    public class UserInputService : IUserInputService
    {
        private readonly AppDbContext DbContext;

        public UserInputService(AppDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public int newUserInput() 
        {
            UserInput newUserInput = new UserInput();
            newUserInput.InsertDate = DateTime.UtcNow;
            EntityEntry<UserInput> added = DbContext.UserInputs.Add(newUserInput);
            DbContext.SaveChanges();
            return added.Entity.Id;
        }      

        public void setRemoteIpAddress(IPAddress remoteIpAddress, int id)
        {
            UserInput found = DbContext.UserInputs.Single(input => input.Id == id);            
            found.RemoteIpAddress = remoteIpAddress.ToString();
            DbContext.SaveChanges();
        }

        public void setStep01(string step01, int id) 
        {                    
            UserInput found = DbContext.UserInputs.Single(input => input.Id == id);            
            found.Step01 = step01;
            DbContext.SaveChanges();
        }

        public void setStep02(string step02, int id) 
        {
            UserInput found = DbContext.UserInputs.Single(input => input.Id == id);            
            found.Step02 = step02;
            DbContext.SaveChanges();
        }        

        public void setStep03(string step03, int id) 
        {
            UserInput found = DbContext.UserInputs.Single(input => input.Id == id);            
            found.Step03 = step03;
            DbContext.SaveChanges();               
        }  

        public void setContacts(string name, string company, string mail, string phone, int id) 
        {
            UserInput found = DbContext.UserInputs.Single(input => input.Id == id);
            found.Name = name;
            found.Company = company;
            found.Mail = mail;
            found.Phone = phone;
            DbContext.SaveChanges();
        } 
        
        public UserInputViewModel GetUserInput(int id)
        {
            IQueryable<UserInputViewModel> queryLinq = DbContext.UserInputs
                .Where(input => input.Id == id)                
                .Select(input => UserInputViewModel.FromEntity(input)); 
            
            return queryLinq.Single();
        }
    }
}