using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Entities;
using Healthware.Core.Constants;
using Healthware.Core.EmailService;
using Healthware.Core.MultiTenancy.Entities;
using Healthware.Core.Security;
using Healthware.Core.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MimeKit;

namespace HealthWare.ActiveASSIST.Web.Common.Email
{
    public interface IEmailService
    {
        Task<string> SendEmailConfirmation(BasicInfo basicInfo, long assessmentId, string mailType, string mailSubject);
        Task<string> SendOTPConfirmation(User user, string fullName, string mailType, string emailSubject);
    }
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _context;
        private readonly IHostingEnvironment _env;

        public EmailService(IEmailSender emailSender, IHttpContextAccessor context, IHostingEnvironment env)
        {
            _emailSender = emailSender;
            _context = context;
            _env = env;
        }
        public async Task<string> SendEmailConfirmation(BasicInfo basicInfo, long assessmentId, string mailType, string mailSubject)
        {
            var token = TokenGeneration(basicInfo, assessmentId, mailType);
            
            string finalURL;
            var fullName = basicInfo.FirstName + " " + basicInfo.MiddleName + " " + basicInfo.LastName;
            var bodyBuilder = new BodyBuilder();
            finalURL = "http://localhost/ActiveAssistClient/email-verification/?token=";
            var path = Application.EmailTemplatePath;
            var pathToFile = _env.WebRootPath + path + mailType + Application.HtmlExtension;
            using (StreamReader sourceReader = File.OpenText(pathToFile))
            {
                bodyBuilder.HtmlBody = sourceReader.ReadToEnd();
            }
            var messageBody = string.Format(bodyBuilder.HtmlBody,
                fullName,
                finalURL,
                token
            );

                bodyBuilder.HtmlBody = messageBody;

            var message = new Message(new string[] { basicInfo.EmailAddress }, mailSubject);
            var result = await _emailSender.SendEmail(message, bodyBuilder);
            if (result == false)
                return string.Empty;
            return token;
        }

        public async Task<string> SendOTPConfirmation(User user, string fullName, string mailType, string emailSubject)
        {
            var otpNumber = GenerateOTP();
            var bodyBuilder = new BodyBuilder();
            string path = Application.EmailTemplatePath;
            var pathToFile = _env.WebRootPath + path + mailType + Application.HtmlExtension;
            using (StreamReader sourceReader = File.OpenText(pathToFile))
            {
                bodyBuilder.HtmlBody = sourceReader.ReadToEnd();
            }

            var messageBody = string.Format(bodyBuilder.HtmlBody,
                 fullName,
                otpNumber);
            bodyBuilder.HtmlBody = messageBody;
                                                                            
            var message = new Message(new string[] { user.EmailAddress }, emailSubject);
            var result = await _emailSender.SendEmail(message, bodyBuilder);
            if (result == false)
                return string.Empty;
            return otpNumber;

        }

        private string TokenGeneration(BasicInfo basicInfo, long assessmentId, string mailType)
        {
            var claims = new List<Claim>
            {
                //TODO: Add other claims also
                new Claim(UserClaimTypes.Email, basicInfo.EmailAddress),
                new Claim(UserClaimTypes.MailType, mailType),
                new Claim(UserClaimTypes.PatientId, basicInfo.Id.ToString()),
                new Claim(UserClaimTypes.AssessmentId, assessmentId.ToString())
            };

            //TODO: Get from appsettings
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HEALTHWARE_C421AAEE0D114E9C"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = Clock.Now().AddDays(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenGeneration = ((JwtSecurityToken)token).RawData;
            return tokenGeneration;
        }

        public string GenerateOTP()
        {
            string numbers = "0123456789";
            Random random = new Random();
            string otp = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                int temp = random.Next(0, numbers.Length);
                otp += temp;
            }
            return otp;

        }
    }
}
