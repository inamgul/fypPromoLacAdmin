using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fypPromolacAdmin.Models
{
    public class vendorViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vendorViewModel()
        {
            this.subUsers = new HashSet<subUser>();
            this.userPackages = new HashSet<userPackage>();
            this.areas = new HashSet<area>();
        }
        [Key]
        public int vendorId { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string firstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required")]

        public string lastName { get; set; }
        [MaxLength(11)]
        [MinLength(11)]
        public string phoneNumber { get; set; }
        [DisplayName("Email ID")]
        [Required(ErrorMessage = "email is required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string vendorEmail { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string vendorAddress { get; set; }
        [DisplayName("Address")]
        [Required(ErrorMessage = "Company Name is required")]
        public string vendorCompanyName { get; set; }
        public DateTime registerTimestamp { get; set; }
        [DisplayName("User Name:")]
        [Required(ErrorMessage = "Username is required")]
        [Remote("IsUserNameAvailable", "Vendor", 
                ErrorMessage = " Username already exists")]
        public string vendorUserName { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        public string vendorPassword { get; set; }
       
        public DateTime vendorBirthDate { get; set; }
        
        public string vendorStatus { get; set; }
        public int vendorAdminId { get; set; }
        [DisplayName("Deal")]
        [Required(ErrorMessage = "Deal is required")]
        public int vendorPackageTaken { get; set; }
        [DisplayName("Deal")]
        [Required(ErrorMessage = "Required")]
        public string isAdmin { get; set; }
        public virtual deal deal { get; set; }
        [Remote("IsAreaAvailable", "Vendor",
            ErrorMessage = " Username already exists")]
        public string[] area_vendor { get; set; }
        public virtual mainAdmin mainAdmin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<subUser> subUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userPackage> userPackages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<areaAssigned> areaAssigneds { get; set; }
        public virtual ICollection<area> areas { get; set; }
        public List<areaModel> detail { get; set; } //list of areas to be shown for selection
        

        public List<areaAssignedModel> vendorAreaDetail { get; set; }
        
        public List<areaModel> area_ids { get; set; }

        public List<package> package_details { get; set; }

        public static explicit operator vendorViewModel(List<vendor> v)
        {
            throw new NotImplementedException();
        }

        /*[NotMapped]
        public List<areaAssignedModel> detail { get; set; }
        */
    }
}