using CovProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CovProj.Controllers
{
    public class HomeController : Controller
    {
        private CovidDBContext db = new CovidDBContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult map()
        {
            return View();
        }
        public ActionResult Statistic()
        {
            return View();
        }
        public ActionResult Public_information()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Peoples people)
        {
            var loggedUser = db.peoples.Where(u => u.Identification == people.Identification && u.Password == people.Password).FirstOrDefault();

            if (loggedUser != null)
            {
                SetSessionForUser(loggedUser);
                return RedirectToAction("Index");
            }

            if (loggedUser == null)
            {
               
                ModelState.AddModelError("", "Wrong credentials plese registrate");
                Session["login"] = "true";

                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Wrong credentials");
                return RedirectToAction("Create", "Peoples");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        private bool EmailAlreadyTaken(string email)
        {
            Peoples user = db.peoples.AsNoTracking().Where(u => u.Email == email).FirstOrDefault();

            return (user != null);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AccessDenied(string ErrorMessage)
        {
            if (ErrorMessage != null)
            {
                ViewBag.ErrorMessage = ErrorMessage;
            }
            return View();
        }
        private void SetSessionForUser(Peoples loggedUser)
        {
            Session["UserID"] = loggedUser.PeoplesId.ToString();
            Session["Username"] = loggedUser.Email.ToString();
            Session["Fullname"] = loggedUser.FirstName.ToString() + " " + loggedUser.LastName.ToString();

            if (loggedUser.IsAdmin)
                Session["Admin"] = "true";
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}