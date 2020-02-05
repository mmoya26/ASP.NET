using System.Web;
using System.Web.Optimization;

namespace Assignment1
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            // Custom JavaScript - image click thumbnail
            bundles.Add(new ScriptBundle("~/bundles/imageClick").Include("~/Scripts/imageClick.js"));
        }
    }
}
