using Itsomax.Module.Core.Data;
using Itsomax.Module.Core.Models;

namespace Itsomax.Module.ItsomaxAdmin.Data
{
    public class AdminCustomRepository : Repository<Entity>,IAdminCustomRepository
    {
        public AdminCustomRepository(ItsomaxDbContext context) : base(context){}
        
    }
}