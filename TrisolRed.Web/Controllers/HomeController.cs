using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Diagnostics;
using System.Net.Mail;
using System.Net.Mime;
using TrisolRed.Web.Helper;
using TrisolRed.Web.Models;
using System.IO;
using System.Threading.Tasks;
using MailKit.Security;

namespace TrisolRed.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailConfigurationJson _mailSettings;
        public HomeController(IOptions<EmailConfigurationJson> mailSettings)
        {
            this._mailSettings = mailSettings.Value;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> ContactUs(EmailBody model)
        //{
        //    var email = new MimeMessage();
        //    email.Sender = MailboxAddress.Parse(_mailSettings.From);
        //    email.To.Add(MailboxAddress.Parse(model.ToEmail));
        //    email.Subject = model.Subject;
        //    var builder = new BodyBuilder();
        //    if (model.Attachments != null)
        //    {
        //        byte[] fileBytes;
        //        foreach (var file in model.Attachments)
        //        {
        //            if (file.Length > 0)
        //            {
        //                using (var ms = new MemoryStream())
        //                {
        //                    file.CopyTo(ms);
        //                    fileBytes = ms.ToArray();
        //                }
        //                builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
        //            }
        //        }
        //    }
        //    builder.HtmlBody = model.Body;
        //    email.Body = builder.ToMessageBody();
        //    using var smtp = new SmtpClient();
        //    smtp.Connect(_mailSettings.SmtpServer, _mailSettings.Port, SecureSocketOptions.StartTls);
        //    smtp.Authenticate(_mailSettings.From, _mailSettings.Password);
        //    await smtp.SendAsync(email);
        //    smtp.Disconnect(true);
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}