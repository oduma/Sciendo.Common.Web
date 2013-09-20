using Sciendo.Common.Web.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sciendo.Common.Web.Components.Base;

namespace Sciendo.Common.Web.Tags.Base
{
    public class TagWithContents:TagWithIdAndCss
    {

        protected string InnerText { get; set; }


        internal bool HasSubTags { get { return _contents != null && _contents.Any(); } }

        protected List<Tag> _contents;

        protected TagWithContents Contents(string contents)
        {
            InnerText = contents;
            return this;
        }

        protected TagWithContents Contents(IEnumerable<Tag> contents)
        {
            if (_contents == null)
                _contents = new List<Tag>();
            _contents.AddRange(contents);
            return this;
        }

        private IEnumerable<string> AddContents()
        {
            List<string> result = new List<string>();
            if (!HasSubTags)
                return new string[] { InnerText };
            else if (_contents != null)
                foreach (var content in _contents)
                {
                    if (content is TagWithContents)
                        result.AddRange(((TagWithContents)content).Render());
                    else if (content is Component)
                        result.AddRange(((Component)content).Render());
                    else
                        result.AddRange(content.Render());
                }

            return result;
        }


        internal new IEnumerable<string> Render()
        {
            var result = new List<string>();
            if(tagBuilder!=null)
                result.Add(tagBuilder.ToString(TagRenderMode.StartTag));
            result.AddRange(AddContents());
            if(tagBuilder!=null)
                result.Add(tagBuilder.ToString(TagRenderMode.EndTag));
            return result;
        }

        public override HtmlString RenderHtml()
        {
            return new MvcHtmlString(string.Join("", Render()));

        }
 
    }
}