using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Common
{
    public class PageQuery
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Order { get; set; }
        public string Sort { get; set; }
        public string Search { get; set; }
    }
}
