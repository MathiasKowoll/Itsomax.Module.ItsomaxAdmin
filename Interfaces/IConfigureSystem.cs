using System.Collections.Generic;
using System.Threading.Tasks;
using Itsomax.Module.Core.Extensions;
using Itsomax.Module.Core.Models;

namespace Itsomax.Module.ItsomaxAdmin.Interfaces
{
    public interface IConfigureSystem
    {
        Task<SystemSucceededTask> SaveCommonConfiguration(string[] systemKeys, string[] systemValues,string userName);
        IList<AppSetting> GetSystemSettings(bool includeImages);
    }
}
