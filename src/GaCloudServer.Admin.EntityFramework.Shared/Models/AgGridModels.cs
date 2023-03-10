using System.Collections.Generic;


namespace GaCloudServer.Admin.EntityFramework.Shared.Models
{
    public class SortModel
    {
        public string colId { get; set; }
        public string sort { get; set; }
    }

    public class FilterParamSortDto
    {
        public string ColId { get; set; }

        public string Sort { get; set; }
    }

    public class FilterModel
    {
        public FilterModel condition1 { get; set; }
        public FilterModel condition2 { get; set; }

        public string Operator { get; set; }
        
        public string type { get; set; }
        private string _filter { get; set; }
        public object filter { get { return _filter; } set { _filter = value.ToString().Split(":")[0].ToString(); } }
        public string filterTo { get; set; }
        //public DateTime? dateFrom { get; set; }
        //public DateTime? dateTo { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
        public string filterType { get; set; }
    }

    public class GridOperationsModel
    {
        public int startRow { get; set; }
        public int endRow { get; set; }
        public SortModel[] sortModel { get; set; }
        public Dictionary<string, FilterModel> filterModel { get; set; }
        public string quickFilter { get; set; }
    }

    public class FilterRequestModel
    {
        public int StartRow { get; set; }

        public int EndRow { get; set; }

        public IEnumerable<SortModel> SortModel { get; set; }
    }
}
