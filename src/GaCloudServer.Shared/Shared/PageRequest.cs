namespace GaCloudServer.Shared
{
    public class PageRequest : GetRequest
    {
        //
        // Riepilogo:
        //     Gets or sets the number of items to take. Default value is 1000.
        public int? Take { get; set; }

        //
        // Riepilogo:
        //     Gets or sets the number of items to skip
        public int? Skip { get; set; }

        //
        // Riepilogo:
        //     Gets or sets the order expression. (Use Pascal case properties names)
        public string OrderBy { get; set; }

        //
        // Riepilogo:
        //     Gets or sets the filter. (Use Pascal case properties names)
        //
        // Valore:
        //     The filter.
        public string Filter { get; set; }

        //
        // Riepilogo:
        //     Gets or sets the select. (Use Pascal case properties names)
        //
        // Valore:
        //     The select.
        public string Select { get; set; }
    }
}
