//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SehirDetay.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class IcerikMedya
    {
        public long Id { get; set; }
        public long IcerikId { get; set; }
        public long MedyaId { get; set; }
    
        public virtual Icerik Icerik { get; set; }
        public virtual Medya Medya { get; set; }
    }
}
