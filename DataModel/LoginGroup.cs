//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginGroup
    {
        public int LoginGroupID { get; set; }
        public int GroupID { get; set; }
        public int LoginID { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual Login Login { get; set; }
    }
}
