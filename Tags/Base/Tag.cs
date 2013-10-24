using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags.Base
{
    public abstract class Tag
    {
        protected TagBuilder tagBuilder;

        public Tag Attribute(string attributeName, string attributeValue)
        {
            tagBuilder.MergeAttribute(attributeName, attributeValue);
            return this;
        }

        public virtual HtmlString RenderHtml()
        {
            return new MvcHtmlString(string.Join("", Render()));

        }

        internal virtual IEnumerable<string> Render()
        {
            return new string[] { tagBuilder.ToString(TagRenderMode.SelfClosing) };
        }

    }
}