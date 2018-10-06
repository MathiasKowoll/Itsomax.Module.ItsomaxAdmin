using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Itsomax.Module.Core.ViewModels;

namespace Itsomax.Module.ItsomaxAdmin.ViewModels
{

    public class SetSystemInfoViewModel
    {
        public IList<AppSettingModels> AppSettings { get; set; }
        public IList<AppSettingModels> ImageConfig { get; set; }
    }

    public abstract class GenericEmailSend
    {
        [MaxLength(200)]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        [MaxLength(200)]
        public string FromEmail { get; set; }
    }
    
    public class MailGunConfigurationViewModel
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Domain { get; set; }
        [MaxLength(200)]
        public byte[] ApiKey { get; set; }
    }

    public class SmtpConfigurationAnonymousViewModel
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string SmtpServer { get; set; }
        [MaxLength(200)]
        public string FromEmail { get; set; }
        public bool RequireSsl { get; set; }
        public int Port { get; set; }
        public bool Default { get; set; }
    }

    public class SmtpConfigurationViewModel
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)] 
        public string SmtpServer { get; set; }
        [MaxLength(200)]
        public string FromEmail { get; set; }
        public bool RequireSsl { get; set; }
        public int Port { get; set; }
        [MaxLength(100)]
        public string User { get; set; }
        public byte[] Password { get; set; }
        public bool Default { get; set; }
    }
}