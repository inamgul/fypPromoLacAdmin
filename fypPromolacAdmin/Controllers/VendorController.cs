using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using fypPromolacAdmin.Models;

namespace fypPromolacAdmin.Controllers
{
    
    public class VendorController : Controller
    {
        // GET: Vendor
        private promoLacDbEntities db = new promoLacDbEntities();

        public ActionResult addVendor()
        {
            using (var context = new promoLacDbEntities())
            {
                vendorViewModel vendorObject = new vendorViewModel();
                var areasList = context.areas.Select(x => new areaModel
                {
                    areaId = x.areaId,
                    areaName = x.areaName,
                    areaHashCode = x.areaHashCode

                }).ToList();
                vendorObject.detail = areasList;

                return View(vendorObject);
            }

        }
        
        [HttpPost]
        public ActionResult AddCompleteVendorInfo(vendorViewModel v)
        {
            vendorViewModel v1 = TempData["vendorObject"] as vendorViewModel;
            v1.vendorPackageTaken = v.vendorPackageTaken;

            using (var context = new promoLacDbEntities())
            {
               
                vendor ven = new vendor()
                {
                    firstName = v1.firstName,
                    lastName = v1.lastName,
                    phoneNumber = v1.phoneNumber,
                    vendorEmail = v1.vendorEmail,
                    vendorAddress = v1.vendorAddress,
                    registerTimestamp = DateTime.Now,
                    vendorUserName = v1.vendorUserName,
                    vendorPassword = v1.vendorPassword,
                    vendorBirthDate = DateTime.Now,
                    vendorStatus = "A",
                    vendorAdminId = getAdminId(User.Identity.Name),
                    vendorPackageTaken = v1.vendorPackageTaken,
                     isAdmin = v1.isAdmin,
                    vendorCompanyName = v1.vendorCompanyName

                };

                context.vendors.Add(ven);
                context.SaveChanges();
                int id = getVendorId(v1.vendorUserName);
                foreach (var item in v1.area_vendor)
                {
                    areaAssigned ar = new areaAssigned()
                    {
                        vendorId = id,
                        areaId = Convert.ToInt32(item)
                    };
                    context.areaAssigneds.Add(ar);
                    context.SaveChanges();
                }


                return RedirectToAction("viewAllVendors");
            }

            

        }
        

        [HttpPost]
        public ActionResult addVendor(vendorViewModel v)
        {
            using (var context = new promoLacDbEntities())
            {
                var packagesdetails = context.packages.ToList();
                v.package_details = packagesdetails;
                TempData["vendorObject"] = v;
                return View("AddCompleteVendorInfo", v);
            }

        }
        public ActionResult viewAllVendors()
        {
            using (var context = new promoLacDbEntities())
            {
                var v = context.vendors.Select(x => new vendorViewModel()
                {
                    vendorId = x.vendorId,
                    firstName = x.firstName,
                    lastName = x.lastName,
                    phoneNumber = x.phoneNumber,
                    vendorEmail = x.vendorEmail,
                    vendorAddress = x.vendorAddress,
                    registerTimestamp = x.registerTimestamp,
                    vendorUserName = x.vendorUserName,
                    vendorPackageTaken = x.vendorPackageTaken,
                    vendorCompanyName = x.vendorCompanyName

                }).ToList();

                foreach (vendorViewModel x in v)
                {
                    x.vendorAreaDetail = getAreas(x.vendorId);

                }
                TempData["VendorDetails"] = v;
                return View(v);
            }
        }
        public List<areaAssignedModel> getAreas(int x)
        {
            using (var context = new promoLacDbEntities())
            {
                var a = context.areaAssigneds.Where(y => y.vendorId == x).Select(z => new areaAssignedModel
                {
                    areaId = z.areaId

                }).ToList();

                foreach (areaAssignedModel j in a)
                {
                    j.areaNames = getAreaName(j.areaId);
                }
                return a;

            }
        }
        
        public ActionResult EditVendor(int id)
        {
            if (id.Equals(null))
            {
                viewAllVendors();
                return View();
            }
            else
            {

                var context = new promoLacDbEntities();
               // List<vendorViewModel> V = TempData["VendorDetails"] as List<vendorViewModel>;
                //TempData["VendorDetails"] = V;
                vendorViewModel z = new vendorViewModel();
                z = context.vendors.Where(x => x.vendorId == id).Select(y => new vendorViewModel
                {
                    vendorId = y.vendorId,
                    vendorEmail = y.vendorEmail,
                    vendorPackageTaken = y.vendorPackageTaken,
                    vendorUserName = y.vendorUserName,
                    vendorAddress = y.vendorAddress,
                    phoneNumber = y.phoneNumber

                }).FirstOrDefault();
                z.vendorAreaDetail = getAreas(z.vendorId);
                return View(z);
            }
        }
        public void removeArea(int area_id, int vendor_id)
        {
            using (var context = new promoLacDbEntities())
            {
                var myresult = context.areaAssigneds.Where(x => (x.areaId == area_id) && (x.vendorId == vendor_id)).First();
                context.areaAssigneds.Remove(myresult);
                context.SaveChanges();
            }
            EditVendor(vendor_id);

        }

