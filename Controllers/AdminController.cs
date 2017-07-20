
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Itsomax.Module.ItsomaxAdmin.Controllers
{
    [Authorize(Policy = "ManageAuthentification")]
    public class AdminController : Controller
    {
        
        public IActionResult WelcomePage()
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
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}