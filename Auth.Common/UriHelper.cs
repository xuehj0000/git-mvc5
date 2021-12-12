using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Common
{
    public class UriHelper
    {
        public static string GetUrlParameterValue(string url, string parameter)
        {
            if (string.IsNullOrEmpty(url))
            {
                return string.Empty;
            }
            var index = url.IndexOf("?");
            if (index > -1)
            {
                index++;
                var targetUrl = url.Substring(index, url.Length - index);
                string[] Params = targetUrl.Split('&');
                foreach(var item in Params)
                {
                    var values = item.Split('=');
                    if (values[0].ToLower().Equals(parameter.ToLower()))
                    {
                        return values[1];
                    }
                }
            }
            return null;
        }
    }
}
