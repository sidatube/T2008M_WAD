using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T2008M_WAD.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage ="Vui lòng điền Họ và Tên!")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Vui lòng điền Email!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Vui lòng nhập đúng định dạng email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Vui long nhập mật khẩu!")]
        public string Password { get; set; }



    }
}