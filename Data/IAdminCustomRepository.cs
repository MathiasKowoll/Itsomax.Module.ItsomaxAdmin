using System.Collections.Generic;
using Itsomax.Data.Infrastructure.Data;
using Itsomax.Module.Core.Models;
using Itsomax.Module.Core.ViewModels;
using Itsomax.Module.ItsomaxAdmin.ViewModels;

namespace Itsomax.Module.ItsomaxAdmin.Data
{
    public interface IAdminCustomRepository : IRepository<Entity>
    {
        IList<AppSettingModels> GetCommonSettings();
        IList<AppSettingModels> GetAllSettings();
        UserAppSettingViewModel GetSystemDefaultPage(long id);
        AppSetting GetSystemConfigByName(string key);
    }
}