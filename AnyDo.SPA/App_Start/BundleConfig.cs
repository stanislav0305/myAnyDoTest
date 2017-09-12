using System.Web;
using System.Web.Optimization;

namespace AnyDo.SPA
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

          
            bundles.Add(new StyleBundle("~/Content/css/site").Include(
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css/uikit").Include(
                      "~/Content/uikit.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/uikit").Include(
                    "~/Scripts/uikit.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                   "~/Scripts/angular.min.js"));
        }
    }
}
