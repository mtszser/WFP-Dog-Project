//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_Projekt
{
    using System;
    using System.Collections.Generic;
    
    public partial class Highscore
    {
        public int Id { get; set; }
        public int Dog_id { get; set; }
        public int Total { get; set; }
    
        public virtual Dog Dog { get; set; }
    }
}
