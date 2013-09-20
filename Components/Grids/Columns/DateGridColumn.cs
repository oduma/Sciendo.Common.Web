using Sciendo.Common.Web.Components.Base;

namespace Sciendo.Common.Web.Components.Grids.Columns
{
    public class DateGridColumn:GridColumn
    {
        private bool _displayAsDatePicker;
        private string _dateFormat;

        public new DateGridColumn SetName(string name)
        {
            return base.SetName(name) as DateGridColumn;
        }

        public new DateGridColumn SetKey(bool isKey)
        {
            return base.SetKey(isKey) as DateGridColumn;
        }

        public new DateGridColumn SetLabel(string label)
        {
            return base.SetLabel(label) as DateGridColumn;
        }

        public new DateGridColumn SetSize(int size)
        {
            return base.SetSize(size) as DateGridColumn;
        }

        public new DateGridColumn MakeSearchable(SearchType searchType, string searchLabel)
        {
            return base.MakeSearchable(searchType, searchLabel) as DateGridColumn;
        }

        public new DateGridColumn MakeEditable(bool enableEdit)
        {
            return base.MakeEditable(enableEdit) as DateGridColumn;
        }

        public DateGridColumn AsDatePicker(string dateFormat)
        {
            _displayAsDatePicker = true;
            _dateFormat = dateFormat;
            return this;
        }

        protected override string GetEditOptions()
        {
            if (!_displayAsDatePicker)
                return string.Empty;
            return string.Format(", 'editoptions':{0}", GetDatePicker());
        }

        private string GetDatePicker()
        {
            return @"{size:20, dataInit:function(el){$(el).datepicker({dateFormat:'" +
                   (string) ((string.IsNullOrEmpty(_dateFormat)) ? "yy-mm-dd" : _dateFormat) + "'});}}";
        }
    }
}
