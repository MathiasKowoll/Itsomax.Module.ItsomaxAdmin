using System.Collections.Generic;
using System.Linq;
using Itsomax.Module.Core.Data;
using Itsomax.Module.Core.Models;

namespace Itsomax.Module.ItsomaxAdmin.Data
{
    public class AdminCustomRepository : Repository<Entity>,IAdminCustomRepository
    {
        public AdminCustomRepository(ItsomaxDbContext context) : base(context){}

        public IList<AppSetting> GetCommonSettings()
        {
            return Context.Set<AppSetting>().Where(x => !x.Key.Contains("System")).ToList();
        }

        public IList<AppSetting> GetAllSettings()
        {
            return Context.Set<AppSetting>().ToList();
        }
    }
}