        public ActionResult addArea(int vendor_id)
        {
            using (var context = new promoLacDbEntities())
            {
                vendorViewModel vendorObject = new vendorViewModel();
                var areasList = context.areas.Select(x => new areaModel
                {
                    areaId = x.areaId,
                    areaName = x.areaName,
                    areaHashCode = x.areaHashCode

                }).ToList();
                List<areaModel> area_ids = getvendorAreas(vendor_id);
                
                    foreach(areaModel x in areasList.ToList())
                {
                    foreach(var z in area_ids)
                    {
                        if (x.areaName.Equals(z.areaName))
                        {
                            areasList.Remove(x);
                         
                        }
                    }
                    
                    
                }
                    
                
                vendorObject.detail = areasList;
                vendorObject.vendorUserName=getVendorUserName(vendor_id);
                
               
                return View(vendorObject);
            }

        }
        public ActionResult updateVendorPackage(int vendor_id)
        {
            using (var context = new promoLacDbEntities())
            {
                var packagesdetails = context.packages.ToList();
                vendorViewModel v = new vendorViewModel();
                v.vendorId = vendor_id;
                v.package_details = packagesdetails;

                return RedirectToAction("viewAllVendors");
            }
        }
        [HttpPost]
        public ActionResult updateVendorPackage(vendorViewModel v)
        {
            using (var context = new promoLacDbEntities())
            {
                var result = context.vendors.Where(x => x.vendorId == v.vendorId).FirstOrDefault();
                result.vendorPackageTaken = v.vendorPackageTaken;
                context.SaveChanges();
                return View("viewAllVendors");
            }
        }
        [HttpPost]
        public ActionResult addArea(vendorViewModel vendor)
        {
            using (var context = new promoLacDbEntities())
            {
               

                return View();
            }

        }
        public JsonResult IsUserNameAvailable(string vendorUserName)
        {
            return Json(!db.vendors.Any(u => u.vendorUserName == vendorUserName), JsonRequestBehavior.AllowGet);
        }




                     /* =====================================================
                                 
                                     Getter Setter functions
                        
                        ======================================================*/

        public int getAdminId(string name)
        {
            using (var context = new promoLacDbEntities())
            {
                var v = context.mainAdmins.Where(x => x.username == name).FirstOrDefault();
                return v.id;

            }
        }
        public List<areaModel> getvendorAreas(int id)
        {
            using (var context = new promoLacDbEntities())
            {
                var v = context.areaAssigneds.Where(x => x.vendorId == id).Select(y => new areaModel

                {
                    areaId = y.areaId,

                }).ToList();
               foreach(areaModel item in v)
                {
                    item.areaName = getAreaName(item.areaId);
                    item.areaHashCode = getAreaHashcode(item.areaId);
                }
                return v;

            }
            
        }
        public string getAreaName(int id)
        {
            using (var context = new promoLacDbEntities())
            {
                var x = context.areas.Where(y => y.areaId == id).FirstOrDefault();
                return x.areaName;
            }


        }
        public string getAreaHashcode(int id)
        {
            using (var context = new promoLacDbEntities())
            {
                var x = context.areas.Where(y => y.areaId == id).FirstOrDefault();
                return x.areaHashCode;
            }


        }
        public int getVendorId(string name)
        {
            using (var context = new promoLacDbEntities())
            {
                
                var v = context.vendors.Where(x => x.vendorUserName == name).FirstOrDefault();
                int id = v.vendorId;
                return id;
            }
        }
        public string getVendorUserName(int id)
        {
            using (var context = new promoLacDbEntities())
            {

                var v = context.vendors.Where(x => x.vendorId==id).FirstOrDefault();
                string name = v.vendorUserName;
                return name;
            }
        }
        public int getAreaId(string name)
        {
            using (var context = new promoLacDbEntities())
            {
                var v = context.areas.Where(x => x.areaName == name).FirstOrDefault();
                int id = v.areaId;
                return id;
            }
        }
    }
}