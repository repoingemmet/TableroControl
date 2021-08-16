using System.Web;
using System.Web.Optimization;

namespace INGEMMET.TableroControl
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
                        
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js")
                //.Include("~/Scripts/respond.min.js")
                .Include("~/Scripts/Site.js")
                );

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/font-awesome.min.css")
                .Include("~/Content/site.css"));
        }
    }
}
