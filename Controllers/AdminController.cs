
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Itsomax.Module.ItsomaxAdmin.Controllers
{
    [Authorize(Policy = "ManageAuthentification")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LogOff()
        {
            return View();
        }
    }
}