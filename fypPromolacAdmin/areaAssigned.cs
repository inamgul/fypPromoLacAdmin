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
    
    public partial class areaAssigned
    {
        public int vendorId { get; set; }
        public int areaId { get; set; }
        public int assignedId { get; set; }
    
        public virtual area area { get; set; }
        public virtual vendor vendor { get; set; }
    }
}
