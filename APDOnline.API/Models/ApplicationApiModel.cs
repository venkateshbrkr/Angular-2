using System.Collections.Generic;
using Online.Business.Entities;

namespace Online.API
{ 
    public class ApplicationApiModel : TransactionalInformation
    {
    
        public List<ApplicationMenu> MenuItems;

        public ApplicationApiModel()
        {           
            MenuItems = new List<ApplicationMenu>();        
        }

    }

}