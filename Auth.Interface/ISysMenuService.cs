using Auth.DAL.ViewEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Interface
{
    public interface ISysMenuService:IBaseService
    {
        List<MenuDto> GetSubMenu(int userId, out List<Tuple<string, string, string>> list);
    }
}
