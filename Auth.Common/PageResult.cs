using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Common
{
    public class PageResult<T>:AjaxResult
    {
        public PageResult()
        {
            Rows = new List<T>();
        }
        public int Total { get; set; }
        public List<T> Rows { get; set; }
    }


    public class AjaxResult
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
