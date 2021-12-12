using Auth.DAL.Entitys;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DAL
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<SysUser, SysUserDto>().ForMember(t => t.CreateDate, t => t.MapFrom(r => r.CreateDate.ToString("yyyy-MM-dd HH:mm ss")));
        }
    }
}
