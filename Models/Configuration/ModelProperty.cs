using System;

namespace Sciendo.Common.Web.Models.Configuration
{
    public class ModelProperty
    {
        public ModelProperty(string modelPropertyName,Type modelPropertyType)
        {
            PropertyName = modelPropertyName;
            PropertyType = modelPropertyType;
        }

        public ModelProperty()
        {
            
        }
        internal Type PropertyType { get; set; }

        internal string Id { get; private set; }

        internal string Label { get; private set; }
        internal int Size { get; private set; }
        internal string CssClasses { get; private set; }

        public ModelProperty SetId(string id)
        {
            Id = id;
            return this;
        }

        public ModelProperty SetLabel(string label)
        {
            Label = label;
            return this;
        }

        public ModelProperty SetSize(int size)
        {
            Size = size;
            return this;
        }

        public ModelProperty SetCssClasses(string cssClasses)
        {
            CssClasses = cssClasses;
            return this;
        }
        public int RankingOrder { get; set; }

        internal string SupportTagId { get; set; }

        public string PropertyName { get; internal set; }
    }
}
