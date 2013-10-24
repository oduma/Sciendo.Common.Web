using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sciendo.Common.Web.Components;
using Sciendo.Common.Web.Components.Grids;
using Sciendo.Common.Web.Models;
using Sciendo.Common.Web.Models.Configuration;

namespace Sciendo.Common.Web
{
    public partial class Ui<T>
    {
        public Search Search()
        {
            return new Search();
        }

        public EntryFormFor<TModel> EntryFormFor<TModel>(ModelConfigurationBase<TModel> modelConfiguration) where TModel:ModelBase, new()
        {
            return new EntryFormFor<TModel>(modelConfiguration);
        }

        public LabelTextBox LabeledTextBox()
        {
            return new LabelTextBox();
        }

        public LabeledDatePicker LabeledDatePicker()
        {
            return new LabeledDatePicker();
        }

        public Grid Grid()
        {
            return new Grid();
        }

        public Grid<TProperty> GridFor<TProperty>(Expression<Func<T, TProperty>> func)
        {
            TProperty value = _model == null ? default(TProperty) : func.Compile()(_model);
            return new Grid<TProperty>(value);
        }

        public ErrorDisplayer ErrorDisplayer()
        {
            return new ErrorDisplayer();
        }

        public DialogErrorDisplayer DialogErrorDisplayer()
        {
            return new DialogErrorDisplayer();
        }

        public AsynchUl AsynchUl()
        {
            return new AsynchUl();
        }
    }
}
