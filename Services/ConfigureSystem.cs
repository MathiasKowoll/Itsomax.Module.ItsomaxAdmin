using Itsomax.Module.Core.Data;
using Itsomax.Module.ItsomaxAdmin.Interfaces;

namespace Itsomax.Module.ItsomaxAdmin.Services
{
    public class ConfigureSystem : IConfigureSystem
    {
        private readonly ItsomaxDbContext _context;

        public ConfigureSystem(ItsomaxDbContext context)
        {
            _context = context;
        }
        
        
    }
}
