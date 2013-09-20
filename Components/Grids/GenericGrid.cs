using System;
using System.Collections.Generic;
using Sciendo.Common.Web.Components.Base;

namespace Sciendo.Common.Web.Components.Grids
{
    public class Grid<T> : GridBase
    {
        private readonly T _gridModel;

        public Grid(T gridModel)
        {
            _gridModel = gridModel;
        }

        public Grid<T>Columns(Func<T,IEnumerable<IGridColumn>> func)
        {
            if (_columns == null)
                _columns = new List<IGridColumn>();
            _columns.AddRange(func.Invoke(_gridModel));
            return this;
        }
        public new Grid<T> AllowsDelete(bool enableDelete)
        {
            return base.AllowsDelete(enableDelete) as Grid<T>;
        }
        public new Grid<T> Id(string id)
        {
            return base.Id(id) as Grid<T>;
        }

        public new Grid<T> GetAction(ControllerAction controllerAction)
        {
            return base.GetAction(controllerAction) as Grid<T>;
        }

        public new Grid<T> EditAction(ControllerAction controllerAction)
        {
            return base.EditAction(controllerAction) as Grid<T>;
        }
        public new Grid<T> Caption(string caption)
        {
            return base.Caption(caption) as Grid<T>;
        }

        public new Grid<T> MaxRowNumber(int maxRowNumber)
        {
            return base.MaxRowNumber(maxRowNumber) as Grid<T>;
        }

        public new Grid<T> RowNumbersList(IEnumerable<int> rowNumbersList)
        {
            return base.RowNumbersList(rowNumbersList) as Grid<T>;
        }

        public new Grid<T> SortName(string sortName)
        {
            return base.SortName(sortName) as Grid<T>;
        }
        public new Grid<T> MultiSearch(bool multiSearch)
        {
            return base.MultiSearch(multiSearch) as Grid<T>;
        }

        public new Grid<T> Height(string height)
        {
            return base.Height(height) as Grid<T>;
        }

    }
}
