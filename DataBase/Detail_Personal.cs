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
    
    public partial class Detail_Personal
    {
        public int Id_Detail_Personal { get; set; }
        public string salon { get; set; }
        public Nullable<System.DateTime> date_of_birth { get; set; }
        public string frequently_chosen_massage { get; set; }
        public Nullable<int> id_personal { get; set; }
    
        public virtual Personal Personal { get; set; }
    }
}
