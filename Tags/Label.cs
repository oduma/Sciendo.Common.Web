using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags
{
    public class Label:TagWithContents
    {
        public Label()
        {
            tagBuilder = new TagBuilder("label");
        }

        public new Label CssClasses(string cssClasses)
        {
            return base.CssClasses(cssClasses) as Label;
        }

        public new Label Contents(string contents)
        {
            return base.Contents(contents) as Label;
        }

        public new Label Id(string id)
        {
            return base.Id(id) as Label;
        }
    }
}
