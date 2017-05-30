using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemplify.Integrations.PaloAlto.Common
{
    public static class StringExtensions
    {
        public static KeyValuePair<string, string> PairWith(this string key, string value)
        {
            return new KeyValuePair<string, string>(key, value);
        }
    }
}
