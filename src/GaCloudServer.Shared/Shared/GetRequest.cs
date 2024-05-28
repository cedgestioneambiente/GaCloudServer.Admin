using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Shared
{
    public class GetRequest
    {
        //
        // Riepilogo:
        //     Gets or sets the expand. (Use Pascal case properties names)
        //
        // Valore:
        //     The expand.
        public string Expand { get; set; }

        //
        // Riepilogo:
        //     Gets or sets the format.
        //
        // Valore:
        //     The format. (json | export)
        public string Format { get; set; }
    }
}
