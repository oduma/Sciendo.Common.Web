using System.Collections.Generic;
using Sciendo.Common.Web.Components.Base;
using Sciendo.Common.Web.Tags;
using Sciendo.Common.Web.Tags.Base;

namespace Sciendo.Common.Web.Components
{
    public class ErrorDisplayer:Component
    {
        private const string _errorDisplayFieldName = "error_display";

        protected string _baseId { get; private set; }

        public string Id { get; private set; }
        internal override IEnumerable<string> Render()
        {
            _contents=new List<Tag>{new P().Id(Id)};
            return AddContents();
        }

        internal ErrorDisplayer GenerateId (string id)
        {
            _baseId = id;
            Id = _errorDisplayFieldName + "_" + id;
            return this;
        }
    }
}
