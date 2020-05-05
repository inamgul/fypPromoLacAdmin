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
        public ActionResult login(vendorViewModel model)
        {
            using (var context = new promoLacDbEntities())
            {
                bool isvalidVendor = context.vendors.Any(x => x.vendorUserName == model.vendorUserName && x.vendorPassword == model.vendorPassword);
                if (isvalidVendor)
                {
                    FormsAuthentication.SetAuthCookie(model.vendorUserName, false);
                    return RedirectToAction("controlPanel", "controlPanel");
                }
                else
                {
                    bool isvalidSubUser = context.subUsers.Any(x => x.subUserUserName == model.vendorUserName && x.subUserPassword == model.vendorPassword);
                    if (isvalidSubUser)
                    {
                        FormsAuthentication.SetAuthCookie(model.vendorUserName, false);
                        return RedirectToAction("controlPanel", "controlPanel");
                    }
                }

                ModelState.AddModelError("", "Invalid User Name and Password");

            }
            return View();
        }
    }
}