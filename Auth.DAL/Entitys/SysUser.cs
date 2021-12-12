using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        public DateTime CreateDate { get; set; }

        public object CurrentMenu { get; set; }

        public List<Tuple<string, string ,string>> TupMenu { get; set; }
    }
}
