using Auth.Common;
using Auth.Common.Extensions;
using Auth.DAL;
using Auth.DAL.Entitys;
using Auth.DAL.ViewEntitys;
using Auth.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Auth.Service
{
    public class SysUserService : BaseService,ISysUserService
    {
        public SysUserService(MyDbContext context):base(context)
        {

        }
        public SysUser FindBy(LoginUser loginUser)
        {
            var pwd = loginUser.Password.ToMd5();
            var user = this.Query<SysUser>(r => r.Name == loginUser.Name && r.Password == pwd).FirstOrDefault();
            return user;
        }

        public bool Exist(Expression<Func<SysUser, bool>> exps)
        {
            return base.Exist<SysUser>(exps);
        }

        public bool Register(RegisterUser user)
        {
            var model = new SysUser();
            model.Name = user.Name;
            model.Password = user.Password.ToMd5();
            base.Insert<SysUser>(model);
            return true;
        }

        public PageResult<SysUserDto> Search(PageQuery query)
        {
            Expression<Func<SysUser, bool>> exps = null;
            if (!string.IsNullOrWhiteSpace(query.Search))
                exps = exps.And(r => r.Name.Contains(query.Search));

            bool isAsc = false;
            
            if (!string.IsNullOrEmpty(query.Order) && query.Order.Equals("asc"))
            {
                isAsc = true;
            }
            var pageResult = QueryPage(exps, query.PageSize, query.PageIndex, r => r.CreateDate, isAsc);

            


            return new PageResult<SysUserDto>()
            {
                Total = pageResult.Total,
                Rows = Mapper.Map<List<SysUser>, List<SysUserDto>>(pageResult.Rows)
            };
        }
    }
}
