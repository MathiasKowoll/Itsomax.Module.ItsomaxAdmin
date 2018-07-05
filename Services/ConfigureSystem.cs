using System.Threading.Tasks;
using Itsomax.Module.Core.Extensions;
using Itsomax.Module.Core.Models;
using Itsomax.Module.ItsomaxAdmin.Data;
using Itsomax.Module.ItsomaxAdmin.Interfaces;

namespace Itsomax.Module.ItsomaxAdmin.Services
{
    public class ConfigureSystem : IConfigureSystem
    {
        private readonly IAdminCustomRepository _adminCustomRepository;

        public ConfigureSystem(IAdminCustomRepository adminCustomRepository)
        {
            _adminCustomRepository = adminCustomRepository;
        }

        public async Task<SystemSucceededTask> SaveConfiguration(AppSetting model)
        {
            var settings = _adminCustomRepository.GetCommonSettings();

            return SystemSucceededTask.Success("Configurations saved successfully");
        }
    }
}
