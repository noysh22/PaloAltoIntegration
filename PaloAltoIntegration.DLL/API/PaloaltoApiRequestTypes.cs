using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemplify.Integrations.PaloAlto.API
{
    public enum ApiRequestTypes
    {
        KEYGEN = 0x1,
        CONFIG,
        COMMIT,
        OP,
        REPORT,
        LOG,
        IMPORT,
        EXPORT,
        //USERID, // Not supported for now 
        VERSION
    }
}
