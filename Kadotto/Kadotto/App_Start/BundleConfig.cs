using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace Kadotto
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new Bundle("~/App_Themes/Themes-css").Include(
            //    "~/App_Themes/Themes/Default.css",
            //    "~/App_Themes/Themes/smart_wizard_theme_arrows.css",
            //    "~/App_Themes/Themes/smart_wizard_theme_circles.css",
            //    "~/App_Themes/Themes/smart_wizard_theme_dots.css"
            //    ));
            //ScriptManager.ScriptResourceMapping.AddDefinition(
            //    "respond",
            //    new ScriptResourceDefinition
            //    {
            //        Path = "~/Scripts/General/respond.min.js",
            //        DebugPath = "~/Scripts/General/respond.js",
            //    });

            bundles.Add(new Bundle("~/assets/js/pluginsjs").Include(
               "~/assets/js/plugins/jquery-1.11.3.min.js",
                   "~/assets/js/plugins/bootstrap.min.js",
                   "~/assets/js/plugins/modernizr-2.8.3-respond-1.4.2.min.js",
                   "~/assets/js/plugins/owl-carousel/owl.carousel.min.js",
                   "~/assets/js/plugins/parallax.min.js",
                   "~/assets/js/plugins/scrollReveal.min.js",
                   "~/assets/js/plugins/bootstrap-dropdownhover.min.js"
            //"~/~/Scripts/General/jquery-1.11.3.min.js",
            //"~/Scripts/General/jquery.cookie.min.js",
            //"~/Scripts/General/bootstrap.min.js",
            //"~/Scripts/General/jquery.validate.min.js",
            //"~/Scripts/General/validator.min.js",
            //"~/Scripts/General/typeahead.bundle.js"
            ));

            bundles.Add(new Bundle("~/assets/js/plugins/revolution/jsjs").Include(
               "~/assets/js/plugins/revolution/js/jquery.themepunch.tools.min.js",
               "~/assets/js/plugins/revolution/js/jquery.themepunch.revolution.min.js"
               ));

            bundles.Add(new Bundle("~/assets/js/plugins/revolution/js/extensionsjs").Include(
             "~/assets/js/plugins/revolution/js/extensions/revolution.extension.actions.min.js",
             "~/assets/js/plugins/revolution/js/extensions/revolution.extension.carousel.min.js",
             "~/assets/js/plugins/revolution/js/extensions/revolution.extension.kenburn.min.js",
             "~/assets/js/plugins/revolution/js/extensions/revolution.extension.layeranimation.min.js",
             "~/assets/js/plugins/revolution/js/extensions/revolution.extension.migration.min.js",
             "~/assets/js/plugins/revolution/js/extensions/revolution.extension.navigation.min.js",
             "~/assets/js/plugins/revolution/js/extensions/revolution.extension.parallax.min.js",
             "~/assets/js/plugins/revolution/js/extensions/revolution.extension.slideanims.min.js",
             "~/assets/js/plugins/revolution/js/extensions/revolution.extension.video.min.js"
            ));
            //bundles.Add(new Bundle("~/Scripts/Corejs").Include(
            //  //"~/Scripts/Core/swiper.min.js",
            //  "~/Scripts/Core/Ajax.Service.js",
            //  "~/Scripts/Core/Ajax.Models.Service.js",
            //  "~/Scripts/Core/utility.js",
            //  "~/Scripts/Core/Tools.js",
            //  "~/Scripts/Core/modernizr-2.8.3-respond-1.4.2.min.js",
            //  "~/Scripts/Core/owl.carousel.min.js",
            //  "~/Scripts/Core/parallax.min.js",
            //  "~/Scripts/Core/scrollReveal.min.js",
            //  "~/Scripts/Core/bootstrap-dropdownhover.min.js"
            //));

            bundles.Add(new Bundle("~/assets/jsjs").Include(
            "~/assets/js/main.js"
            ));
        }
    }
}
