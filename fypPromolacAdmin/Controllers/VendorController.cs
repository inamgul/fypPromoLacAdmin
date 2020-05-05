using System;
using System.Collections.Generic;
using System.Linq;
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
                var areasList= context.areas.Select(x=> new areaModel{
                    areaId=x.areaId,
                    areaName=x.areaName,
                    areaHashCode=x.areaHashCode

                }).ToList();
                vendorObject.detail = areasList;

                    return View(vendorObject);
            }

        }
        [HttpPost]
        public ActionResult AddCompleteVendorInfo(vendorViewModel v)
        {
            vendorViewModel v1 = TempData["vendorObject"] as vendorViewModel;
            v1.vendorDealTaken = v.vendorDealTaken;

            using (var context = new promoLacDbEntities())
            {
                vendor ven = new vendor()
                {
                    firstName=v1.firstName,
                    lastName=v1.lastName,
                    phoneNumber=v1.phoneNumber,
                    vendorEmail=v1.vendorEmail,
                    vendorAddress=v1.vendorAddress,
                    registerTimestamp=DateTime.Now,
                    vendorUserName=v1.vendorUserName,
                    vendorPassword=v1.vendorPassword,
                    vendorSex=v1.vendorSex,
                    vendorBirthDate=DateTime.Now,
                    vendorStatus=v1.vendorStatus,
                    vendorAdminId=v1.vendorAdminId,
                    vendorDealTaken=v1.vendorDealTaken,
                    latitude=v1.latitude,
                    longitude=v1.longitude,
                    isAdmin=v1.isAdmin,
                    vendorCompanyName=v1.vendorCompanyName

                };

                context.vendors.Add(ven);
                context.SaveChanges();
                int id=getVendorId(v1.vendorUserName);
                foreach(var item in v1.area_vendor)
                {
                    areaAssigned ar = new areaAssigned()
                    {
                        vendorId = id,
                        areaId = Convert.ToInt32(item)
                    };
                    context.areaAssigneds.Add(ar);
                    context.SaveChanges();
                }
                
                
                    
            }


            return View("addVendor");
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
        
        [HttpPost]
        public ActionResult addVendor(vendorViewModel  v)
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
            using (var context= new promoLacDbEntities())
            {
                var v = context.vendors.Select(x=> new vendorViewModel() {
                    vendorId=x.vendorId,
                    firstName = x.firstName,
                    lastName = x.lastName,
                    phoneNumber = x.phoneNumber,
                    vendorEmail = x.vendorEmail,
                    vendorAddress = x.vendorAddress,
                    registerTimestamp = x.registerTimestamp,
                    vendorUserName = x.vendorUserName,
                    vendorDealTaken = x.vendorDealTaken,
                    vendorCompanyName =x.vendorCompanyName

                }).ToList();
              
                foreach (vendorViewModel x in v)
                {
                    x.vendorAreaDetail = getAreas(x.vendorId);
                    
                }
                return View(v);
            }
        }
        public List<areaAssignedModel> getAreas(int x)
        {
            using (var context = new promoLacDbEntities())
            {
                var a = context.areaAssigneds.Where(y => y.vendorId == x).Select(z => new areaAssignedModel {
                    areaId=z.areaId

                }).ToList() ;
                
               foreach(areaAssignedModel j in a)
                {
                    j.areaNames = getAreaName(j.areaId);
                }
                return a;

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
       
      
    }
}