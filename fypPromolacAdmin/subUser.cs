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
    
    public partial class subUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public subUser()
        {
            this.areaAssignedSUsers = new HashSet<areaAssignedSUser>();
        }
    
        public int subUserId { get; set; }
        public string subUserFirstName { get; set; }
        public string subUserLastName { get; set; }
        public string subUserPhoneNumber { get; set; }
        public string subUserEmail { get; set; }
        public System.DateTime subUserRegisterTimestamp { get; set; }
        public string subUserUserName { get; set; }
        public string subUserPassword { get; set; }
        public int subUserVendorId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<areaAssignedSUser> areaAssignedSUsers { get; set; }
        public virtual vendor vendor { get; set; }
    }
}