using System.Web;
using System.Web.Optimization;

namespace FormularioAspNetNew
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-3.4.1.min.js",
                        "~/Scripts/jquery.mask.min.js", //Sempre colocar para funcionar as mascaras
                        "~/Scripts/mascara.js")); 

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",//Permite funcionar o DataAnnotations e o asterisco carrega todos os scripts de validacao da pasta scripts
                        "~/Scripts/validacao_ptbr.js")); //Valida formato de data e valor do brasil, para funcionar a data precisa ser colocado aqui, tentei colocar no método acima mas nao funcionou.



            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
