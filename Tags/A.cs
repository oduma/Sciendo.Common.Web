using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags
{
    public class A:TagWithContents
    {
        public A()
        {
            tagBuilder = new TagBuilder("a");
        }

        public A Href(string url)
        {
            return base.Attribute("href", url) as A;
        }

        public new A Id(string id)
        {
            return base.Id(id) as A;
        }

        public new A Contents(string contents)
        {
            return base.Contents(contents) as A;
        }
    }
}
