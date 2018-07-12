using System.Collections.Generic;
using System.Threading.Tasks;
using Itsomax.Module.Core.Interfaces;
using Itsomax.Module.Core.Models;
using Itsomax.Module.ItsomaxAdmin.Data;
using Itsomax.Module.ItsomaxAdmin.Interfaces;
using Itsomax.Module.ItsomaxAdmin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Itsomax.Module.ItsomaxAdmin.Controllers
{
    [Authorize(Policy = "ManageAuthentification")]
    public class AdminController : Controller
    {
        private readonly IEmailService _sendEmail;
        private readonly IConfigureSystem _configureSystem;
        private readonly IAdminCustomRepository _adminCustomRepository;
        private readonly UserManager<User> _userManager;
        private readonly IToastNotification _toastNotification;


        public AdminController(IEmailService sendEmail, IConfigureSystem configureSystem,
            IAdminCustomRepository adminCustomRepository, IToastNotification toastNotification,
            UserManager<User> userManager)
        {
            _sendEmail = sendEmail;
            _configureSystem = configureSystem;
            _adminCustomRepository = adminCustomRepository;
            _toastNotification = toastNotification;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var customPage = _adminCustomRepository.GetSystemDefaultPage();
            return Redirect(customPage.Value == "" ? "/Admin/Welcome" : customPage.Value);
        }


        [Route("/Admin/Welcome")]
        public IActionResult WelcomePage()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Route("/Configuration/GlobalSettings")]
        public IActionResult Configuration()
        {
            var model = new SetSystemInfoViewModel {AppSettings = _configureSystem.GetSystemSettings(false)};
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ConfigurationPost(IFormCollection form)
        {
            string[] systemKeys = form["key"].ToArray();
            string[] systemValues = form["value"].ToArray();
            var res = _configureSystem.SaveCommonConfiguration(systemKeys, systemValues, GetCurrentUserAsync().Result.UserName).Result;
            if (res.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage(res.OkMessage, new ToastrOptions
                {
                    PositionClass = ToastPositions.TopCenter
                });
                return RedirectToAction(nameof(Index));
            }
            _toastNotification.AddWarningToastMessage(res.Errors, new ToastrOptions
            {
                PositionClass = ToastPositions.TopCenter
            });
            return RedirectToAction("Configuration");
        }

        [Route("/Configuration/AddEmailSmtp")]
        public IActionResult EmailAddSmtp()
        {
            return View();
        }

        public IActionResult TestEmail()
        {
            IList<string> atachments = new List<string>();
            atachments.Add("");
            IList<string> emails = new List<string>();
            emails.Add("XXXX@somemail.com");
            var res = _sendEmail.SmtpSendEmail(emails, "test email", "This is a test email using gmail",
                "smtp.gmail.com",
                "xxxx@gmail.com", "xxx@gmail.com", "password", true, 587,
                "xxx@gmail.com", atachments);

            return View("WelcomePage");
        }

        //#Helper Region
        private Task<User> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

    }
}