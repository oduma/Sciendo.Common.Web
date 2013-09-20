using System;
using System.Collections.Generic;
using Sciendo.Common.Web.Components.Base;

namespace Sciendo.Common.Web.Components.Grids.Columns
{
    public class TextGridColumn:GridColumn
    {
        private bool _displayAsDropDown;
        private IDictionary<string, string> _lookupValues;

        public new TextGridColumn SetName(string name)
        {
            return base.SetName(name) as TextGridColumn;
        }

        public new TextGridColumn SetKey(bool isKey)
        {
            return base.SetKey(isKey) as TextGridColumn;
        }

        public new TextGridColumn SetLabel(string label)
        {
            return base.SetLabel(label) as TextGridColumn;
        }

        public new TextGridColumn SetSize(int size)
        {
            return base.SetSize(size) as TextGridColumn;
        }

        public new TextGridColumn MakeSearchable(SearchType searchType, string searchLabel)
        {
            return base.MakeSearchable(searchType, searchLabel) as TextGridColumn;
        }

        public new TextGridColumn MakeEditable(bool enableEdit)
        {
            return base.MakeEditable(enableEdit) as TextGridColumn;
        }
        
        public TextGridColumn AsDropDown(Func<IDictionary<string, string>> getLookupValues)
        {
            _displayAsDropDown = true;
            _lookupValues = getLookupValues.Invoke();
            return this;
        }

        protected override string GetEditOptions()
        {
            if(!_displayAsDropDown || _lookupValues==null || _lookupValues.Keys.Count==0)
                return string.Empty;
            return string.Format(", 'edittype':'select', 'editoptions':{0}", _lookupValues.ToOptionsJsonString());
        }
    }
}
