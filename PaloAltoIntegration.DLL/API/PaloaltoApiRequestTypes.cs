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
        //USERID, // Not supported for now translated to user-id
        VERSION
    }

    public enum ApiActionTypes
    {
        // Read action types
        SHOW = 0x1,
        GET,
        
        // Modifying action types
        SET,
        EDIT,
        DELETE,
        RENAME,
        CLONE,
        MOVE,
        OVERRIDE,
        //MULTIMOVE, // Not supported for now translated to multi-move
        //MULTICLONE, // Not supported for now translated to multi-clone
        COMPLETE,
    }
}
