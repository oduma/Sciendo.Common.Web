using System.Web.Optimization;

namespace Sciendo.Common.Web
{
    public static class SciendoBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var bundle = new ScriptBundle("~/bundles/sciendo").IncludeDirectory(
                        "~/Content/Scripts/", "*.js", false);
            bundles.Add(bundle);
            
            bundles.Add(new ScriptBundle("~/bundles/sciendo.components").IncludeDirectory(
                        "~/Content/Scripts/Components/", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/3rdparty").IncludeDirectory(
            "~/Content/Scripts/3rdParty/", "*.js", true));


            bundles.Add(new StyleBundle("~/Content/sciendo").IncludeDirectory("~/Content/CSS", "*.css", true));
        }
    }
}
