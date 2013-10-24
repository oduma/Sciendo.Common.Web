using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags
{
    public class Div : TagWithContents
    {
        public readonly static string TagName="div";
        public Div()
        {
            tagBuilder = new TagBuilder(Div.TagName);
        }
        public new Div Contents(string contents)
        {
            return base.Contents(contents) as Div;
        }
        public new Div Contents(IEnumerable<Tag> contents)
        {
            return base.Contents(contents) as Div;
        }
        public new Div CssClasses(string cssClasses)
        {
            return base.CssClasses(cssClasses) as Div;
        }

        public new Div Id(string id)
        {
            return base.Id(id) as Div;
        }

        public Div Title(string title)
        {
            return base.Attribute("title", title) as Div;
        }

        public new Div Style(string style)
        {
            return base.Style(style) as Div;
        }
    }
}