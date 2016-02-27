using System.Web;
using System.Web.Optimization;

namespace sauemk.web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.6.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/sweetalert.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetalert").Include(
                      "~/Scripts/sweetalert.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/sweetalert.css",
                      "~/Content/Site.css"));

            //Angular
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-local-storage.min.js",
                        "~/Angular/app.js",
                        "~/Angular/Services/authInterceptorService.js",
                        "~/Angular/Services/authService.js",
                        "~/Angular/Controllers/Account.Login.Controller.js",
                        "~/Angular/Controllers/Account.Register.Controller.js",
                        "~/Angular/Controllers/Admin.EtkinlikEkle.Controller.js",
                        "~/Angular/Controllers/Admin.Index.Controller.js",
                        "~/Angular/Controllers/Admin.Liste.Controller.js",
                        "~/Angular/Controllers/Etkinlik.EtkinlikPage.Controller.js",
                        "~/Angular/Controllers/Etkinlik.Index.Controller.js",
                        "~/Angular/Controllers/Home.About.Controller.js",
                        "~/Angular/Controllers/Home.Index.Controller.js",
                        "~/Angular/Controllers/Shared.Layout.Controller.js",
                        "~/Angular/Controllers/Shared.LoginPartial.Controller.js"));

        }
    }
}
