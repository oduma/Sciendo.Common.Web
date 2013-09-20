using Sciendo.Common.Web.Controllers.Grids;

namespace Sciendo.Common.Web.Models.Grids
{
    public class GridRequestSettings
    {
        public int CurrentPage { get; set; }

        public int RowsPerPage { get; set; }

        public string SortColumn { get; set; }

        public string SortOrder { get; set; }

        public Filters Where { get; set; }
    }
}
