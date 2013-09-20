using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags
{
    public class Ul:TagWithContents
    {
        public Ul()
        {
            tagBuilder = new TagBuilder("ul");
        }
        public new Ul CssClasses(string cssClasses)
        {
            return base.CssClasses(cssClasses) as Ul;
        }


        public new Ul Contents(IEnumerable<Tag> contents)
        {
            return base.Contents(contents) as Ul;
        }

    }
}