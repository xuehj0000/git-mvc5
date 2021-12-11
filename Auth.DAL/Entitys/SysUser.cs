using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DAL
{
    [Table("SysUser")]
    public class SysUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }
    }
}
