using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags
{
    public class P:TagWithContents
    {
        public P()
        {
            tagBuilder = new TagBuilder("p");
        }
        public new P CssClasses(string cssClasses)
        {
            return base.CssClasses(cssClasses) as P;
        }


        public new P Contents(string contents)
        {
            return base.Contents(contents) as P;
        }
        public new P Contents(IEnumerable<Tag> contents)
        {
            return base.Contents(contents) as P;
        }

    }
}
