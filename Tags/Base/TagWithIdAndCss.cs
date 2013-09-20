using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags.Base
{
    public abstract class TagWithIdAndCss:Tag
    {
        
        public Tag Id(string id)
        {
            tagBuilder.GenerateId(id);
            return this;
        }

        protected Tag CssClasses(string cssClasses)
        {
            return Attribute("class", cssClasses);
        }
    }
}
