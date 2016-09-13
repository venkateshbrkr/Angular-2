using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online.Business.Entities
{   
    public class ApplicationMenu
    {         
        public Guid MenuId { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public string Module { get; set; }
        public int MenuOrder { get; set; }
        public Boolean RequiresAuthenication { get; set; } 
        public List<ApplicationSubMenu> Menus { get; set; }
    }

    public class ApplicationSubMenu
    {
        public Guid MenuId { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public string Module { get; set; }
        public int MenuOrder { get; set; }
        public Boolean RequiresAuthenication { get; set; }
    }
}
