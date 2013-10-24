using System.Collections.Generic;
using System.Web.Mvc;
using Sciendo.Common.Web.Tags.Base;

namespace Sciendo.Common.Web.Tags
{
    public class Span:TagWithContents
    {
        public readonly static string TagName="span";
        public Span()
        {
            tagBuilder = new TagBuilder(Span.TagName);
        }
        public new Span Contents(string contents)
        {
            return base.Contents(contents) as Span;
        }
        public new Span Contents(IEnumerable<Tag> contents)
        {
            return base.Contents(contents) as Span;
        }
        public new Span CssClasses(string cssClasses)
        {
            return base.CssClasses(cssClasses) as Span;
        }

        public new Span Id(string id)
        {
            return base.Id(id) as Span;
        }

        public new Span Style(string style)
        {
            return base.Style(style) as Span;
        }

    }
}
