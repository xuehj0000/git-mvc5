using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DAL.Entitys
{
    public class SysUserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="请输入用户名")]
        [StringLength(20, ErrorMessage ="用户名不能超过20个字符")]
        [Display(Name="用户名")]
        public string Name { get; set; }

        public string CreateDate { get; set; }
    }
}
