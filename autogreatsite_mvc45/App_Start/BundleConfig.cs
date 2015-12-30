﻿using System.Web;
using System.Web.Optimization;

namespace autogreatsite_mvc45
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/site.js",
                        "~/Scripts/Slick/slick.js",
                        "~/Scripts/fotorama.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                                "~/Scripts/jquery.form.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/dropzonejs").Include(
                      "~/Scripts/dropzone/dropzone.js"));

            bundles.Add(new StyleBundle("~/bundles/dropzonecss").Include(
                      "~/Scripts/dropzone/base.css",
                      "~/Scripts/dropzone/dropzone.css"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/themes/base/*.css",
                      "~/Content/site.css",
                      "~/Scripts/slick/slick.css",
                      "~/Scripts/slick/slick-theme.css",
                      "~/Content/fotorama.css")
                      );

            bundles.Add(new ScriptBundle("~/bundles/echo").Include(
                "~/Scripts/echo.js"
                ));

            bundles.Add(new StyleBundle("~/Content/loadplug").Include(
                "~/Content/Load.css"
                ));

            // BundleTable.EnableOptimizations = true;
        }
    }
}
