
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Itsomax.Module.ItsomaxAdmin.Controllers
{
    [Authorize(Policy = "ManageAuthentification")]
    public class AdminController : Controller
    {       
        private readonly IStringLocalizer<AdminController> _localizer;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IStringLocalizer<AdminController> localizer,
            ILogger<AdminController> logger)
        {
            _localizer = localizer;
            _logger = logger;
        }

        public IActionResult WelcomePage()
        {
            _logger.LogInformation(_localizer["Hello"]);
            return View();
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}