using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class SifreDegistirme
    {
        [Required]
        [DisplayName("Şimdi Şifre")]
        public string OldPassword { get; set; }
        [Required]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Şifreniz en az 5 karakter olmalı...")]
        [DisplayName("Yeni Şifre")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("NewPassword",ErrorMessage ="Şifreler aynı değil...")]
        public string ConNewPassword { get; set; }
    }
}