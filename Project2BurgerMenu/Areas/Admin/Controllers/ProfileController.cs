using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2BurgerMenu.Entities;
using Project2BurgerMenu.Context;

namespace Project2BurgerMenu.Areas.Admin.Controllers
{
    public class ProfileController : Controller
    {
        BurgerMenuContext context = new BurgerMenuContext();
        // GET: Admin/Profile
        public ActionResult MyProfileList()
        {
            var userName = Session["x"];
            var values = context.Admins.Where(x => x.Username == userName).FirstOrDefault();
            return View(values);
        }

        [HttpPost]
        public ActionResult MyProfileList(Project2BurgerMenu.Entities.Admin admin)
        {
            var userName = Session["x"];
            var values = context.Admins.Where(x => x.Username == userName).FirstOrDefault();
            values.Username = admin.Username;
            values.Surname = admin.Surname;
            values.Name = admin.Name;
            values.Email = admin.Email;
            values.Password = admin.Password;
            context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}