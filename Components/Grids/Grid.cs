using System.Collections.Generic;
using Sciendo.Common.Web.Components.Base;

namespace Sciendo.Common.Web.Components.Grids
{
    public class Grid : GridBase
    {
        public Grid Columns(IEnumerable<IGridColumn> columnDefinitions)
        {
            if (_columns == null)
                _columns = new List<IGridColumn>();
            _columns.AddRange(columnDefinitions);
            return this;
        }
        public new Grid AllowsDelete(bool enableDelete)
        {
            return base.AllowsDelete(enableDelete) as Grid;
        }
        public new Grid Id(string id)
        {
            return base.Id(id) as Grid;
        }

        public new Grid GetAction(ControllerAction controllerAction)
        {
            return base.GetAction(controllerAction) as Grid;
        }

        public new Grid EditAction(ControllerAction controllerAction)
        {
            return base.EditAction(controllerAction) as Grid;
        }
        public new Grid Caption(string caption)
        {
            return base.Caption(caption) as Grid;
        }

        public new Grid MaxRowNumber(int maxRowNumber)
        {
            return base.MaxRowNumber(maxRowNumber) as Grid;
        }

        public new Grid RowNumbersList(IEnumerable<int> rowNumbersList)
        {
            return base.RowNumbersList(rowNumbersList) as Grid;
        }

        public new Grid SortName(string sortName)
        {
            return base.SortName(sortName) as Grid;
        }
        public new Grid MultiSearch(bool multiSearch)
        {
            return base.MultiSearch(multiSearch) as Grid;
        }

        public new Grid Height(string height)
        {
            return base.Height(height) as Grid;
        }
    }
}
