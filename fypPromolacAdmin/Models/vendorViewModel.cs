using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string vendorEmail { get; set; }
        public string vendorAddress { get; set; }
        public string vendorCompanyName { get; set; }
        public DateTime registerTimestamp { get; set; }
        [DisplayName("User Name:")]
        public string vendorUserName { get; set; }
        public string vendorPassword { get; set; }
        public string vendorSex { get; set; }
        public DateTime vendorBirthDate { get; set; }
        public string vendorStatus { get; set; }
        public int vendorAdminId { get; set; }
        public int vendorDealTaken { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string isAdmin { get; set; }
        public virtual deal deal { get; set; }
        public virtual mainAdmin mainAdmin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<subUser> subUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userPackage> userPackages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<areaAssigned> areaAssigneds { get; set; }
        public virtual ICollection<area> areas { get; set; }
        public List<areaModel> detail { get; set; }

        public List<areaAssignedModel> vendorAreaDetail { get; set; }
        public List<string> area_vendor { get; set; }

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