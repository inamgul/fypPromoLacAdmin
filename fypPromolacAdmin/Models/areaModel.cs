using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace fypPromolacAdmin.Models
{
    public class areaModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public areaModel()
        {
            this.areaAssignedSUsers = new HashSet<areaAssignedSUser>();
            this.areaAssigneds = new HashSet<areaAssigned>();
            this.notifications = new HashSet<notification>();
        }
        [Key]
        public int areaId { get; set; }
        public string areaName { get; set; }
        public string areaHashCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<areaAssignedSUser> areaAssignedSUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<areaAssigned> areaAssigneds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notification> notifications { get; set; }
    }
}