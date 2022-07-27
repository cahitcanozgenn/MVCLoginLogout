using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCLogınLogout.Models.Entity;
namespace MVCLogınLogout.Controllers
{
   
    public class SecurityController : Controller
    {
        userEntities userEntities = new userEntities();
        // GET: Security
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(users users)
        {
            var value = userEntities.users.FirstOrDefault(x => x.usersUserName == users.usersUserName && x.usersPassword == users.usersPassword);
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(users.usersUserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı Adı Ya Da Şifre Hatalı";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}