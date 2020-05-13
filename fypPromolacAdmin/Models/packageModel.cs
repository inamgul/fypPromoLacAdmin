using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fypPromolacAdmin.Models
{
    public class packageModel
    {
        [Key]
        [DisplayName("PackageId")]
        public int packagesId { get; set; }
        [DisplayName("Package Name")]
        public string packageName { get; set; }
        [DisplayName("Messages Allowed")]
        public int messagesAllowed { get; set; }
        [DisplayName("Sub Users Allowed")]
        public int subUsersAllowed { get; set; }

        [DisplayName("Package Duration")]
        public int packageDurationDays { get; set; }

        [DisplayName("Package Description")]
        public string packageDescription { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<packageStatus_> packageStatus_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userPackage> userPackages { get; set; }

       
    }
}