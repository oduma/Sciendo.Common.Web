using System;
using Sciendo.Common.Web.Components.Base;

namespace Sciendo.Common.Web.Components.Grids.Columns
{
    public static class GridColumnDefintions
    {
        public static GridColumn CreateColumnFor(int property)
        {
            return new GridColumn();
        }

        public static GridColumn CreateColumnFor(int? property)
        {
            return new GridColumn();
        }

        public static GridColumn CreateColumnFor(decimal property)
        {
            return new GridColumn();
        }

        public static GridColumn CreateColumnFor(decimal? property)
        {
            return new GridColumn();
        }

        public static TextGridColumn CreateColumnFor(string property)
        {
            return new TextGridColumn();
        }

        public static DateGridColumn CreateColumnFor(DateTime property)
        {
            return new DateGridColumn();
        }

        public static DateGridColumn CreateColumnFor(DateTime? property)
        {
            return new DateGridColumn();
        }

        public static BooleanColumn CreateColumn(bool property)
        {
            return new BooleanColumn();
        }

        public static BooleanColumn CreateColumn(bool? property)
        {
            return new BooleanColumn();
        }
    }
}
