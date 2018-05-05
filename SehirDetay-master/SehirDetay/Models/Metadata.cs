using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SehirDetay.Models
{



    public class KullaniciMetadata
    {
        [Required(ErrorMessage ="Bu alan gereklidir")]
        public string Eposta;

        [Required(ErrorMessage = "Bu alan gereklidir")]
        public string Ad;

        [Required(ErrorMessage = "Bu alan gereklidir")]
        public string Soyad;

       

    }

    public class KategoriMetadata
    {

    }























    /*
    public class KullaniciMetadata
    {
        [StringLength(50 , ErrorMessage ="En fazla 50 karakter girilmelidir.")]
        [Required(ErrorMessage = "Bu alan gereklidir")]
        [Display(Name = "Adı")]
        public string Ad;

        [StringLength(50, ErrorMessage = "En fazla 50 karakter girilmelidir.")]
        [Required(ErrorMessage = "Bu alan gereklidir")]
        [Display(Name = "Soyadı")]
        public string Soyad;


    }

    */



}