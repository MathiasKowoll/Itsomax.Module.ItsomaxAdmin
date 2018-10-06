using Itsomax.Data.Infrastructure;
using Itsomax.Module.ItsomaxAdmin.Data;
using Itsomax.Module.ItsomaxAdmin.Interfaces;
using Itsomax.Module.ItsomaxAdmin.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Itsomax.Module.ItsomaxAdmin
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
			serviceCollection.AddScoped<IConfigureSystem, ConfigureSystem>();
            serviceCollection.AddScoped<IAdminCustomRepository, AdminCustomRepository>();
        }
    }
}