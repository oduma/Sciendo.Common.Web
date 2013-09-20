using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Sciendo.Common.Web
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

    }
}
