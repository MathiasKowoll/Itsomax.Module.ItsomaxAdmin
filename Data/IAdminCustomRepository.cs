using System.Collections.Generic;
using Itsomax.Data.Infrastructure.Data;
using Itsomax.Module.Core.Models;

namespace Itsomax.Module.ItsomaxAdmin.Data
{
    public interface IAdminCustomRepository : IRepository<Entity>
    {
        IList<AppSetting> GetCommonSettings();
        IList<AppSetting> GetAllSettings();
        AppSetting GetSystemDefaultPage();
        AppSetting GetSystemConfigByName(string key);
    }
}