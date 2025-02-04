using Microsoft.AspNetCore.Hosting;
using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Entities.Helper
{
    public class EmailHelper : IEmailHelper
    {
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _env;

        public EmailHelper(IEmailService emailService, IWebHostEnvironment env)
        {
            _emailService = emailService;
            _env = env;
        }

        public bool IsValidEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> SendEmailAsync(string email, string url, string subject, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> SendNotificationEmailAsync(string email, string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}
