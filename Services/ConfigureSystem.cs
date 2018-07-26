using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Itsomax.Module.Core.Extensions;
using Itsomax.Module.Core.Interfaces;
using Itsomax.Module.Core.ViewModels;
using Itsomax.Module.ItsomaxAdmin.Data;
using Itsomax.Module.ItsomaxAdmin.Interfaces;


namespace Itsomax.Module.ItsomaxAdmin.Services
{
    public class ConfigureSystem : IConfigureSystem
    {
        private readonly IAdminCustomRepository _adminCustomRepository;
        private readonly ILogginToDatabase _logger;

        public ConfigureSystem(IAdminCustomRepository adminCustomRepository, ILogginToDatabase logger)
        {
            _adminCustomRepository = adminCustomRepository;
            _logger = logger;
        }

        public async Task<SystemSucceededTask> SaveCommonConfiguration(string[] systemKeys, string[] systemValues,string userName)
        {
            var count = systemKeys.Length;
            try
            {
                for (var i = 0; i < count; i++)
                {
                    var systemConfig = _adminCustomRepository.GetSystemConfigByName(systemKeys[i]);
                    if (systemConfig != null)
                    {
                        systemConfig.Value = systemValues[i];
                        await _adminCustomRepository.SaveChangesAsync();
                    }
                }
                _logger.InformationLog("Save Configuration Succesfull", "Save Configuration", string.Empty, userName);
                return SystemSucceededTask.Success("Configuration saved succesfully");
            }
            catch (Exception ex)
            {
                _logger.ErrorLog(ex.Message,"Save Consumption",ex.InnerException.Message,userName);
                return SystemSucceededTask.Failed("Configuration saved succesfully",ex.InnerException.Message,true,false);
            }
            
        }

        public IList<AppSettingModels> GetSystemSettings(bool includeImages)
        {
            return includeImages == true ? _adminCustomRepository.GetAllSettings() : _adminCustomRepository.GetCommonSettings();
        }

    }
}
