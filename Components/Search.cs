using Sciendo.Common.Web.Components.Base;
using Sciendo.Common.Web.Styles;
using Sciendo.Common.Web.Tags;
using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Components
{
    public class Search:Component
    {
        private string _id;
        private string _title;
        private string _buttonLabel;
        private MvcHtmlString _actionUrl;
        private string _serverSideId;
        private static readonly string _valueFieldName="search_value";
        private static readonly string _actionFieldName = "search_action";
        private static readonly string _displayFieldName="display_area";
        private int _size;
        private string _formatDataClientFunction;

        public Search Id(string id)
        {
            _id = id;
            return this;
        }

        public Search Title(string title)
        {
            _title = title;
            return this;
        }

        public Search ButtonLabel(string buttonLabel)
        {
            _buttonLabel = buttonLabel;
            return this;
        }

        public Search Action(ControllerAction controllerAction)
        {
            _actionUrl = new MvcHtmlString(string.Format(@"/{0}/{1}",controllerAction.Controller,controllerAction.Action));
            return this;
        }

        public Search ServerSideId(string serverSideId)
        {
            _serverSideId = serverSideId;
            return this;
        }

        public Search SearchValueSize(int size)
        {
            _size = size;
            return this;
        }

        public Search FormatClientData(string formatDataClientFunction)
        {
            _formatDataClientFunction = formatDataClientFunction;
            return this;
        }

        internal override IEnumerable<string> Render()
        {
            var result = new List<string>();
            Div titledDiv = new Div().Id(string.Format("{0}{1}{2}",Div.TagName,"_", _id))
                .Contents(new Tag[] { new H2().Contents(_title).CssClasses(Style.Title) }).CssClasses(Style.TitleContainer);
            titledDiv.Contents(new Tag[]{
            new Input().InputType(TypeOfInput.Text).Size(_size).Id(string.Format("{0}{1}{2}",_valueFieldName,"_",_id)),
            new Input().InputType(TypeOfInput.Button).Value(_buttonLabel).Id(string.Format("{0}{1}{2}",_actionFieldName,"_",_id)),
            new P().Id(string.Format("{0}{1}{2}",_displayFieldName,"_",_id))});
            _contents = new List<Tag>();
            _contents.Add(titledDiv);
            result.AddRange(AddContents());
            return result;
        }


        public override string InitializeJavaScript()
        {
            var subComponentsInitialize = base.InitializeJavaScript();
            var thisComponentInitialize = @"components.SearchClient('" + _actionUrl + "', '" + _id + "', '" +
                                          _serverSideId + "'" +
                                          ((string.IsNullOrEmpty(_formatDataClientFunction))
                                               ? ""
                                               : " ," + _formatDataClientFunction) +
                                          ");";
            return string.Format("{0}{1}{2}",subComponentsInitialize,Environment.NewLine,thisComponentInitialize);

        }
    }
}
