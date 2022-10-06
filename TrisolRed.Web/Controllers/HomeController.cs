using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using TrisolRed.Web.Helper;
using TrisolRed.Web.Models;
using TrisoleRed.Services.Interfaces;
using TrisoleRed.Services.Modes;

namespace TrisolRed.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailConfigurationJson _mailSettings;
        private readonly IProperties _properties;
        private readonly IContactUs _contact;
        public HomeController(IOptions<EmailConfigurationJson> mailSettings,IProperties properties,IContactUs contactUs)
        {    
            _contact = contactUs;
            _mailSettings = mailSettings.Value;
            _properties = properties;
        }

        public IActionResult Index()
        {
            //List<ProblemDetails> model = new List<ProblemDetails>();
            var model = _properties.GetAllProperties();
            return View(model);
        }

        public IActionResult PropptyDetails(int propertyId)
        {
            var property = _properties.GetById(propertyId);
            return View(property);

        }
        public async Task<IActionResult> ContactUs(ContactUsVm model)
        {
            if (ModelState.IsValid)
            {
                if (_contact.IsAdd(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
            //var email = new MimeMessage();
            //email.Sender = MailboxAddress.Parse(_mailSettings.From);
            //email.To.Add(MailboxAddress.Parse(model.ToEmail));
            //email.Subject = model.Subject;
            //var builder = new BodyBuilder();
            //if (model.Attachments != null)
            //{
            //    byte[] fileBytes;
            //    foreach (var file in model.Attachments)
            //    {
            //        if (file.Length > 0)
            //        {
            //            using (var ms = new MemoryStream())
            //            {
            //                file.CopyTo(ms);
            //                fileBytes = ms.ToArray();
            //            }
            //            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
            //        }
            //    }
            //}
            //builder.HtmlBody = model.Body;
            //email.Body = builder.ToMessageBody();
            //using var smtp = new SmtpClient();
            //smtp.Connect(_mailSettings.SmtpServer, _mailSettings.Port, SecureSocketOptions.StartTls);
            //smtp.Authenticate(_mailSettings.From, _mailSettings.Password);
            //await smtp.SendAsync(email);
            //smtp.Disconnect(true);
            //return RedirectToAction(nameof(Index));
        }

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