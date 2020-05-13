using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace fypPromolacAdmin.Models
{
    public class areaAssignedModel
    {
        [Key, Column(Order = 0)]
        public int vendorId { get; set; }
        [Key, Column(Order = 1)]
        public int areaId { get; set; }

        
        public int assignedId { get; set; }
        [NotMapped]
        public string areaNames { get; set; }
        public virtual area area { get; set; }
        public virtual vendor vendor { get; set; }
    }
}