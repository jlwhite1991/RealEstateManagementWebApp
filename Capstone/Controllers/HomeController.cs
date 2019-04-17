using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using Capstone.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Capstone.Providers.Auth;

namespace Capstone.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationDAL applicationDAL;
        private IPropertyDAL propertyDAL;
        private readonly IAuthProvider authProvider;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IUserDAL userDAL;
        public static string SessionKey = "Auth_User";

        public HomeController(IApplicationDAL applicationDAL, IPropertyDAL propertyDAL, IHttpContextAccessor contextAccessor, IUserDAL userDAL, IAuthProvider authProvider)
        {
            this.applicationDAL = applicationDAL;
            this.contextAccessor = contextAccessor;
            this.userDAL = userDAL;
            this.authProvider = authProvider;
            this.propertyDAL = propertyDAL;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Apply(Application application)
        {
            if (!ModelState.IsValid)
            {
                return View(application);
            }
            else
            {
                applicationDAL.AddApplication(application);

                return RedirectToAction("Apply");
            }
        }

        [HttpGet]
        public IActionResult Search()
        {
            SearchModel model = new SearchModel();
            model.CurrentAvailableProperties = propertyDAL.GetAvailableProperties();

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Search(SearchModel model)
        {
            model.CurrentAvailableProperties = propertyDAL.GetAvailableProperties();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                model.AdvancedPropertySearch();
                return View(model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        ISession Session => contextAccessor.HttpContext.Session;

        /// <summary>
        /// Returns true if the user is logged in.
        /// </summary>
        public bool IsLoggedIn => !String.IsNullOrEmpty(Session.GetString(SessionKey));

        /// <summary>
        /// Signs the user in and saves their username in session.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool SignIn(string username, string password)
        {
            var user = userDAL.GetUser(username);
            var hashProvider = new HashProvider();

            if (user != null && hashProvider.VerifyPasswordMatch(user.Password, password, user.Salt))
            {
                Session.SetString(SessionKey, user.EmailAddress);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Logs the user out by clearing their session data.
        /// </summary>
        public void LogOff()
        {
            Session.Clear();
        }

        /// <summary>
        /// Gets the user using the current username in session.
        /// </summary>
        /// <returns></returns>
        public User GetCurrentUser()
        {
            var username = Session.GetString(SessionKey);

            if (!String.IsNullOrEmpty(username))
            {
                return userDAL.GetUser(username);
            }

            return null;
        }
    }
}
