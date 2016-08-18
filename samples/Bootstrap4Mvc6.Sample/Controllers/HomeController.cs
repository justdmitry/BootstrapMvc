namespace Bootstrap4Mvc6.Sample.Controllers
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
                typeof(BootstrapMvc.Alert).GetTypeInfo(),
                typeof(BootstrapMvc.Mvc6.BootstrapHelper).GetTypeInfo(),
                typeof(BootstrapMvc.Bootstrap4Mvc6AnyContentExtensions).GetTypeInfo(),
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

        [Route("/home/components/{component}")]
        public ActionResult Components(string component)
        {
            return View("Components/" + component);
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