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
        public IActionResult Index()
        {
            return View("LoginBasic");
        }

        public IActionResult LoginBasic()
        {
            return View();
        }

        public IActionResult SignupBasic()
        {
            return View();
        }

        //public void SignUp()

    }
}
