using System;
using Microsoft.AspNet.Mvc;

namespace Bootstrap3Mvc6.Sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var versions = new string[4][];
            versions[0] = new[] { "BootstrapMvc.Core", typeof(BootstrapMvc.Core.WritableBlock).Assembly.GetName().Version.ToString() };
            versions[1] = new[] { "BootstrapMvc.Bootstrap3", typeof(BootstrapMvc.Elements.Icon).Assembly.GetName().Version.ToString() };
            versions[2] = new[] { "BootstrapMvc.Bootstrap3Mvc6", typeof(BootstrapMvc.Bootstrap3Mvc6.Bootstrap3Mvc6Marker).Assembly.GetName().Version.ToString() };
            versions[3] = new[] { "BootstrapMvc.Mvc6", typeof(BootstrapMvc.Core.BootstrapContext).Assembly.GetName().Version.ToString() };
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
            return View(new Bootstrap3Mvc6.Sample.Models.DemoModelOne());
        }

        public ActionResult Extend()
        {
            return View();
        }
    }
}