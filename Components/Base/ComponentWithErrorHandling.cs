using System.Collections.Generic;
using Sciendo.Common.Web.Tags.Base;

namespace Sciendo.Common.Web.Components.Base
{
    public abstract class ComponentWithErrorHandling:Component
    {

        protected ErrorDisplayer _errorDisplayer;

        protected ComponentWithErrorHandling DisplayErrorUsing(ErrorDisplayer errorDisplayer)
        {
            _errorDisplayer = errorDisplayer;
            return this;
        }

        protected override IEnumerable<string> AddContents()
        {
            List<string> result = new List<string>();
            foreach (var content in _contents)
            {
                if (content is TagWithContents)
                    result.AddRange(((TagWithContents)content).Render());
                else
                    result.AddRange(content.Render());
            }
            if(_errorDisplayer!=null)
                result.AddRange(_errorDisplayer.Render());
            return result;
        }
    }
}
