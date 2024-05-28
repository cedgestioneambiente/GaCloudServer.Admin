using System.Collections.Generic;

namespace GaCloudServer.Shared
{
    public class PageResponse<T>
    {
        //
        // Riepilogo:
        //     Gets or sets page items
        public IEnumerable<T> Items { get; set; }

        //
        // Riepilogo:
        //     Gets or sets total number of items
        public int Count { get; set; }
    }
}
