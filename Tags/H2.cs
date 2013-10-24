using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags
{
    public class H2 : TagWithContents
    {
        public H2()
        {
            tagBuilder = new TagBuilder("h2");
        }

        public new H2 CssClasses(string cssClasses)
        {
            return base.CssClasses(cssClasses) as H2;
        }

        public new H2 Contents(string contents)
        {
            return base.Contents(contents) as H2;
        }
        public new H2 Contents(IEnumerable<Tag> contents)
        {
            return base.Contents(contents) as H2;
        }

        public new H2 Style(string style)
        {
            return base.Style(style) as H2;
        }


    }
}