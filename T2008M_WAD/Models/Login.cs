using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T2008M_WAD.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Vui lòng nhập Email!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập password!")]
        public string Password { get; set; }
    }
}