using System;
using Microsoft.AspNet.Mvc;
using System.Linq;
using System.Reflection;

namespace Bootstrap4Mvc6.Sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var types = new[]
            {
                typeof(BootstrapMvc.Core.IWritable),
                //typeof(BootstrapMvc.Elements.Icon),
                typeof(BootstrapMvc.Mvc6.BootstrapHelper),
                //typeof(BootstrapMvc.Bootstrap4Mvc6AnyContentExtensions),
                typeof(Microsoft.AspNet.Mvc.ActionResult)
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

        public ActionResult Layout()
        {
            return View();
        }

        public ActionResult Forms()
        {
            var model = new Bootstrap4Mvc6.Sample.Models.DemoModelOne();
            model.FieldWithError = "Some wrong value";
            ModelState.AddModelError("FieldWithError", "Demo error message for field FieldWithError");
            ModelState.AddModelError(string.Empty, "Demo error message for whole model");
            return View(model);
        }

        public ActionResult Extend()
        {
            return View();
        }
    }
}