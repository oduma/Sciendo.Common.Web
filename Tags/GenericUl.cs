using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Tags
{
    public class Ul<T>:TagWithContents
    {
        private T _ulModel;

        public Ul<T> Contents(Func<T, IEnumerable<Tag>> func)
        {
            if (_contents == null)
                _contents = new List<Tag>();
            _contents.AddRange(func.Invoke(_ulModel));
            return this;
        }

        public Ul(T ulModel)
        {
            _ulModel=ulModel;
            tagBuilder = new TagBuilder("ul");
        }

        public new Ul<T> CssClasses(string cssClasses)
        {
            return base.CssClasses(cssClasses) as Ul<T>;
        }


        public new Ul<T> Contents(IEnumerable<Tag> contents)
        {
            return base.Contents(contents) as Ul<T>;
        }


        public new Ul<T> Style(string style)
        {
            return base.Style(style) as Ul<T>;
        }

        public new Ul<T> Id(string id)
        {
            return base.Id(id) as Ul<T>;
        }
    }
}
