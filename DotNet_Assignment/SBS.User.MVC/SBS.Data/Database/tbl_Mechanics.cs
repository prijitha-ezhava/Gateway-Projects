//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SBS.Data.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Mechanics
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Mechanics()
        {
            this.tbl_Services = new HashSet<tbl_Services>();
        }
    
        public int ID { get; set; }
        public string MecName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string Make { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Services> tbl_Services { get; set; }
    }
}