using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tcc.Models;

namespace tcc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult receita2()
        {
            return View();
        }

        public ActionResult receita3()
        {
            return View();
        }
        public ActionResult parceria()
        {
            return View();
        }
        public ActionResult principal()
        {
            return View();
        }
        public ActionResult Sair()
        {
            Session.Abandon();
            return RedirectToAction("Login","Home");
        }
        public ActionResult Index()
            {
                using (OurDbContext db = new OurDbContext())
                {
                    return View(db.userAccount.ToList());

                }

            }
            public ActionResult Register()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Register(UserAccount Home)
            {
                if (ModelState.IsValid)
                {
                    using (OurDbContext db = new OurDbContext())
                    {
                        db.userAccount.Add(Home);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.Message = Home.FirstName + " " + Home.LastName + "Sucessfully Registered.";
                }
            return RedirectToAction("Login");
            }
            public ActionResult Login()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Login(UserAccount user)
            {
                using (OurDbContext db = new OurDbContext())
                {
                var usr = db.userAccount.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                if (usr != null)
                    {
                        Session["UserID"] = usr.UserID.ToString();
                        Session["Username"] = usr.Username.ToString();
                        return RedirectToAction("receita1");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or password is wrong.");
                    }
                }
                return View();
            }
            public ActionResult receita1()
            {
                if (Session["Username"] != null)
                {
                return View();
            }
                else
                {
                return RedirectToAction("Login");
            } 
            }


    }

}
   