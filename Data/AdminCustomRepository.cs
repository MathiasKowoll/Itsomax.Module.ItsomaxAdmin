using System.Collections.Generic;
using System.Linq;
using Itsomax.Module.Core.Data;
using Itsomax.Module.Core.Extensions.CommonHelpers;
using Itsomax.Module.Core.Models;
using Itsomax.Module.Core.ViewModels;
using Itsomax.Module.ItsomaxAdmin.ViewModels;

namespace Itsomax.Module.ItsomaxAdmin.Data
{
    public class AdminCustomRepository : Repository<Entity>,IAdminCustomRepository
    {
        public AdminCustomRepository(ItsomaxDbContext context) : base(context){}

        public IList<AppSettingModels> GetCommonSettings()
        {
            return Context.Set<AppSetting>().Where(x => !x.Key.Contains("Logo") && !x.Key.Contains("Image"))
                .OrderBy(x => x.Key)
                .Select(x => new AppSettingModels()
                {
                    Key = x.Key,
                    Value = x.Value,
                    KeyName = StringHelperClass.CamelSplit(x.Key)
                }).ToList();
        }

        public IList<AppSettingModels> GetAllSettings()
        {
            return Context.Set<AppSetting>()
                .OrderBy(x => x.Key)
                .Select(x => new AppSettingModels
                {
                    Key = x.Key,
                    Value = x.Value,
                    KeyName = StringHelperClass.CamelSplit(x.Key)

                }).ToList();
        }

        public UserAppSettingViewModel GetSystemDefaultPage(long id)
        {

            var userSetting =
                from uas in Context.Set<UserAppSetting>()
                join usd in Context.Set<UserSettingDetail>() on uas.Id equals usd.UserAppSettingId into setDet
                from sd in setDet.DefaultIfEmpty()
                where sd.UserId == id && uas.Key == "SystemDefaultPage"
                select new UserAppSettingViewModel
                {
                    Key = uas.Key,
                    Value = sd.Value ?? ""
                };

            if (userSetting.Any()) return userSetting.FirstOrDefault();
            var model = new UserAppSettingViewModel
            {
                Key = "SystemDefaultPage",
                Value = ""
            };

            return model;

        }

        public AppSetting GetSystemConfigByName(string key)
        {
            return Context.Set<AppSetting>().FirstOrDefault(x => x.Key == key);
        }
    }
}