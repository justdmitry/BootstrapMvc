namespace Bootstrap3Mvc6.Sample.Controllers
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var types = new[]
            {
                typeof(BootstrapMvc.Core.IWritable).GetTypeInfo(),
                typeof(BootstrapMvc.Elements.Icon).GetTypeInfo(),
                typeof(BootstrapMvc.Mvc6.BootstrapHelper).GetTypeInfo(),
                typeof(BootstrapMvc.Bootstrap3Mvc6AnyContentExtensions).GetTypeInfo(),
                typeof(Microsoft.AspNetCore.Mvc.ActionResult).GetTypeInfo()
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
            var model = new Bootstrap3Mvc6.Sample.Models.DemoModelOne();
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