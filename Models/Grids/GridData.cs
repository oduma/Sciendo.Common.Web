using System;
using System.Collections.Generic;
using System.Linq;

namespace Sciendo.Common.Web.Models.Grids
{
    public class GridData<T>
    {
        public GridData(int page, int total, int records)
        {
            this.page = page;
            this.total = total;
            this.records = records;
        }

        public int page { get; private set; }

        public int total { get; private set; }

        public int records { get; private set; }

        public IEnumerable<IEnumerable<string>> rows { get; private set; }

        public void LoadRows(IEnumerable<T> elements, Func<T, IEnumerable<string>> transformForUi)
        {
            rows = elements.Select(transformForUi);
        }
    }
}
