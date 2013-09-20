using System;
using Newtonsoft.Json;
using Sciendo.Common.Web.Components.Base;
using Sciendo.Common.Web.Models;
using Sciendo.Common.Web.Models.Configuration;
using Sciendo.Common.Web.Styles;
using Sciendo.Common.Web.Tags;
using Sciendo.Common.Web.Tags.Base;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Components
{
    public class EntryFormFor<TModel>:Component where TModel:ModelBase, new()
    {
        private ModelConfigurationBase<TModel> _modelConfiguration;
        private string _id;
        private string _title;
        private string _buttonLabel;
        private MvcHtmlString _actionUrl;
        private static readonly string _actionFieldName = "entryForm_action";
        private string _failClientHandler;
        private string _successClientHandler;


        public EntryFormFor(ModelConfigurationBase<TModel> modelConfiguration)
        {
            _modelConfiguration = modelConfiguration;
        }

        public EntryFormFor<TModel> Id(string id)
        {
            _id = id;
            return this;
        }

        public EntryFormFor<TModel> Title(string title)
        {
            _title = title;
            return this;
        }

        public EntryFormFor<TModel> ButtonLabel(string buttonLabel)
        {
            _buttonLabel = buttonLabel;
            return this;
        }

        public EntryFormFor<TModel> Action(ControllerAction controllerAction)
        {
            _actionUrl = new MvcHtmlString(string.Format(@"/{0}/{1}", controllerAction.Controller, controllerAction.Action));
            return this;
        }

        public EntryFormFor<TModel> SuccessCallbackHandler(string clientHandler)
        {
            _successClientHandler = clientHandler;
            return this;
        }

        public EntryFormFor<TModel> FailCallbackHandler(string clientHandler)
        {
            _failClientHandler = clientHandler;
            return this;
        }

        internal override IEnumerable<string> Render()
        {
            var result = new List<string>();
            Div titledDiv = new Div().Id(string.Format("{0}{1}{2}", Div.TagName, "_", _id))
                .Contents(new Tag[] { new H2().Contents(_title).CssClasses(Style.Title) }).CssClasses(Style.TitleContainer);
            var contents = _modelConfiguration.RenderModel(this);
            titledDiv.Contents(new Tag[]{new Div().Id(string.Format("{0}{1}{2}", Div.TagName, "_inner_", _id)).Contents(contents),
            new Input().InputType(TypeOfInput.Button).Value(_buttonLabel).Id(string.Format("{0}{1}{2}",_actionFieldName,"_",_id)).CssClasses(Style.BottomButton)});
            _contents = new List<Tag>();
            _contents.Add(titledDiv);
            result.AddRange(AddContents());
            return result;
        }

        public override string InitializeJavaScript()
        {
            var subComponentsInitialize = base.InitializeJavaScript();
            var thisComponentInitialize = @"components.EntryFormClient('" + _actionUrl + "', '" + _id + "', '" +
                                          RenderClientModel() +
                                          "'" +
                                          ((string.IsNullOrEmpty(_successClientHandler))
                                               ? ""
                                               : " ," + _successClientHandler) +
                                          ((string.IsNullOrEmpty(_failClientHandler)) ? "" : " ," + _failClientHandler) +
                                          ");";
            return string.Format("{0}{1}{2}",subComponentsInitialize,Environment.NewLine,thisComponentInitialize);
        }

        private string RenderClientModel()
        {
            var clientModel = _modelConfiguration.BuildClientModel();
            return JsonConvert.SerializeObject(clientModel);
        }
    }
}
