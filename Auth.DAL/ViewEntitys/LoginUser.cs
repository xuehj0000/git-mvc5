using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DAL.ViewEntitys
{
    public class LoginUser
    {
        [Required(ErrorMessage = "请输入用户名")]
        [StringLength(20, ErrorMessage = "用户名不能超过20个字符")]
        public string Name { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        [StringLength(64, ErrorMessage = "密码不能超过64个字符")]
        public string Password { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "请输入验证码")]
        public string CheckCode { get; set; }

        public bool Remember { get; set; }
    }
}
