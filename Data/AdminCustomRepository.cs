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
            return Context.Set<AppSetting>().Where(x => !x.Key.Contains("Logo") && !x.Key.Contains("Image"))
                .OrderBy(x => x.Key).ToList();
        }

        public IList<AppSetting> GetAllSettings()
        {
            return Context.Set<AppSetting>().OrderBy(x => x.Key).ToList();
        }

        public AppSetting GetSystemDefaultPage()
        {
            return Context.Set<AppSetting>().FirstOrDefault(x => x.Key == "SystemDefaultPage");
        }

        public AppSetting GetSystemConfigByName(string key)
        {
            return Context.Set<AppSetting>().FirstOrDefault(x => x.Key == key);
        }
    }
}