using System.Collections.Generic;

using Online.Business.Entities;

namespace Online.API
{
    public class AccountsApiModel : TransactionalInformation
    {
        public List<ApplicationMenu> MenuItems;
        public User User;
        public string AppURL;

        public AccountsApiModel()
        {
            User = new User();
            MenuItems = new List<ApplicationMenu>();
            AppURL = string.Empty;
        }
    }

    public class ApplicationDTO
    {
        public string URL { get; set; }      
    }

    public class UserDTO
    {     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }

    public class LoginUserDTO
    {        
        public string UserName { get; set; }
        public string Password { get; set; }      
    }

}