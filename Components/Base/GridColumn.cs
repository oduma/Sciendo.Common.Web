using System.Text;

namespace Sciendo.Common.Web.Components.Base
{
    public class GridColumn : IGridColumn
    {
        private SearchType _searchType;
        private bool _key;
        private string _searchLabel;
        public string Label { get; private set; }
        private string _name;
        private int _size;
        private bool _enableEdit;

        public GridColumn SetName(string name)
        {
            _name = name;
            return this;
        }

        public GridColumn SetKey(bool isKey)
        {
            _key = isKey;
            return this;
        }

        public GridColumn SetLabel(string label)
        {
            Label = label;
            return this;
        }

        public GridColumn SetSize(int size)
        {
            _size = size;
            return this;
        }

        public GridColumn MakeSearchable(SearchType searchType, string searchLabel)
        {
            _searchType = searchType;
            _searchLabel = searchLabel;
            return this;
        }

        public GridColumn MakeEditable(bool enableEdit)
        {
            _enableEdit = enableEdit;
            return this;
        }

        public string GetJsonStringDefinition()
        {
            StringBuilder temp= new StringBuilder("");
            temp.Append("{");
            temp.AppendFormat("'name':'{0}'", _name);
            if (_key)
                temp.AppendFormat(" ,'key':'{0}'", _key);
            temp.AppendFormat(" ,'width':'{0}'", _size);
            if (_searchType != SearchType.NoSearch)
            {
                temp.AppendFormat(
                    " ,'search':true, 'stype':'{0}'", _searchType.ToString().ToLower());
                temp.Append(" ,searchoptions: {attr:{");
                temp.AppendFormat("title:'Search for {0}'", _searchLabel);
                temp.Append("}}");
            }
            if (_enableEdit)
            {
                    temp.Append(",'editable':true" + GetEditOptions());
            }
            temp.Append("},");
            return temp.ToString();
        }

        protected virtual string GetEditOptions()
        {
            return string.Empty;
        }
    }
}
