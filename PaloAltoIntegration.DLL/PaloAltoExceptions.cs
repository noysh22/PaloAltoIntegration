using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemplify.Integrations.PaloAlto
{
    public class PaloAltoException : Exception
    {
        public PaloAltoException() { }
        public PaloAltoException(string message) : base(message) { }
        public PaloAltoException(string message, Exception innerEx) : base(message, innerEx) { }
    }
}
