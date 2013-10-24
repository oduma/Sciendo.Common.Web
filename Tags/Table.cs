using System.Collections.Generic;
using System.Web.Mvc;
using Sciendo.Common.Web.Tags.Base;

namespace Sciendo.Common.Web.Tags
{
    public class Table:TagWithContents
    {
                public readonly static string TagName="table";
        public Table()
        {
            tagBuilder = new TagBuilder(TagName);
        }
        public new Table Contents(IEnumerable<Tag> contents)
        {
            return base.Contents(contents) as Table;
        }
        public new Table CssClasses(string cssClasses)
        {
            return base.CssClasses(cssClasses) as Table;
        }

        public new Table Id(string id)
        {
            return base.Id(id) as Table;
        }

        public new Table Style(string style)
        {
            return base.Style(style) as Table;
        }

    }
}
