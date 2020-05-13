//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fypPromolacAdmin
{
    using System;
    using System.Collections.Generic;
    
    public partial class vendor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vendor()
        {
            this.areaAssigneds = new HashSet<areaAssigned>();
            this.packageStatus_ = new HashSet<packageStatus_>();
            this.subUsers = new HashSet<subUser>();
            this.userPackages = new HashSet<userPackage>();
        }
    
        public int vendorId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string vendorEmail { get; set; }
        public string vendorAddress { get; set; }
        public string vendorCompanyName { get; set; }
        public System.DateTime registerTimestamp { get; set; }
        public string vendorUserName { get; set; }
        public string vendorPassword { get; set; }
        public System.DateTime vendorBirthDate { get; set; }
        public string vendorStatus { get; set; }
        public string isAdmin { get; set; }
        public int vendorAdminId { get; set; }
        public int vendorPackageTaken { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<areaAssigned> areaAssigneds { get; set; }
        public virtual mainAdmin mainAdmin { get; set; }
        public virtual package package { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<packageStatus_> packageStatus_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<subUser> subUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userPackage> userPackages { get; set; }
    }
}
