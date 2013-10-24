using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags
{
    public class Literal:TagWithContents
    {
        public Literal()
        {
            //tagBuilder = new TagBuilder("");
        }

        public new Literal Contents(string contents)
        {
            return base.Contents(contents) as Literal;
        }
    }
}
