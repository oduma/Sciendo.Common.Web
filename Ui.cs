using Sciendo.Common.Web.Tags;
using Sciendo.Common.Web.Tags.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Sciendo.Common.Web
{
    public partial class Ui<T>
    {
        private T _model; 
        public Ui(T model)
        {
            _model = model;
        }
        public Ul Ul()
        {
            return new Ul();
        }
        public H2 H2()
        {
            return new H2();
        }
        public Div Div()
        {
            return new Div();
        }

        public Div TitledDiv(string id, string title)
        {
            return new Div().Contents(new Tag[]{new H2().Contents(title).CssClasses("title")}).Id(id).CssClasses("title-container") as Div;
        }

        public Label Label()
        {
            return new Label();
        }
        public Input Input()
        {
            return new Input();
        }

        public P P()
        {
            return new P();
        }

        public LI LI()
        {
            return new LI();
        }

        public Ul UlFor(Func<T, IEnumerable<LI>> func,string id)
        {
            return new Ul().Contents(func.Invoke(_model)).Id(id) as Ul;
        }

        public HtmlString IncludeCommonCss()
        {
            return new Link().Href("Content/CSS/Common.css").RenderHtml();
        }

        public Link Link()
        {
            return new Link();
        }

        public Section MainSection()
        {
            return new Section().CssClasses("content-wrapper main-content clear-fix");
        }

        public HtmlString IncludeCommonJs()
        {
            return new Script().Src("Content/Scripts/Sciendo.Common.js").RenderHtml();
        }

        public Table Table()
        {
            return new Table();
        }
    }
}