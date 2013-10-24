using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags
{
    public class Input:TagWithIdAndCss
    {
        public Input()
        {
            tagBuilder = new TagBuilder("input");
        }

        public new Input CssClasses(string cssClasses)
        {
            return base.CssClasses(cssClasses) as Input;
        }

        public Input InputType(TypeOfInput inputType)
        {
            Attribute("type", inputType.ToString());
            return this;
        }

        public Input Size(int size)
        {
            Attribute("size", size.ToString());
            return this;
        }

        public Input Value(string value)
        {
            Attribute("value", value);
            return this;
        }

        public new Input Id(string id)
        {
            return base.Id(id) as Input;
        }

        public new Input Style(string style)
        {
            return base.Style(style) as Input;
        }

    }
}
