using Sciendo.Common.Web.Components.Base;
using Sciendo.Common.Web.Tags;
using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Components
{
    public class AsynchUl:Component
    {
        private const string _idPrefix="asynch_ul";
        private string _id;
        private string _successClientHandler;
        private string _failClientHandler;
        private MvcHtmlString _actionUrl;
        private string _controllerParams;

        public AsynchUl Id(string id)
        {
            _id = id;
            return this;
        }

        internal override IEnumerable<string> Render()
        {
            Ul ul = new Ul().Id(string.Format("{0}{1}{2}",_idPrefix,"_",_id));

            var result = new List<string>();
            _contents = new List<Tag>();
            _contents.Add(ul);
            result.AddRange(AddContents());
            return result;
        }

        public AsynchUl Action(ControllerAction controllerAction)
        {
            _actionUrl = new MvcHtmlString(string.Format(@"/{0}/{1}", controllerAction.Controller, controllerAction.Action));
            return this;
        }

        public AsynchUl Params(params string[] controllerParams)
        {
            //For the moment
            _controllerParams = controllerParams[0];
            return this;
        }

        public AsynchUl SuccessCallbackMethod(string jsMethodName)
        {
            _successClientHandler = jsMethodName;
            return this;
        }

        public AsynchUl FailCallbackMethod(string jsMethodName)
        {
            _failClientHandler = jsMethodName;
            return this;
        }
        public override string InitializeJavaScript()
        {
            var subComponentsInitialize = base.InitializeJavaScript();
            var thisComponentInitialize = @"components.AddNewAsynchUl(0,'" + _actionUrl + "', '" + 
                                            _id + "', '" + _controllerParams + "'"+
                                          ((string.IsNullOrEmpty(_successClientHandler))
                                               ? ""
                                               : " ," + _successClientHandler) +
                                          ((string.IsNullOrEmpty(_failClientHandler)) ? "" : " ," + _failClientHandler) +
                                          ");";
            return string.Format("{0}{1}{2}", subComponentsInitialize, Environment.NewLine, thisComponentInitialize);
        }
    }
}
