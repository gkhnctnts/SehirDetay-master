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
    
    public partial class Icerik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Icerik()
        {
            this.Ulasim = new HashSet<Ulasim>();
            this.Yorum = new HashSet<Yorum>();
            this.IcerikMedya = new HashSet<IcerikMedya>();
        }
    
        public long Id { get; set; }
        public string Baslik { get; set; }
        public string Detay { get; set; }
        public int KategoriId { get; set; }
        public int KullaniciId { get; set; }
        public System.DateTime OlusturulmaTarihi { get; set; }
        public System.DateTime GuncellenmeTarihi { get; set; }
        public string AnahtarKelimeler { get; set; }
        public bool Aktif { get; set; }
        public System.Data.Entity.Spatial.DbGeography Konum { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
    
        public virtual Ilce Ilce { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual Sehir Sehir { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ulasim> Ulasim { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorum> Yorum { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IcerikMedya> IcerikMedya { get; set; }
    }
}
