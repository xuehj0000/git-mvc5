using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DAL.ViewEntitys
{
    public class MenuDto
    {
        public MenuDto()
        {
            this.ChildMenu = new List<MenuDto>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int Level { get; set; }

        public int Type { get; set; }

        public string Icon { get; set; }

        public string Memo { get; set; }

        public int Sort { get; set; }

        public List<MenuDto> ChildMenu { get; set; }
    }
}
