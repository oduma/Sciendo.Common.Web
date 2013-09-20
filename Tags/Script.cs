using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags
{
    public class Script:Tag
    {
        public Script()
        {
            tagBuilder = new TagBuilder("script");
        }

        public Script Src(string src)
        {
            return base.Attribute("src", src) as Script;
        }
    }
}
