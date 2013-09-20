using Sciendo.Common.Web.Components;
using Sciendo.Common.Web.Components.Base;
using Sciendo.Common.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sciendo.Common.Web.Views.Base
{
    public class BaseView<T> : WebViewPage<T>
    {
        public Ui<T> Ui { get; set; }
        public override void InitHelpers()
        {
            base.InitHelpers();
            Ui = new Ui<T>(Model);
        }

        private List<Component> _components;
        protected List<Component> Components { get { return _components = (_components) ?? new List<Component>(); } }

        public override void Execute()
        {
            ;
        }

    }
}
