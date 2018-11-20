using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace Kadotto
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/assets/js/pluginsjs").Include(
               "~/assets/js/plugins/jquery-3.3.1.min.js",
                "~/assets/js/plugins/bootstrap.min.js",
                "~/assets/js/plugins/modernizr-2.8.3-respond-1.4.2.min.js",
                "~/assets/js/plugins/owl-carousel/owl.carousel.min.js",
                "~/assets/js/plugins/parallax.min.js",
                "~/assets/js/plugins/scrollReveal.min.js",
                "~/assets/js/plugins/bootstrap-dropdownhover.min.js"
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

            bundles.Add(new Bundle("~/assets/jsjs").Include(
            "~/assets/js/main.js"
            ));

            bundles.Add(new Bundle("~/assets/js/Kaadoto/Corejs").Include(
                "~/assets/js/Kaadoto/Core/Ajax.Service.js",
                "~/assets/js/Kaadoto/Core/Ajax.Models.Service.js",
                "~/assets/js/Kaadoto/Core/Tools.js",
                "~/assets/js/Kaadoto/Core/utility.js",
                "~/assets/js/Kaadoto/Core/validator.min.js",
                "~/assets/js/Kaadoto/Base/BaseInitializing.js",
                "~/assets/js/Kaadoto/Shop/Card.js"
                ));

            bundles.Add(new Bundle("~/assets/js/Kaadoto/Uploaderjs").Include(
              "~/assets/js/Kaadoto/Uploader/moxie.js",
              "~/assets/js/Kaadoto/Uploader/plupload.dev.js",
              "~/assets/js/Kaadoto/Uploader/plupload.js",
              "~/assets/js/Kaadoto/Uploader/jquery-ui-1.12.1.js",
              "~/assets/js/Kaadoto/Uploader/jquery.ui.plupload/jquery.ui.plupload.js"
               ));
        }
    }
}
