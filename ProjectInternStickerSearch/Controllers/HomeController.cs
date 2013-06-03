using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Transactions;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using ProjectInternStickerSearch.Filters;
using ProjectInternStickerSearch.Models;

namespace ProjectInternStickerSearch.Controllers
{
    
    public class HomeController : Controller
    {
        public static string username;

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult Group()
        {
            FormsAuthentication.SetAuthCookie(null, true);
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SetAuthCookie(null, true);
            username = null;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult LoginCall(string UserName, string Password)
        {
            Login loginModelObject = new Login();
            
            if (0 == loginModelObject.LogIn(UserName, Password))
            {
                FormsAuthentication.SetAuthCookie(UserName, true);
                username = UserName;
                 return View("Profile");
            }
            else
            {
                 return View("Group");
            }
        }
    }
}
