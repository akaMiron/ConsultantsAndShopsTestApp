//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAS.DataStorage
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblConsultant
    {
        public int cons_Id { get; set; }
        public string cons_Name { get; set; }
        public string cons_LastName { get; set; }
        public Nullable<int> cons_StoreId { get; set; }
        public Nullable<System.DateTime> cons_AssignmentDate { get; set; }
    
        public virtual tblStore tblStore { get; set; }
    }
}
