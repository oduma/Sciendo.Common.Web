using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sciendo.Common.Web.Components
{
    public class ControllerAction
    {
        public string Controller { get; private set; }

        public string Action { get; private set; }

        public ControllerAction(string controller, string action)
        {
            Controller = controller;
            Action = action;
        }
    }
}
