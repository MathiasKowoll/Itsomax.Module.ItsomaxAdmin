using System.Collections.Generic;
using Itsomax.Data.Infrastructure.Data;
using Itsomax.Module.Core.Models;
using Itsomax.Module.Core.ViewModels;

namespace Itsomax.Module.ItsomaxAdmin.Data
{
    public interface IAdminCustomRepository : IRepository<Entity>
    {
        IList<AppSettingModels> GetCommonSettings();
        IList<AppSettingModels> GetAllSettings();
        AppSetting GetSystemDefaultPage();
        AppSetting GetSystemConfigByName(string key);
    }
}