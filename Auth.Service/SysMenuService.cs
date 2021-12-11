using Auth.DAL;
using Auth.DAL.Entitys;
using Auth.DAL.ViewEntitys;
using Auth.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Service
{
    public class SysMenuService : BaseService,ISysMenuService
    {
        public SysMenuService(MyDbContext context) : base(context)
        {

        }


        public List<MenuDto> GetSubMenu(int userId, out List<Tuple<string, string, string>> outList)
        {
            var list = this.Query<SysMenu>().ToList();
            var result = new List<MenuDto>();
            outList = list.Select(r => new Tuple<string, string, string>(r.Id.ToString(), r.Name, r.Url)).ToList();
            var menus = GetSubMenuList(list, 0, result);
            return result;
        }


        private List<MenuDto> GetSubMenuList(List<SysMenu> subList, int parentId, List<MenuDto> outList)
        {
            var nextList = subList.Where(r => r.ParentId == parentId);
            foreach(var item in nextList)
            {
                var model = new MenuDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Url = item.Url,
                    Icon = item.Icon,
                    Level = item.Level,
                    Type = item.Type,
                    Memo = item.Memo,
                    Sort = item.Sort
                };
                var nextSubList = subList.Where(r => r.ParentId != parentId).ToList();
                GetSubMenuList(nextSubList, item.Id, model.ChildMenu);
                outList.Add(model);
            }
            return outList;
        }
    }
}
