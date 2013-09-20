namespace Sciendo.Common.Web.Components.Base
{
    public interface IGridColumn
    {
        string Label { get; }
        string GetJsonStringDefinition();
    }

}
