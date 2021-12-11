using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DAL.ViewEntitys
{
    public class RegisterUser
    {
        [Required(ErrorMessage ="用户名称不能为空")]
        [StringLength(20, ErrorMessage ="名称不能超过20个字符")]
        public string Name { get; set; }

        [Required(ErrorMessage ="密码不能为空")]
        [StringLength(64, ErrorMessage ="密码不能超过64个字符")]
        public string Password { get; set; }

        [Required(ErrorMessage ="确认密码不能为空")]
        [StringLength(64, ErrorMessage = "确认密码不能超过64个字符")]
        public string NewPassword { get; set; }


    }
}
