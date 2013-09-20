using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags
{
    public class Link:Tag
    {
        public Link()
        {
            tagBuilder = new TagBuilder("link");
            base.Attribute("rel", "stylesheet");
        }

        public Link Href(string href)
        {
            return base.Attribute("href", href) as Link;
        }

    }
}
