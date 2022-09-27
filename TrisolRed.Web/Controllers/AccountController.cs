using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using TrisoleRed.Services.Interfaces;
using TrisoleRed.Services.Modes;

namespace TrisolRed.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserInterface _user;
        private readonly INotyfService _notyf;
        public AccountController(IUserInterface user,INotyfService notyf)
        {
            _user = user;
            _notyf = notyf;
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
    }
}
