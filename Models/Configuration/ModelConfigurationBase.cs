using Sciendo.Common.Web.Components.Base;
using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;

namespace Sciendo.Common.Web.Models.Configuration
{
    public abstract class ModelConfigurationBase<TModel>:IModelConfiguration<TModel> 
        where TModel:ModelBase,new()
    {
        protected TModel Model;

        public ModelConfigurationBase()
        {
            Model = new TModel();
            InitiateConfigurator();
        }

        private void InitiateConfigurator()
        {
            ModelProperties = new List<ModelProperty>();
            ConfigureModel(Model);

        }
        public ModelConfigurationBase(TModel model)
        {
            Model = model;
            InitiateConfigurator();
        }

        protected abstract void ConfigureModel(TModel model);

        protected List<ModelProperty> ModelProperties;

        public ModelProperty ConfigureProperty<TProperty>(Func<TModel, KeyValuePair<string,TProperty>> func)
        {
            var modelProperty = new ModelProperty(func.Invoke(Model).Key,typeof (TProperty));
            ModelProperties.Add(modelProperty);
            return modelProperty;
        }

        public IEnumerable<Tag> RenderModel(Component component)
        {
            Ui<TModel> ui= new Ui<TModel>(Model);
            List<Tag> result = new List<Tag>();
            if (component.SubComponents == null)
                component.SubComponents=new List<Component>();
            foreach (var modelProperty in ModelProperties)
            {
                if (modelProperty.PropertyType == typeof(string) || modelProperty.PropertyType == typeof(decimal))
                {
                    var supportTag = ui.LabeledTextBox().Id(modelProperty.Id).Label(modelProperty.Label).Size(modelProperty.Size);
                    modelProperty.SupportTagId = supportTag.InputId;
                    result.Add(supportTag);
                    component.SubComponents.Add(supportTag);
                }
                else
                {
                    var supportTag = ui.LabeledDatePicker().Id(modelProperty.Id).Label(modelProperty.Label);
                    modelProperty.SupportTagId = supportTag.InputId;
                    result.Add(supportTag);
                    component.SubComponents.Add(supportTag);
                }
            }
            return result;
        }

        public IEnumerable<ClientModelTuple> BuildClientModel()
        {
            foreach (var modelProperty in ModelProperties)
            {
                yield return new ClientModelTuple{Name = modelProperty.PropertyName, SupportingTagId=modelProperty.SupportTagId};
            }
        }
    }
}
