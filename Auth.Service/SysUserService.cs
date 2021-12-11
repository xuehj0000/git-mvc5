using Auth.Common;
using Auth.DAL;
using Auth.DAL.ViewEntitys;
using Auth.Interface;
using System;
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
    }
}
