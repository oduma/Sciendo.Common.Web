using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sciendo.Common.Web.Controllers
{
    public class AjaxExceptionWithOriginator:Exception
    {
        public string Originator { get; private set; }

        public AjaxExceptionWithOriginator(string message, string originator)
            : base(message)
        {
            Originator = originator;
        }
    }
}
