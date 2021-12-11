using System.Web;
using System.Web.Optimization;

namespace Auth.Web
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Content/bootstrap/js/bootstrap.min.js"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            bundles.Add(new StyleBundle("~/plugins/css").Include(
                 "~/Content/bootstrap/css/bootstrap.min.css",
                "~/Content/font-awesome/css/font-awesome.min.css",
                "~/Content/simple-line-icons/simple-line-icons.min.css",
                "~/Content/plugins.css",
                "~/Content/components-rounded.css"
            ));

            bundles.Add(new StyleBundle("~/layout/css").Include(
                "~/Content/layout/css/layout.min.css",
                "~/Content/layout/css/themes/darkblue.min.css"
                //"~/Content/layout/css/custom.min.css"
            ));
        }
    }
}
