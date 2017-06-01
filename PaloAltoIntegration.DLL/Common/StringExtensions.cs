using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemplify.Integrations.PaloAlto.Common
{
    public static class StringExtensions
    {
        public static KeyValuePair<string, object> PairWith(this string key, object value)
        {
            return new KeyValuePair<string, object>(key, value);
        }

        public static KeyValuePair<string, object> PairWith(this string key, string value)
        {
            return new KeyValuePair<string, object>(key, value);
        }
    }
}
