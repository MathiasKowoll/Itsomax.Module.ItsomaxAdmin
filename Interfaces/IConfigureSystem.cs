using System.Collections.Generic;
using System.Threading.Tasks;
using Itsomax.Module.Core.Extensions;
using Itsomax.Module.Core.Models;

namespace Itsomax.Module.ItsomaxAdmin.Interfaces
{
    public interface IConfigureSystem
    {
        Task<SystemSucceededTask> SaveConfiguration(AppSetting model);
        IList<AppSetting> GetSystemSettings(bool includeImages);
    }
}
