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
    
    public partial class userPackage
    {
        public int vendorId { get; set; }
        public int packageId { get; set; }
        public System.DateTime packageStartTime { get; set; }
    
        public virtual package package { get; set; }
        public virtual vendor vendor { get; set; }
    }
}
