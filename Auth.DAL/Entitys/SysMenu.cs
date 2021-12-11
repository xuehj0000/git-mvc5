using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DAL.Entitys
{
    [Table("SysMenu")]
    public class SysMenu
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int Level { get; set; }

        public int Type { get; set; }

        public string Icon { get; set; }

        public int Sort { get; set; }

        public int Status { get; set; }

        public string Memo { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
