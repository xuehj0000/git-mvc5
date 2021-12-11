using Auth.DAL;
using Auth.DAL.ViewEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Interface
{
    public interface ISysUserService:IBaseService
    {
        SysUser FindBy(LoginUser loginUser);

        bool Exist(Expression<Func<SysUser, bool>> exps);

        bool Register(RegisterUser user);
    }
}
