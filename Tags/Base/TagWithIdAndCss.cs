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

        protected Tag Style(string style)
        {
            return Attribute("style", style);
        }
    }
}
