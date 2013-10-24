using Sciendo.Common.Web.Tags.Base;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags
{
    public class Section:TagWithContents
    {
        public Section()
        {
            tagBuilder = new TagBuilder("section");
        }

        public new Section Contents(string contents)
        {
            return base.Contents(contents) as Section;
        }
        public new Section Contents(IEnumerable<Tag> contents)
        {
            return base.Contents(contents) as Section;
        }
        public new Section CssClasses(string cssClasses)
        {
            return base.CssClasses(cssClasses) as Section;
        }

        public new Section Id(string id)
        {
            return base.Id(id) as Section;
        }


        public new Section Style(string style)
        {
            return base.Style(style) as Section;
        }

    }
}
