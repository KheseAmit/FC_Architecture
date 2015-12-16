using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FC.Entities;
using FC.Repositories;

namespace FastCodeinxSIMS.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository UserRepository;
        public AccountController()
        {
            UserRepository = new UserRepository();

        }

        public ActionResult Login()
        {
            FC_Users fcUser = new FC_Users();
            return View("Login", fcUser);
        }

        [HttpPost]
        public ActionResult Login(FC_Users fcUser)
        {
            if (UserRepository.IsValidUser(fcUser))
            {
                return RedirectToAction("index", "Home");
            }
            else
            {
                fcUser = new FC_Users();
                ViewBag.InvalidLoginMessage = "Invalid Username and Password!";
                return View("Login", fcUser);
            }

        }
    }
}