using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using Capstone.Models.Account;
using Capstone.Providers.Auth;
using Microsoft.AspNetCore.Http;
using Capstone.DAL.Interfaces;

namespace Capstone.Controllers
{

    public class AccountController : Controller
    {
        private readonly IAuthProvider authProvider;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IUserDAL userDAL;
        private readonly IApplicationDAL applicationDAL;

        public AccountController(IApplicationDAL applicationDAL, IHttpContextAccessor contextAccessor, IUserDAL userDAL, IAuthProvider authProvider)
        {
            this.applicationDAL = applicationDAL;
            this.contextAccessor = contextAccessor;
            this.userDAL = userDAL;
            this.authProvider = authProvider;
        }



        [AuthorizationFilter("manager", "owner", "tenant", "user")]
        [HttpGet]
        public IActionResult Index()
        {
            User user = authProvider.GetCurrentUser();

            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                bool validLogin = authProvider.SignIn(loginViewModel.Email, loginViewModel.Password);
                if (validLogin)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            authProvider.LogOff();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Register(registerViewModel.Email, registerViewModel.Password, "user",
                    registerViewModel.PhoneNumber, registerViewModel.FirstName, registerViewModel.LastName) == false)
                {
                    return RedirectToAction("Error", "Home");
                }


                return RedirectToAction("Index", "Home");
            }
            return View(registerViewModel);
        }


    }
}