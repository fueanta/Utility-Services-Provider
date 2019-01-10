using System.Web.Optimization;

namespace Application
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/notify.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/table").Include(
                        "~/scripts/datatables/jquery.datatables.js",
                        "~/scripts/datatables/datatables.bootstrap4.js",
                        "~/scripts/datatables/dataTables.buttons.js",
                        "~/scripts/datatables/buttons.bootstrap4.js",
                        "~/scripts/datatables/buttons.flash.js",
                        "~/scripts/datatables/buttons.print.js",
                        "~/scripts/datatables/buttons.html5.js",
                        "~/scripts/datatables/buttons.colVis.js",
                        "~/scripts/datatables/jszip.js",
                        "~/scripts/datatables/pdfmake.js",
                        "~/scripts/datatables/vfs_fonts.js",
                        "~/scripts/datatables/dataTables.fixedColumns.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/all.css",
                      "~/content/datatables/css/datatables.bootstrap4.css",
                      "~/content/datatables/css/buttons.bootstrap4.css",
                      "~/Content/themes/base/jquery-ui.css",
                      "~/Content/site.css"));
        }
    }
}
