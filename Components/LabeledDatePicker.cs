using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Sciendo.Common.Web.Components.Base;
using Sciendo.Common.Web.Styles;
using Sciendo.Common.Web.Tags;
using Sciendo.Common.Web.Tags.Base;

namespace Sciendo.Common.Web.Components
{
    public class LabeledDatePicker:Component
    {
        private string _id;
        private string _label;
        private const string _inputPrefix="datepicker";
        private const string _labelPrefix = "label";

        public LabeledDatePicker Id(string id)
        {
            //temporary hack
            InputId = string.Format("{0}{1}{2}", _inputPrefix, "_", id);

            _id = id;
            return this;
        }

        public string InputId { get; private set; }

        public LabeledDatePicker Label(string label)
        {
            _label = label;
            return this;
        }

        internal override IEnumerable<string> Render()
        {
            Input input = new Input().InputType(TypeOfInput.Text).Id(InputId).CssClasses(Style.NewTextInput);
            Div div = new Div().Id(_id).Contents(new Tag[] { new Label().Id(string.Format("{0}{1}{2}",_labelPrefix,"_",_id)).Contents(_label), 
                 input}).CssClasses(Style.NewLabelTextBox);
            var result = new List<string>();
            _contents = new List<Tag>();
            _contents.Add(div);
            result.AddRange(AddContents());
            return result;
        }

        public override string InitializeJavaScript()
        {
            return string.Format(
                        @"{0}components.DatePicker('" + InputId + "');",
                        base.InitializeJavaScript());
        }
    }
}
