using fypPromolacAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace fypPromolacAdmin.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(adminModel model)
        {
            using (var context = new promoLacDbEntities())
            {
                bool isvalidVendor = context.mainAdmins.Any(x => x.username == model.username && x.password_ == model.password_);
                if (isvalidVendor)
                {
                    FormsAuthentication.SetAuthCookie(model.username, false);
                    return RedirectToAction("addVendor", "Vendor");
                }
                ModelState.AddModelError("", "Invalid User Name and Password");

            }
            return View();
        }
    }
}