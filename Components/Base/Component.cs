using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sciendo.Common.Web.Tags.Base;

namespace Sciendo.Common.Web.Components.Base
{
    public abstract class Component:Tag
    {
        protected List<Tag> _contents;

        internal List<Component> SubComponents; 

        protected Component Contents(IEnumerable<Tag> contents)
        {
            if (_contents == null)
                _contents = new List<Tag>();
            _contents.AddRange(contents);
            return this;
        }

        protected IEnumerable<string> AddContents()
        {
            List<string> result = new List<string>();
            foreach (var content in _contents)
            {
                if (content is TagWithContents)
                    result.AddRange(((TagWithContents)content).Render());
                else
                    result.AddRange(content.Render());
            }

            return result;
        }


        internal new abstract IEnumerable<string> Render();

        public override HtmlString RenderHtml()
        {
            return new MvcHtmlString(string.Join("", Render()));

        }
 

        public virtual string InitializeJavaScript()
        {
            if(SubComponents==null)
                return string.Empty;
            return string.Join("",SubComponents.Select(s=>s.InitializeJavaScript()));
        }
    }
}
