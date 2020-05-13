using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fypPromolacAdmin.Models;
namespace fypPromolacAdmin.Controllers
{
    public class packageController : Controller
    {
        // GET: package
        public ActionResult viewAllPackage()
        {
            using (var context = new promoLacDbEntities())
            {
                List <packageModel> package_List= new List<packageModel>();
                
                package_List = context.packages.Select(x=> new packageModel
                {
                    packageName=x.packageName,
                    packagesId=x.packagesId,
                    packageDescription=x.packageDescription,
                    packageDurationDays=x.packageDurationDays,
                    messagesAllowed=x.messagesAllowed,
                    subUsersAllowed=x.subUsersAllowed
                }).ToList();
                
                return View(package_List);
            }
                
        }
        
        public ActionResult editPackage(int id)
        {
            var context = new promoLacDbEntities();
            var package=context.packages.Where(x=>x.packagesId==id).Select(x=> new packageModel
            {
                packageName=x.packageName,
                packagesId=x.packagesId,
                packageDescription=x.packageDescription,
                subUsersAllowed=x.subUsersAllowed,
                packageDurationDays=x.packageDurationDays

            }).FirstOrDefault();
            

                return View(package) ;
        }
        [HttpPost]
        public ActionResult editPackage(packageModel pck)
        {
            using (var context = new promoLacDbEntities())
            {

                var myresult = context.packages.Where(x => x.packagesId == pck.packagesId).First();

                myresult.packageName = pck.packageName;
                myresult.packageDescription = pck.packageDescription;
                myresult.messagesAllowed = pck.messagesAllowed;
                myresult.packageDurationDays = pck.packageDurationDays;

                context.SaveChanges();
                List<packageModel> package_List = new List<packageModel>();
                package_List = context.packages.Select(x => new packageModel
                {
                    packageName = x.packageName,
                    packagesId = x.packagesId,
                    packageDescription = x.packageDescription,
                    packageDurationDays = x.packageDurationDays,
                    messagesAllowed = x.messagesAllowed,
                    subUsersAllowed = x.subUsersAllowed
                }).ToList();

                return View("viewAllPackage", package_List);

            }
         }
        public ActionResult createPackage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createPackage(packageModel pckg)
        {
            using (var context= new promoLacDbEntities())
            {
                package p = new package();
                p.packageName = pckg.packageName;
                p.packageDescription = pckg.packageDescription;
                p.packageDurationDays = pckg.packageDurationDays;
                p.subUsersAllowed = pckg.subUsersAllowed;

                context.packages.Add(p);
                context.SaveChanges();
                List<packageModel> package_List = new List<packageModel>();
                package_List = context.packages.Select(x => new packageModel
                {
                    packageName = x.packageName,
                    packagesId = x.packagesId,
                    packageDescription = x.packageDescription,
                    packageDurationDays = x.packageDurationDays,
                    messagesAllowed = x.messagesAllowed,
                    subUsersAllowed = x.subUsersAllowed
                }).ToList();
                return View("viewAllPackage", package_List);
            }
           
           
        }

    }
}