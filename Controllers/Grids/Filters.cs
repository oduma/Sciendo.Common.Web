
using System.IO;
using Newtonsoft.Json;

namespace Sciendo.Common.Web.Controllers.Grids
{
    public class Filters
    {
        public string groupOp { get; set; }
        public Rule[] rules { get; set; }
        public static Filters Create(GridSettings gridSettings)
        {
            if (!gridSettings._search)
                return null;
            if (!string.IsNullOrEmpty(gridSettings.searchField))
            {
                return new Filters
                {
                    rules =
                        new Rule[]
                                       {
                                           new Rule
                                               {
                                                   field = gridSettings.searchField,
                                                   data = gridSettings.searchString,
                                                   op = gridSettings.searchOper
                                               }
                                       }
                };
            }
            JsonSerializer serializer= new JsonSerializer();

            using(TextReader reader = new StringReader(gridSettings.filters))
            {
                return serializer.Deserialize(reader, typeof (Filters)) as Filters;
            }
        }
    }

}
