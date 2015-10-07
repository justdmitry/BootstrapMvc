extern alias bootstrap3mvc5;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI;

namespace Bootstrap3Mvc5.Sample.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 60 * 60, Location = OutputCacheLocation.Any)]
        public ActionResult Index()
        {
            var versions = new string[4][];
            versions[0] = new[] { "BootstrapMvc.Core", typeof(BootstrapMvc.Core.WritableBlock).Assembly.GetName().Version.ToString() };
            versions[1] = new[] { "BootstrapMvc.Bootstrap3", typeof(BootstrapMvc.Elements.Icon).Assembly.GetName().Version.ToString() };
            versions[2] = new[] { "BootstrapMvc.Bootstrap3Mvc5", typeof(bootstrap3mvc5::BootstrapMvc.AnyContentExtensions).Assembly.GetName().Version.ToString() };
            versions[3] = new[] { "BootstrapMvc.Mvc5", typeof(BootstrapMvc.Core.BootstrapContext).Assembly.GetName().Version.ToString() };
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