using System.Collections.Generic;
using Sciendo.Common.Web.Components.Base;

namespace Sciendo.Common.Web.Components.Grids.Columns
{
    public class BooleanColumn:GridColumn
    {
        private bool _displayAsCheckbox;

        public new BooleanColumn SetName(string name)
        {
            return base.SetName(name) as BooleanColumn;
        }

        public new BooleanColumn SetKey(bool isKey)
        {
            return base.SetKey(isKey) as BooleanColumn;
        }

        public new BooleanColumn SetLabel(string label)
        {
            return base.SetLabel(label) as BooleanColumn;
        }

        public new BooleanColumn SetSize(int size)
        {
            return base.SetSize(size) as BooleanColumn;
        }

        public new BooleanColumn MakeSearchable(SearchType searchType, string searchLabel)
        {
            return base.MakeSearchable(searchType, searchLabel) as BooleanColumn;
        }

        public new BooleanColumn MakeEditable(bool enableEdit)
        {
            return base.MakeEditable(enableEdit) as BooleanColumn;
        }

        public BooleanColumn AsCheckbox()
        {
            _displayAsCheckbox = true;
            return this;
        }

        protected override string GetEditOptions()
        {
            if (!_displayAsCheckbox)
                return string.Empty;
            return string.Format(", 'edittype':'checkbox', 'editoptions':{0}", new Dictionary<string, string>{{"Yes","No"}}.ToOptionsJsonString());
        }
    }
}
