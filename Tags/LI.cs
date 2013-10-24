using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags
{
    public class LI:TagWithContents
    {
        public LI()
        {
            tagBuilder = new TagBuilder("li");
        }

        public new LI CssClasses(string cssClasses)
        {
            return base.CssClasses(cssClasses) as LI;
        }

        public new LI Contents(string contents)
        {
            return base.Contents(contents) as LI;
        }
        public new LI Contents(IEnumerable<Tag> contents)
        {
            return base.Contents(contents) as LI;
        }

        public new LI Id(string id)
        {
            return base.Id(id) as LI;
        }


        public new LI Style(string style)
        {
            return base.Style(style) as LI;
        }

    }
}
