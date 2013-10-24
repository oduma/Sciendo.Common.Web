using System.Collections.Generic;
using Sciendo.Common.Web.Tags;
using Sciendo.Common.Web.Tags.Base;

namespace Sciendo.Common.Web.Components
{
    public class DialogErrorDisplayer:ErrorDisplayer
    {
        private const string _messageBoxId="dialog_message";
        private string _title;
        private string _cssClasses;

        public DialogErrorDisplayer Title(string title)
        {
            _title = title;
            return this;
        }

        public DialogErrorDisplayer CssClasses(string cssClasses)
        {
            _cssClasses = cssClasses;
            return this;
        }

        internal override IEnumerable<string> Render()
        {
            _contents = new List<Tag>
                            {
                                new Div().Id(string.Format("{0}{1}{2}", _messageBoxId, "_", _baseId)).Title(_title).
                                    Contents(new Tag[]
                                                 {
                                                     new P().Contents(new Tag[]
                                                                          {new Span().CssClasses(_cssClasses).Id(Id).Style("float: left; margin: 0 7px 50px 0;")})
                                                 })
                            };
            return AddContents();
        }

    }
}
