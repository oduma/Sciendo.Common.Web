using Sciendo.Common.Web.Components.Base;
using Sciendo.Common.Web.Styles;
using Sciendo.Common.Web.Tags;
using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Components
{
    public class LabelTextBox:Component
    {
        private string _id;
        private string _label;
        private int _size;
        private const string _inputPrefix="text";
        private const string _labelPrefix="label";
        public LabelTextBox Id(string id)
        {
            //temporary hack
            InputId = string.Format("{0}{1}{2}", _inputPrefix, "_", id);

            _id = id;
            return this;
        }

        public LabelTextBox Label(string label)
        {
            _label = label;
            return this;
        }

        public LabelTextBox Size(int size)
        {
            _size = size;
            return this;
        }

        internal string InputId { get; set; }

        internal override IEnumerable<string> Render()
        {
            Input input = new Input().InputType(TypeOfInput.Text).Size(_size).Id(InputId).CssClasses(Style.NewTextInput);
            Div div = new Div().Id(_id).Contents(new Tag[] { new Label().Id(string.Format("{0}{1}{2}",_labelPrefix,"_",_id)).Contents(_label), 
                 input}).CssClasses(Style.NewLabelTextBox);
            var result = new List<string>();
            _contents = new List<Tag>();
            _contents.Add(div);
            result.AddRange(AddContents());
            return result;
        }
    }
}
