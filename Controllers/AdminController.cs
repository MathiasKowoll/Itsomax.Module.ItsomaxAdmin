using System.Collections.Generic;
using Itsomax.Module.Core.Interfaces;
using Itsomax.Module.Core.Models;
using Itsomax.Module.ItsomaxAdmin.Data;
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
        private readonly IEmailService _sendEmail;
        private readonly IAdminCustomRepository _adminCustomRepository;

        public AdminController(IStringLocalizer<AdminController> localizer,ILogger<AdminController> logger, 
            IEmailService sendEmail, IAdminCustomRepository adminCustomRepository)
        {
            _localizer = localizer;
            _logger = logger;
            _sendEmail = sendEmail;
            _adminCustomRepository = adminCustomRepository;
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

        public IActionResult Configuration()
        {
            
            return View(_adminCustomRepository.GetCommonSettings());
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Configuration(AppSetting model)
        {
            
            return View(_adminCustomRepository.GetCommonSettings());
        }

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
            var res =_sendEmail.SmtpSendEmail(emails, "test email", "This is a test email using gmail", "smtp.gmail.com",
                "xxxx@gmail.com", "xxx@gmail.com", "password", true, 587,
                "xxx@gmail.com",atachments);
            
            return View("WelcomePage");
        }
    }
}