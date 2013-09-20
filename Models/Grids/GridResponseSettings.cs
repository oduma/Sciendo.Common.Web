using System.Collections.Generic;

namespace Sciendo.Common.Web.Models.Grids
{
    public class GridResponseSettings<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int TotalNumberOfRecords { get; set; }
    }
}
