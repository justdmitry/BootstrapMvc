namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class ContainerExtensions
    {
        public static IItemWriter<T, AnyContent> Fluid<T>(this IItemWriter<T, AnyContent> target, bool fluid)
            where T : Container
        {
            target.Item.Fluid = fluid;
            return target;
        }

        public static IItemWriter<Container, AnyContent> Container(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<Container, AnyContent>();
        }

        public static IItemWriter<Container, AnyContent> Container(this IAnyContentMarker contentHelper, bool fluid)
        {
            return contentHelper.CreateWriter<Container, AnyContent>().Fluid(fluid);
        }

        public static IItemWriter<Container, AnyContent> Container(this IAnyContentMarker contentHelper, object content)
        {
            return contentHelper.CreateWriter<Container, AnyContent>().Content(content);
        }

        public static IItemWriter<Container, AnyContent> Container(this IAnyContentMarker contentHelper, bool fluid, object content)
        {
            return contentHelper.CreateWriter<Container, AnyContent>().Fluid(fluid).Content(content);
        }

        public static IItemWriter<Container, AnyContent> Container(this IAnyContentMarker contentHelper, bool fluid, params object[] content)
        {
            return contentHelper.CreateWriter<Container, AnyContent>().Fluid(fluid).Content(content);
        }

        public static AnyContent BeginContainer(this IAnyContentMarker contentHelper)
        {
            return Container(contentHelper).BeginContent();
        }

        public static AnyContent BeginContainer(this IAnyContentMarker contentHelper, bool fluid)
        {
            return Container(contentHelper).Fluid(fluid).BeginContent();
        }
    }
}
