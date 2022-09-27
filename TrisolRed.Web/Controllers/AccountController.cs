using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using TrisoleRed.Services.Interfaces;
using TrisoleRed.Services.Modes;
using TrisolRed.Web.Helper;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace TrisolRed.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserInterface _user;
        private readonly INotyfService _notyf;
        private readonly IProperties _properties;
        [Obsolete]
        public AccountController(IUserInterface user,INotyfService notyf, IProperties properties)
        {
            _user = user;
            _notyf = notyf;
            _properties = properties;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LogIn model)
        {
            if (ModelState.IsValid)
            {
                if (_user.LogIn(model))
                {
                    _notyf.Success("");
                    return View();
                }
                _notyf.Error("");
                return View(model);
            }
            else
            {
                _notyf.Error("");
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(Sign model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_user.SignIn(model))
                    {
                        _notyf.Success("user create success");
                        return View();
                    }
                    else
                    {
                        _notyf.Error("Email is already exit");
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
            }
            catch(Exception ex)
            {
                _notyf.Error(ex.Message);
                return View(model);
            }
        }
        public IActionResult ListProperty()
        {
            var model = _properties.GetAllProperties();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddProperty()
        {
            return View();
        }
        [HttpPost]
        [Obsolete]
        public IActionResult AddProperty(PropertiesDetailsModelView model)
        {
            if (ModelState.IsValid)
            {
                if (_properties.AddPropty(model))
                {
                    _notyf.Success("Create success");
                    return RedirectToAction(nameof(ListProperty));
                }
                _notyf.Error("Server Error");
                return View(model);
            }
            _notyf.Error("Server Error");
            return View(model);
        }

        
    }
}
