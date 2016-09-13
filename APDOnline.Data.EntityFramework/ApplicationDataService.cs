using System;
using System.Collections.Generic;
using System.Linq;
using Online.Interfaces;
using Online.Business.Entities;
using System.Linq.Dynamic;

namespace Online.Data.EntityFramework
{
    public class ApplicationDataService : EntityFrameworkService, IApplicationDataService
    {
        private List<ApplicationMenu> ApplicationMenuInfo;
        public void InitializeApplication()
        {
            int menuItemsCount = 0;
            if (menuItemsCount > 0) return;        
        }

        /// <summary>
        /// Create Menu Item
        /// </summary>
        /// <param name="description"></param>
        /// <param name="route"></param>
        /// <param name="module"></param>
        /// <param name="requiresAuthenication"></param>
        /// <param name="menuOrder"></param>
        /// <returns></returns>
        private ApplicationMenu CreateMenuItem(string description, string route, string module, Boolean requiresAuthenication, int menuOrder, bool master)
        {
            
            ApplicationMenu menuItem = new ApplicationMenu();
            if (master)
            {
                menuItem.MenuId = Guid.NewGuid();
                menuItem.Route = route;
                menuItem.Description = description;
                menuItem.RequiresAuthenication = requiresAuthenication;
                menuItem.MenuOrder = menuOrder;
                menuItem.Module = module;
            }
            else
            {
                menuItem = (from item in ApplicationMenuInfo
                            where item.Module == module
                            select item).First();
                if (menuItem.Menus == null)
                {
                    menuItem.Menus = new List<ApplicationSubMenu>();
                    ApplicationSubMenu submenuItem = new ApplicationSubMenu();
                    submenuItem.MenuId = Guid.NewGuid();
                    submenuItem.Route = route;
                    submenuItem.Description = description;
                    submenuItem.RequiresAuthenication = requiresAuthenication;
                    submenuItem.MenuOrder = menuOrder;
                    submenuItem.Module = module;
                    menuItem.Menus.Add(submenuItem);
                }
                else
                {
                    ApplicationSubMenu submenuItem = new ApplicationSubMenu();
                    submenuItem.MenuId = Guid.NewGuid();
                    submenuItem.Route = route;
                    submenuItem.Description = description;
                    submenuItem.RequiresAuthenication = requiresAuthenication;
                    submenuItem.MenuOrder = menuOrder;
                    submenuItem.Module = module;
                    menuItem.Menus.Add(submenuItem);
                }
            }
            return menuItem;
        }
      
        /// <summary>
        /// Get Menu Items
        /// </summary>
        /// <param name="isAuthenicated"></param>
        /// <returns></returns>
        public List<ApplicationMenu> GetMenuItems(Int32 isAuthenicatedType)
        {
            ApplicationMenuInfo = new List<ApplicationMenu>();
            if (isAuthenicatedType == 1)
            {
                ApplicationMenu menuItem;

                menuItem = CreateMenuItem(" ", "#Main/DashBoard", "CRO", true, 1, true);
                ApplicationMenuInfo.Add(menuItem);               

                menuItem = CreateMenuItem(" ", "#Main/DashBoard", "MEMO", true, 2,true);
                ApplicationMenuInfo.Add(menuItem);

                menuItem = CreateMenuItem(" ", "#Main/DashBoard", "MISC", true, 3, true);
                ApplicationMenuInfo.Add(menuItem);

                menuItem = CreateMenuItem(" ", "#Main/DashBoard", "MOD", true, 4, true);
                ApplicationMenuInfo.Add(menuItem);

                menuItem = CreateMenuItem(" ", "#Main/DashBoard", "OOD", true, 5, true);
                ApplicationMenuInfo.Add(menuItem);

                menuItem = CreateMenuItem("Continuance", "#ADPForm/CreateForm", "MISC", true, 1, false);

                menuItem = CreateMenuItem("Order of Confinement", "#ADPForm/CreateForm", "MISC", true, 2, false);

                menuItem = CreateMenuItem("Order of Release", "#ADPForm/CreateForm", "MISC", true, 3, false);

                menuItem = CreateMenuItem("Sex Offender Annual Review", "#ADPForm/CreateForm", "MISC", true, 4, false);

                menuItem = CreateMenuItem("Attorney Notification", "#ADPForm/CreateForm", "MISC", true, 5, false);

                menuItem = CreateMenuItem("Original Criminal Restitution Order", "#ADPForm/CreateForm", "CRO", true, 1, false);

                menuItem = CreateMenuItem("Addendum Criminal Restitution Order", "#ADPForm/CreateForm", "CRO", true, 2, false);

                menuItem = CreateMenuItem("Memo to the Court", "#ADPForm/CreateForm", "MEMO", true, 1, false);

                menuItem = CreateMenuItem("Restitution Delinquency Memo", "#ADPForm/CreateForm", "MEMO", true, 2,false);

                menuItem = CreateMenuItem("Petition to Modify", "#ADPForm/CreateForm", "MOD", true, 1, false);

                menuItem = CreateMenuItem("Petition to Modify - IPS Level changes Only", "#ADPForm/CreateForm", "MOD", true, 2, false);

                menuItem = CreateMenuItem("Early Termination Order Of Discharge", "#ADPForm/CreateForm", "OOD", true, 1, false);

                menuItem = CreateMenuItem("Earned Time Credit Order Of Discharge", "#ADPForm/CreateForm", "OOD", true, 2, false);

                menuItem = CreateMenuItem("Expiration Of Probation Order Of Discharge", "#ADPForm/CreateForm", "OOD", true, 3, false);
            }
            var menuQuery = ApplicationMenuInfo.AsQueryable();          

            var menuItems = (from m in menuQuery.Where(m => m.RequiresAuthenication == true) select m).ToList();         
            return menuItems;
        }
    }
}
