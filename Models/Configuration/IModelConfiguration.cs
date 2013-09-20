using Sciendo.Common.Web.Components;
using Sciendo.Common.Web.Components.Base;
using Sciendo.Common.Web.Tags.Base;
using System.Collections.Generic;

namespace Sciendo.Common.Web.Models.Configuration
{
    public interface IModelConfiguration<TModel> where TModel: ModelBase
    {

        IEnumerable<Tag> RenderModel(Component component);

        IEnumerable<ClientModelTuple> BuildClientModel();
    }
}
