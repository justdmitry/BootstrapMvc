using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.UI;

namespace Bootstrap3Mvc5.Sample.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 60 * 60, Location = OutputCacheLocation.Any)]
        public ActionResult Index()
        {
            var types = new[]
            {
                typeof(BootstrapMvc.Core.IWritable),
                typeof(BootstrapMvc.Elements.Icon),
                typeof(BootstrapMvc.Mvc5LinkExtensions),
                typeof(BootstrapMvc.Bootstrap3Mvc5AnyContentExtensions),
                typeof(System.Web.Mvc.ActionResult)
            };

            var versions = types.Select(x => new[]
            {
                x.Assembly.GetName().Name,
                x.Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion
            }).ToArray();

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

        public ActionResult Forms()
        {
            return View(new Bootstrap3Mvc5.Sample.Models.DemoModelOne());
        }

        public ActionResult Extend()
        {
            return View();
        }
    }
}