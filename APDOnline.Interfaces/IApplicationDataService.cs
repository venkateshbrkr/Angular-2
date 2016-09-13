using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Online.Business.Entities;
using System.Threading.Tasks;

namespace Online.Interfaces
{
    public interface IApplicationDataService : IDataRepository, IDisposable
    {
        void InitializeApplication();
        List<ApplicationMenu> GetMenuItems(Int32 isAuthenicated);
    }
}
