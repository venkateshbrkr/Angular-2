using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online.Interfaces;
using Online.Business.Entities;

namespace Online.Data.EntityFramework
{
   
    /// <summary>
    /// User Data Service
    /// </summary>
    public class UserDataService : EntityFrameworkService, IUserDataService
    {        
        public void CreateUser(Business.Entities.User user)
        {
            User Userinfo = new EntityFramework.User();
            DateTime now = DateTime.Now;
            Userinfo.DateCreated = now;
            Userinfo.DateUpdated = now;
            dbConnection.Users.Add(Userinfo);
        }

        public void UpdateUser(Business.Entities.User user)
        {
            user.DateUpdated = DateTime.Now;
        }

        Business.Entities.User IUserDataService.GetUser(string emailAddress)
        {
            Business.Entities.User usr = new Business.Entities.User();        
            User user = dbConnection.Users.Where(u => u.EmailAddress == emailAddress).FirstOrDefault();
            if (user != null)
            {
                usr.AddressLine1 = user.AddressLine1;
                usr.AddressLine2 = user.AddressLine2;
                usr.City = user.City;
                usr.DateCreated = user.DateCreated;
                usr.DateUpdated = user.DateUpdated;
                usr.EmailAddress = user.EmailAddress;
                usr.FirstName = user.FirstName;
                usr.LastName = user.LastName;
                usr.Password = user.Password;
                usr.State = user.State;
                usr.UserID = user.UserID;
                usr.ZipCode = user.ZipCode;
            }       
            return usr;
        }

        Business.Entities.User IUserDataService.GetUser(int userID)
        {
            Business.Entities.User usr = new Business.Entities.User();
            User user = dbConnection.Users.Where(u => u.UserID == userID).FirstOrDefault();
            if (user != null)
            {
                usr.AddressLine1 = user.AddressLine1;
                usr.AddressLine2 = user.AddressLine2;
                usr.City = user.City;
                usr.DateCreated = user.DateCreated;
                usr.DateUpdated = user.DateUpdated;
                usr.EmailAddress = user.EmailAddress;
                usr.FirstName = user.FirstName;
                usr.LastName = user.LastName;
                usr.Password = user.Password;
                usr.State = user.State;
                usr.UserID = user.UserID;
                usr.ZipCode = user.ZipCode;
            }
            return usr;
        }
    }
}
