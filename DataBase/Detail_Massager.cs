//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Detail_Massager
    {
        public int Id_Detail_Massager { get; set; }
        public string costume { get; set; }
        public Nullable<System.DateTime> date_of_birth { get; set; }
        public Nullable<int> id_massager { get; set; }
    
        public virtual Massager Massager { get; set; }
    }
}
