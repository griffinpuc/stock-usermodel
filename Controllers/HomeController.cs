using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleLoginForm.Models;

namespace SimpleLoginForm.Controllers
{
    public class HomeController : Controller
    {

        private DatabaseContext _context;
        private SafeVerify _safeVerify;

        public HomeController(DatabaseContext context)
        {
            _context = context;
            _safeVerify = new SafeVerify(context);
        }

        

        public IActionResult Index()
        {
            return View("Parent_Index");
        }

        public IActionResult LoginBasic()
        {
            return View();
        }

        public IActionResult SignupBasic()
        {
            return View();
        }

        public IActionResult Parent_Index()
        {
            return View();
        }

        public IActionResult Profile(string email)
        {
            return View();
        }

        public PartialViewResult SwitchToSignup()
        {
            return PartialView("Partial_Signup");
        }

        public PartialViewResult SwitchToLogin()
        {
            return PartialView("Partial_Login");
        }

        public bool VerifyEmail(string email)
        {
            bool retval = false;

            if (_safeVerify.verifyEmail(email))
            {
                retval = true;
            }

            return retval;
        }

        public ActionResult SecureSignUp(string inputEmail, string inputPassword)
        {
            if(_safeVerify.secureCreation(inputEmail, inputPassword))
            {
                return null; //return page here
            }

            return null;
        }

        public ActionResult SecureLogIn(string inputEmail, string inputPassword)
        {
            if(_safeVerify.secureLogin(inputEmail, inputPassword))
            {
                return View("Profile");
            }
            else
            {
                return View(); //return other view
            }
            
        }

    }
}
