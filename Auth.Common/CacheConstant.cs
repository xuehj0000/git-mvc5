using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Common
{
    public class CacheConstant
    {
        /// <summary>
        /// 当前用户的面包屑
        /// </summary>
        /// <returns></returns>
        public static string CacheCurrentCrumbs() => $"CurrentCrumbs";
    }
}
