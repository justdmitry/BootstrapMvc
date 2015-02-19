extern alias bootstrap3mvc5;

using System.Collections.Specialized;
using System.Web.Mvc;
using System.Web.UI;

namespace Bootstrap3Mvc5.Sample.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 60 * 60 * 24, Location = OutputCacheLocation.Any)]
        public ActionResult Index()
        {
            var versions = new NameValueCollection();
            versions.Add("Bootstrapmvc.Core", typeof(BootstrapMvc.Core.WritableBlock).Assembly.GetName().Version.ToString());
            versions.Add("Bootstrapmvc.Mvc5", typeof(BootstrapMvc.Core.BootstrapContext).Assembly.GetName().Version.ToString());
            versions.Add("Bootstrapmvc.Bootstrap3", typeof(BootstrapMvc.Elements.Icon).Assembly.GetName().Version.ToString());
            versions.Add("Bootstrapmvc.Bootstrap3Mvc5", typeof(bootstrap3mvc5::BootstrapMvc.AnyContentExtensions).Assembly.GetName().Version.ToString());
            return View(versions);
        }

        public ActionResult Installation()
        {
            return View();
        }

        public ActionResult Basics()
        {
            return View();
        }

        public ActionResult Components()
        {
            return View();
        }

        public ActionResult Extend()
        {
            return View();
        }
    }
}