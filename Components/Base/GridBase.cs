using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Sciendo.Common.Web.Tags;
using Sciendo.Common.Web.Tags.Base;

namespace Sciendo.Common.Web.Components.Base
{
    public abstract class GridBase : Component
    {
        private string _id;
        private MvcHtmlString _getActionUrl;
        protected List<IGridColumn> _columns;
        private string _caption;
        private int _maxRowNumber;
        private string _sortName;
        private IEnumerable<int> _rowNumbersList;
        private bool _multiSearch;
        private bool _enableEdit;
        private bool _enableAdd;
        private bool _enableDelete;
        private MvcHtmlString _editActionUrl;
        private const int _defaultMaxRowNumber = 10;
        protected readonly string _pagerPrefix = "simple_grd_pager";
        protected readonly string _gridPrefix = "simple_grd";
        private string _height;

        internal override IEnumerable<string> Render()
        {
            var result = new List<string>();
            _contents = new List<Tag>();
            _contents.AddRange(new Tag[]
                                   {
                                       new Table().Id(string.Format("{0}{1}{2}", _gridPrefix, "_", _id)),
                                       new Div().Id(string.Format("{0}{1}{2}", _pagerPrefix, "_", _id))
                                   });
            result.AddRange(AddContents());
            return result;
        }

        public GridBase AllowsDelete(bool enableDelete)
        {
            _enableDelete = enableDelete;
            return this;
        }
        public GridBase Id(string id)
        {
            _id = id;
            return this;
        }

        public GridBase GetAction(ControllerAction controllerAction)
        {
            _getActionUrl = new MvcHtmlString(string.Format(@"/{0}/{1}", controllerAction.Controller, controllerAction.Action));
            return this;
        }

        public GridBase EditAction(ControllerAction controllerAction)
        {
            _editActionUrl = new MvcHtmlString(string.Format(@"/{0}/{1}", controllerAction.Controller, controllerAction.Action));
            return this;
        }
        public GridBase Caption(string caption)
        {
            _caption = caption;
            return this;
        }

        public GridBase MaxRowNumber(int maxRowNumber)
        {
            _maxRowNumber = maxRowNumber;
            return this;
        }

        public GridBase RowNumbersList(IEnumerable<int> rowNumbersList)
        {
            _rowNumbersList = rowNumbersList;
            return this;
        }

        public GridBase SortName(string sortName)
        {
            _sortName = sortName;
            return this;
        }
        public GridBase MultiSearch(bool multiSearch)
        {
            _multiSearch = multiSearch;
            return this;
        }
        public GridBase Height(string height)
        {
            _height = height;
            return this;
        }
        public override string InitializeJavaScript()
        {
            var subComponentsInitialize = base.InitializeJavaScript();
            var thisComponentInitialize =
                string.Format(
                    @"components.SimpleGrid('{0}', '{1}', {2}, {3}, {4}, {5}, '{6}', '{7}', {8}, {9}, {10},{11},'{12}','{13}');",
                    _getActionUrl, _id, RenderColumnNames(), RenderColumnDefinitions(),
                    ((_maxRowNumber == 0) ? _defaultMaxRowNumber : _maxRowNumber),
                    RenderRowNumberList(), _sortName, _caption, _multiSearch.ToString().ToLower(),
                    _enableEdit.ToString().ToLower(), _enableAdd.ToString().ToLower(),
                    _enableDelete.ToString().ToLower(), _editActionUrl,_height);
            return string.Format("{0}{1}{2}", subComponentsInitialize, Environment.NewLine, thisComponentInitialize);
        }

        private string RenderRowNumberList()
        {
            return string.Format("[{0}]", string.Join(", ", _rowNumbersList.Select(r => r.ToString())));
        }

        private string RenderColumnDefinitions()
        {
            var temp = new StringBuilder("");
            foreach (var column in _columns)
            {
                temp = temp.Append(column.GetJsonStringDefinition());
            }
            return string.Format("[{0}]", temp.Remove(temp.Length - 1, 1));
        }

        private string RenderColumnNames()
        {
            return string.Format("[{0}]", string.Join(",", _columns.Select(c => string.Format("'{0}'", c.Label))));
        }
    }
}
